﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Application.Models.Dtos.ProductImages
{
    public class ProductImagesDto
    {

        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Path { get; set; }
        public int Order { get; set; } = 0;
        public bool? IsThumbnail { get; set; }
    }
}
