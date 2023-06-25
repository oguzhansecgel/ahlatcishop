﻿using Ahlatci.Shop.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Domain.Entites
{
    //Conventional mapping biz fluent mapping kullanıyoruz

    public class Product : AuditableEntity
    {
        
        public int CatId { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public int UnitInStock { get; set; }
        public Decimal UnitPrice{ get; set; }


        //navigation property
        public Catergory Catergory { get; set; }


        
    
    }
}