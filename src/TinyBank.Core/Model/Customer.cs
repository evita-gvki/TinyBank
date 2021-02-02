using System;
using System.Collections.Generic;
using System.Text;

namespace TinyBank.Core.Model
{
    public class Customer
    {
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string VatNumber { get; set; }
    public CustomerCategory Category{ get; set; }

    public List<Account> Accounts { get; set; }

    public Customer()
    {
        Accounts= new List<Account>();
    }
}
}
