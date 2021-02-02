using System;
using System.Collections.Generic;
using System.Text;

namespace TinyBank.Core.Model
{
    public class Account
    {
        public string AccountId { get; set; }
        //public string AccNumber { get; set; }
        public decimal TotalAmount { get; private set; }
        public DateTimeOffset Created { get; set; }
        public int CustomerId { get; set; }
        public List<Transaction> Transactions { get; set; }

        public Account()
        {
            Created = DateTimeOffset.Now;
            Transactions = new List<Transaction>();
        }

        public void AddTrn(Transaction trn)
        {
            Transactions.Add(trn);
            if (TrnCategory.Pistwsh.Equals(trn.Category)) { TotalAmount += trn.TrnAmount; }
             else { TotalAmount -= trn.TrnAmount; }
         //   TotalAmount -= trn.TrnAmount;

        }
    }
    }

