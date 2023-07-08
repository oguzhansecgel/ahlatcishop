﻿using Ahlatci.Shop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Domain.Entites
{
    public class Account : BaseEntity
    {
        public int CustomerId { get; set; } 
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public  string LastUserIp { get; set; }
        
        public Customer Customer { get; set; }
    }
}
