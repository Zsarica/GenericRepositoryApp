﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DTO
{
    public class ProductCategoryDTO
    {
        public int ProductID { get; set; }
        public string  ProductName { get; set; }
        public int CategoryID { get; set; }
        public string  CategoryName { get; set; }
    }
}
