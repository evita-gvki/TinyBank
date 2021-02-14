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

namespace TinyBank.Migrations
{
    class Program
    {
     // const string connectionString =

      //   "Server=localhost;Database=crmdb2;User Id=sa;Password=admin!@#123;";



        static void Main(string[] args)

        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath($"{AppDomain.CurrentDomain.BaseDirectory}")
            .AddJsonFile("appsettings.json", false)
            .Build();

            var config = configuration.ReadAppConfiguration();

            //var optionsBuilder = new DbContextOptionsBuilder<BankDbContext>();
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer(
                config.CrmConnectionString,
                options =>
                {
                    options.MigrationsAssembly("TinyBank.Migrations");
                });
            //var options = new DbContextOptionsBuilder();
            //    options.UseSqlServer(connectionString_,
            //        optionw => { options.MigrationsAssembly("TinyBank.Migrations")};


            //var config = new ConfigurationBuilder()
            //    .SetBasePath($"{AppDomain.CurrentDomain.BaseDirectory}")
            //    .AddJsonFile("appsettings.json", false)
            //    .Build();

            //var serviceCollection = new ServiceCollection();
            //serviceCollection.AddAppServices(config);

            using (var dbContext = new CrmDbContext(optionsBuilder.Options))
            {
                var customers = new List<Customer>();
                var customer = new Customer()
                {
                    Name = "Pavloss",
                    Surname = "Pavlouu",
                    VatNumber = "888888888",
                    Category = CustomerCategory.FusikoProswpo

                };
                var customer2 = new Customer()
                {
                    Name = "Pavloss",
                    Surname = "Pavlopouloss",
                    VatNumber = "777777777",
                    Category = CustomerCategory.FusikoProswpo

                };

                //var account = new Account()
                //{
                //    AccountId = "2252525252"

                //};

                //customer.Accounts.Add(account);

                //var account2 = new Account()
                //{
                //    AccountId = "2626262626"

                //};

                //customer2.Accounts.Add(account2);

                //var transaction = new Transaction()
                //{
                //    TrnAmount = 200,
                //    Category = TrnCategory.Xrewsh

                //};

                //account.AddTrn(transaction);

                //var trn2 = new Transaction()
                //{
                //    TrnAmount = 1500,
                //    Category = TrnCategory.Pistwsh
                //};
                //account.AddTrn(trn2);

                //var trn3 = new Transaction()
                //{
                //    TrnAmount = 1000,
                //    Category = TrnCategory.Pistwsh
                //};
                //account2.AddTrn(trn3);

                customers.Add(customer);
                customers.Add(customer2);

                //var results = customers.Where(c => c.Name == "Petros");

                //dbContext.Add(customer);
                //dbContext.Add(customer2);
                //dbContext.SaveChanges();

                var results = dbContext.Set<Customer>()
                    .Where(c => c.Name == "Pavloss")
                    .ToList();


            }
        }
    }
}
