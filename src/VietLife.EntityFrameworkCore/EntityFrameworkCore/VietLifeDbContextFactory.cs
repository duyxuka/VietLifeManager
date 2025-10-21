using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace VietLife.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class VietLifeDbContextFactory : IDesignTimeDbContextFactory<VietLifeDbContext>
{
    public VietLifeDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        VietLifeEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<VietLifeDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new VietLifeDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../VietLife.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
