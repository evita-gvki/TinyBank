using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyBank.Core.Model;

namespace TinyBank.Core.Services.Options
{
    public class CreateTransactionOptions
    {
        public string AccountId { get; set; }
        public decimal TrnAmount { get; set; }
        public TrnCategory Category { get; set; }
        public int CustomerId { get; set; }
    }
}