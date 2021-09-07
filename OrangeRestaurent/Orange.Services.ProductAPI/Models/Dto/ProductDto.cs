﻿    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orange.Services.ProductAPI.Models.Dto
{
    public class ProductDto
    {

        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Price { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }
    }
}