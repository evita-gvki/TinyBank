﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyBank.Core.Services.Options
{
    public class CreateAccountOptions
    {
        public string AccountId { get; set; }
        public int CustomerId { get; set; }
    }
}
