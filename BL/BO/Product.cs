﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BO.Enums;

namespace BO
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
        public int InStock { get; set; }
        public string? ImageRelativeName { get; set; }
        public override string ToString() => this.ToStringProperty();
        //public override string ToString()
        //{
        //    return this.ToStringProperty();
        //}
    }
}
