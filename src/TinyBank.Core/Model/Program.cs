using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TinyBank.Core.Model
{
    class Program
    {
        static void Main(string[] args)

        {
            using var dbContext = new CrmDbContext();


            var customer = new Customer()
            {
                Name = "giannis",
                Surname = "giannopoulos",
                VatNumber = "444444444",

            };

            //var account = new Account()
            //   {
            //        AccountId = "0011223344",
            //        TotalAmount = 100

            //    };
            //customer.Accounts.Add(account);



            dbContext.Add(customer);
            dbContext.SaveChanges();


        }
    }
    }
