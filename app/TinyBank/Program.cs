using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TinyBank.Core;


namespace TinyBank
    {
        class Program
        {
            static void Main(string[] args)

            {
                using var dbContext = new Core.CrmDbContext();


            var customer = new Customer()
            {
                Name = "Giorgos",
                Surname = "papas",
                VatNumber = "222222222",
                Category = CustomerCategory.FusikoProswpo

            };

            var account = new Account()
                {
                    AccountId = "1616161616"
                   
                };

               customer.Accounts.Add(account);

            var account2 = new Account()
            {
                AccountId = "1717171717"

            };

            customer.Accounts.Add(account2);

            var transaction = new Transaction()
            {
                TrnAmount = 200,
                Category = TrnCategory.Xrewsh

            };

            account.AddTrn(transaction);
                        
            var trn2 = new Transaction()
            {
                TrnAmount = 1500,
                Category = TrnCategory.Pistwsh
            };
            account.AddTrn(trn2);

            var trn3 = new Transaction()
            {
                TrnAmount = 1000,
                Category = TrnCategory.Pistwsh
            };
            account2.AddTrn(trn3);

            dbContext.Add(customer);
            dbContext.SaveChanges();


            }
        }
    }
