using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyBank.Core.Data;
using TinyBank.Core.Config.Extensions;

namespace TinyBank.Migrations
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
                    options.MigrationsAssembly("TinyBank.Migrations");
                });

            return new CrmDbContext(optionsBuilder.Options);
        }
    }
}
