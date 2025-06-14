﻿using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi
{
    public interface IOrderItem : ICrud<OrderItem>
    {
        IEnumerable<OrderItem?> ItemsInOrder(int id);
        OrderItem? GetByOrNumNProNum(int x, int y);
    }
}
