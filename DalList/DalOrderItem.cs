
using DO;
using System.Collections.Generic;

namespace Dal;

public class DalOrderItem
{
    public int Add(OrderItem oi)
    {
        bool a = DataSource.OrderItemsList.Any(ori => ori.Value.OrderItemID == oi.OrderItemID);
        if (a == true)
        {
            throw new Exception("ID not exist");
        }
        else
        {
            DataSource.OrderItemsList.Add(oi);
            return oi.OrderItemID;
        }
    }

    public OrderItem GetById(int id)
    {
        OrderItem? oi = DataSource.OrderItemsList.Find(ori => ori.Value.OrderItemID == id);
        if (oi == null)
            throw new Exception("Order not exist");
        else
            return (OrderItem)oi;
    }

    public void Update(OrderItem oi)
    {

    }

    public void Delete(int id)
    {
        OrderItem? a = DataSource.OrderItemsList.Find(pro => pro.Value.OrderItemID == id);
        DataSource.OrderItemsList.Remove(a);

        //OrderItem? a = DataSource.OrderItemsList.Find(or => or.Value.OrderItemID == id);
        //DataSource.OrderItemsList.Remove(a);
    }
    
    public Enumerable<OrderItem?> GetAll()
    {
        
    }

    public List ItemsInOrder(int id)
    {
        List<Product> products = DataSource.OrderItemsList.FindAll(it => it.Value.OrderID == id);
    }

    public Product GetByOrNumNProNum(int orNum, int proNum)
    {

    }
}
