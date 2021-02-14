using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TinyBank.Core.Model;
using TinyBank.Core.Data;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Threading.Tasks;
using TinyBank.Core.Config.Extensions;
using TinyBank.Core.Services;
using TinyBank.Core.Services.Options;

namespace TinyTest
{
    public class TestTransaction
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath($"{AppDomain.CurrentDomain.BaseDirectory}")
            .AddJsonFile("appsettings.json", false)
            .Build();

            var config = configuration.ReadAppConfiguration();

            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer(
                config.CrmConnectionString,
                options =>
                {
                    options.MigrationsAssembly("TinyBank.Migrations");
                });

            using (var dbContext = new CrmDbContext(optionsBuilder.Options))
            {
                var opt = new CreateTransactionOptions()
                {
                    AccountId = "3333333333",
                    TrnAmount = 50,
                    CustomerId = 1,
                    Category = TrnCategory.Xrewsh
                };

                var trn = new TransactionService(dbContext).CreateTransactionAsync(opt).Result.Data;

                if (trn == null) { Console.WriteLine("Unable to make the transaction"); }
                else
                {
                    var acc = new AccountService(dbContext).FindAccountAsync(opt.AccountId).Result.Data;
                    Console.WriteLine("Account: " + trn.AccountId);
                    Console.WriteLine("TrnAmount: " + trn.TrnAmount);
                    Console.WriteLine("Total Amount: " + acc.TotalAmount);
                }



            }
        }
    }
}
