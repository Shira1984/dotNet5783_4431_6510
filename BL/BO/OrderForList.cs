using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BO.Enums;
using static BO.Enums.OrderStatus;

namespace BO
{
    internal class OrderForList
    {
        public int ID { get; set; }
        public string? CustomerName { get; set; }
        public OrderStatus status { get; set; }
        public double TotalPrice { get; set; }
        public int AmountOfItems { get; set; }
    }
}
