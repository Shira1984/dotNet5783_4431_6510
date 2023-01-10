using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    internal class DalOrderItem : IOrderItem
    {
        string s_orderItems = "orderItems";

        public int Add(OrderItem item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderItem?> GetAll(Func<OrderItem?, bool>? filter = null)
        {
            throw new NotImplementedException();
        }

        public OrderItem GetById(int id)
        {
            throw new NotImplementedException();
        }

        public OrderItem? GetByOrNumNProNum(int x, int y)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderItem?> ItemsInOrder(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderItem item)
        {
            throw new NotImplementedException();
        }
    }
}
