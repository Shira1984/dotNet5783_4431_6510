using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BO.Enums;

namespace BO
{
    public class OrderForList
    {
        public int ID { get; set; }
        public string? CustomerName { get; set; }
        public OrderStatus Status { get; set; }
        public double TotalPrice { get; set; }
        public int AmountOfItems { get; set; }
        public override string ToString() => this.ToStringProperty();
    }
}
