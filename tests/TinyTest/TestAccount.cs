//using System;
//using System.Linq;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;
//using TinyBank.Core.Model;
//using TinyBank.Core.Data;
//using Microsoft.Extensions.Configuration;
//using System.Text;
//using System.Threading.Tasks;
//using TinyBank.Core.Config.Extensions;
//using TinyBank.Core.Services;
//using TinyBank.Core.Services.Options;

//namespace TinyTest
//{
//    public class TestAccount
//    {
//        public static void Main(string[] args)
//        {
//            var configuration = new ConfigurationBuilder()
//            .SetBasePath($"{AppDomain.CurrentDomain.BaseDirectory}")
//            .AddJsonFile("appsettings.json", false)
//            .Build();

//            var config = configuration.ReadAppConfiguration();

//            var optionsBuilder = new DbContextOptionsBuilder();
//            optionsBuilder.UseSqlServer(
//                config.CrmConnectionString,
//                options =>
//                {
//                    options.MigrationsAssembly("TinyBank.Migrations");
//                });

//            using (var dbContext = new CrmDbContext(optionsBuilder.Options))
//            {
//                ////1.test create account
//                //////////////////////////
//                //var opt = new CreateAccountOptions()
//                //{
//                //    AccountId = "3333333333",
//                //    CustomerId = 2
//                //};

//                //var acc = new AccountService(dbContext).CreateAccountAsync(opt).Result.Data;

//                //if (acc == null) { Console.WriteLine("Account not created!"); }
//                //else { Console.WriteLine("Account created is:" + acc.AccountId + " For customer id " + acc.CustomerId); }

//                ////2.test find account
//                //////////////////////////
//                //var acc = new AccountService(dbContext).FindAccount("2233445566").Result.Data;
//                //if (acc == null) { Console.WriteLine("Account not found!"); }
//                //else { Console.WriteLine("Account found is:" + acc.AccountId + " For customer id " + acc.CustomerId + 
//                //    " and Total Amount: " + acc.TotalAmount); }

//                //3.test find all customer accounts
//                var acc = new AccountService(dbContext).FindAllCustomerAccountsAsync(2);
//                foreach (var i in acc ) 
//                { 
//                    Console.WriteLine ($"acount: {i.AccountId}");
//                }
//            }
//        }
//    }
//}

