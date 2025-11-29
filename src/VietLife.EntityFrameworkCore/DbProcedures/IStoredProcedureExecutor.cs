using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietLife.DbProcedures
{
    public interface IStoredProcedureExecutor
    {
        /// <summary>
        /// Thực thi stored procedure trả về list hàng (mỗi hàng là Dictionary column->value).
        /// </summary>
        Task<List<Dictionary<string, object?>>> ExecAsync(string storedProcedureName, Dictionary<string, object?> parameters);

        /// <summary>
        /// Thực thi stored procedure không trả về result set (như UPDATE/INSERT) — trả về số rows affected.
        /// </summary>
        Task<int> ExecNonQueryAsync(string storedProcedureName, Dictionary<string, object?> parameters);
    }
}
