using System;
using System.Collections.Generic;
using System.Text;

namespace TinyBank.Core.Model
{
    public class Transaction
    {
        public Guid TransactionId { get; set; }
        public string AccountId { get; set; }
        public decimal TrnAmount { get; set; }
        public TrnCategory Category{ get; set; }
        public DateTimeOffset Created { get; set; }
        
        public Transaction()
        {
            Created = DateTimeOffset.Now;
            TransactionId = Guid.NewGuid();
        }
    }
}
