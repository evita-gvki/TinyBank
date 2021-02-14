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
//    public class TestCustomer
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
//                //test register
//                var opt = new RegisterCustomerOptions()
//                {
//                    Name = "Evita",
//                    Surname = "Gvki",
//                    VatNumber = "444455555",
//                    Category = CustomerCategory.NomikoProswpo,
//                    PaymentMethod = PaymentMethods.Card
//                };

//                var cust = new CustomerService(dbContext).RegisterAsync(opt).Result.Data;

//                //test find
//                //var opt = new FindCustomerOptions()
//                //{
//                //    Name = "Evita",
//                //    Surname = "Gkogiannaki",
//                //    VatNumber = "456456456",

//                //};

//                //var cut = new CustomerService(dbContext).FindCustomerAsync(opt).Result.Data;

//                //if (cut == null) { Console.WriteLine("Customer not found!"); }
//                //else { Console.WriteLine("Customer found is:" + cut.Name + "-" + cut.Surname); }

//            }
//        }
//    }
//}

