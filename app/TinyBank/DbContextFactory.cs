using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

using TinyBank.Core;
using TinyBank.Core.Config.Extensions;

namespace TinyBank
{
    public class DbContextFactory : IDesignTimeDbContextFactory<CrmDbContext>
    {
        public CrmDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath($"{AppDomain.CurrentDomain.BaseDirectory}")
                .AddJsonFile("appsettings.json", false)
                .Build();

            var config = configuration.ReadAppConfiguration();

            var optionsBuilder = new DbContextOptionsBuilder<CrmDbContext>();

            optionsBuilder.UseSqlServer(
                config.CrmConnectionString,
                options => {
                    options.MigrationsAssembly("TinyBank");
                });

            return new CrmDbContext(optionsBuilder.Options);
        }
    }
}
