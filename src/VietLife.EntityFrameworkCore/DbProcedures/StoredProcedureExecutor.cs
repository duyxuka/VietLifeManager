using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using VietLife.EntityFrameworkCore;

namespace VietLife.DbProcedures
{
    /// <summary>
    /// Implementation for calling stored procedures via DbConnection.
    /// Exposed as IStoredProcedureExecutor for DI.
    /// </summary>
    [ExposeServices(typeof(IStoredProcedureExecutor))]
    public class StoredProcedureExecutor : IStoredProcedureExecutor, ITransientDependency
    {
        private readonly IDbContextProvider<VietLifeDbContext> _dbContextProvider;

        public StoredProcedureExecutor(IDbContextProvider<VietLifeDbContext> dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public async Task<List<Dictionary<string, object?>>> ExecAsync(string storedProcedureName, Dictionary<string, object?> parameters)
        {
            if (string.IsNullOrWhiteSpace(storedProcedureName)) throw new ArgumentNullException(nameof(storedProcedureName));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var connection = dbContext.Database.GetDbConnection();

            try
            {
                if (connection.State != ConnectionState.Open)
                    await connection.OpenAsync();

                using var cmd = connection.CreateCommand();
                cmd.CommandText = storedProcedureName;
                cmd.CommandType = CommandType.StoredProcedure;

                // Add parameters
                foreach (var kv in parameters ?? new Dictionary<string, object?>())
                {
                    var param = cmd.CreateParameter();
                    param.ParameterName = kv.Key.StartsWith("@") ? kv.Key : "@" + kv.Key;
                    param.Value = kv.Value ?? DBNull.Value;
                    cmd.Parameters.Add(param);
                }

                using var reader = await cmd.ExecuteReaderAsync();

                var result = new List<Dictionary<string, object?>>();

                while (await reader.ReadAsync())
                {
                    var row = new Dictionary<string, object?>(StringComparer.OrdinalIgnoreCase);
                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        var name = reader.GetName(i);
                        var val = await reader.IsDBNullAsync(i) ? null : reader.GetValue(i);
                        row[name] = val;
                    }
                    result.Add(row);
                }

                return result;
            }
            finally
            {
                // Do not close connection explicitly if connection is shared by EF (but safe to close)
                if (connection.State == ConnectionState.Open)
                    await connection.CloseAsync();
            }
        }

        public async Task<int> ExecNonQueryAsync(string storedProcedureName, Dictionary<string, object?> parameters)
        {
            if (string.IsNullOrWhiteSpace(storedProcedureName)) throw new ArgumentNullException(nameof(storedProcedureName));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var connection = dbContext.Database.GetDbConnection();

            try
            {
                if (connection.State != ConnectionState.Open)
                    await connection.OpenAsync();

                using var cmd = connection.CreateCommand();
                cmd.CommandText = storedProcedureName;
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (var kv in parameters ?? new Dictionary<string, object?>())
                {
                    var param = cmd.CreateParameter();
                    param.ParameterName = kv.Key.StartsWith("@") ? kv.Key : "@" + kv.Key;
                    param.Value = kv.Value ?? DBNull.Value;
                    cmd.Parameters.Add(param);
                }

                var affected = await cmd.ExecuteNonQueryAsync();
                return affected;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    await connection.CloseAsync();
            }
        }
    }
}
