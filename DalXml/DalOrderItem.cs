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
            List<DO.OrderItem?> listprods = XMLTools.LoadListFromXMLSerializer<DO.OrderItem>(s_orderItems);
            
            item.OrderItemID =(int) Config.GetNextOrderItemIDfromXMLconfig();
            bool a = listprods.Any(ori => ori?.OrderItemID == item.OrderItemID);
            while (a == true)
            {
                item.OrderItemID = (int)Config.GetNextOrderItemIDfromXMLconfig();
                a = listprods.Any(ori => ori?.OrderItemID == item.OrderItemID);
            }


            listprods.Add(item);
            Config.SaveNextOrderItemID(item.OrderItemID + 1);
            XMLTools.SaveListToXMLSerializer(listprods, s_orderItems);
            return item.OrderItemID;


        }

        public void Delete(int id)
        {
            List<DO.OrderItem?> listprods = XMLTools.LoadListFromXMLSerializer<DO.OrderItem>(s_orderItems);
            OrderItem? a = listprods.Find(pro => pro?.OrderItemID == id);
            listprods.Remove(a);
        }

        public IEnumerable<OrderItem?> GetAll(Func<OrderItem?, bool>? filter = null)
        {
            List<DO.OrderItem?> listprods = XMLTools.LoadListFromXMLSerializer<DO.OrderItem>(s_orderItems);
            if (filter != null)
                return listprods.Where(item => filter(item));
            return listprods.Select(item => item);
        }

        public OrderItem GetById(int id)
        {
            List<DO.OrderItem?> listprods = XMLTools.LoadListFromXMLSerializer<DO.OrderItem>(s_orderItems);
            OrderItem? oi = listprods.Find(ori => ori?.OrderItemID == id);
            if (oi == null)
                throw new Exception("Order not exist");
            else
                return (OrderItem)oi;
        }

        public OrderItem? GetByOrNumNProNum(int x, int y)
        {
            List<DO.OrderItem?> listprods = XMLTools.LoadListFromXMLSerializer<DO.OrderItem>(s_orderItems);
            bool a = listprods.Exists(p => p?.OrderID == x && p?.ProductID == y);
            if (a)
            {
                OrderItem? p = listprods.Find(p => p?.OrderID == x && p?.ProductID == y);
                return p;
            }
            else
                throw new Exception("Not found");
        }

        public IEnumerable<OrderItem?> ItemsInOrder(int id)
        {
            List<DO.OrderItem?> listprods = XMLTools.LoadListFromXMLSerializer<DO.OrderItem>(s_orderItems);
            List<OrderItem?> products0 = listprods.FindAll(it => it?.OrderID == id);
            List<OrderItem?> products1 = products0;
            return products1;
        }

        public void Update(OrderItem item)
        {
            List<DO.OrderItem?> listprods = XMLTools.LoadListFromXMLSerializer<DO.OrderItem>(s_orderItems);
            bool a = listprods.Exists(ori => ori?.OrderItemID == item.OrderItemID);
            if (a == true)
            {
                OrderItem oldOi = (OrderItem)listprods.Find(ori => ori?.OrderItemID == item.OrderItemID);
                oldOi.OrderItemID = item.OrderItemID;
                oldOi.OrderID = item.OrderID;
                oldOi.ProductID = item.ProductID;
                oldOi.Price = item.Price;
                oldOi.Amount = item.Amount;
                XMLTools.SaveListToXMLSerializer(listprods, s_orderItems);
            }
            else
                throw new Exception("No Product to update");
        }
    }
}
