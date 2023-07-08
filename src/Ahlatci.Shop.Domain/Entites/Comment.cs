﻿using Ahlatci.Shop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Domain.Entites
{
    public class Comment : AuditableEntity
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public string Detail { get; set; }
        public int LikeCount{ get; set; }
        public int DislikeCount { get; set; }
        public bool IsApproved { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }

    }
}
