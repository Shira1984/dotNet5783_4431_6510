
using DO;
using System.Diagnostics.Contracts;

namespace Dal;

public class DalOrder
{
    public int Add(Order order)
    {
        bool a = DataSource.OrdersList.Any(or => or.Value.ID == order.ID);
        if (a == true)
        {
            throw new Exception("ID not exist");
        }
        else
        {
            DataSource.OrdersList.Add(order);
            return order.ID;
        }
    }
    
    public Order GetById(int id)
    {
        Order? o = DataSource.OrdersList.Find(or => or.Value.ID == id);
        if (o == null)
            throw new Exception("Order not exist");
        else
            return (Order)o;
    }

    public void Update(Order order)
    {
        bool a = DataSource.OrdersList.Exists(or => or.Value.ID == order.ID);
        if (a == true)
        {
            Order oldO = (Order)DataSource.OrdersList.Find(pro => pro.Value.ID == p.ID);
            oldO.ID = order.ID;
            oldO.OrderDate = order.OrderDate;
            oldO.ShipDate = order.ShipDate;
            oldO.CustomerAdress = order.CustomerAdress;
            oldO.CustomerEmail = order.CustomerEmail;
            oldO.CustomerName = order.CustomerName;
            oldO.DeliveryDate = order.DeliveryDate;
        }
        else
            throw new Exception("No Product to update");
    }


    public void Delete(int id)
    {
        Order? a = DataSource.OrdersList.Find(or => or.Value.ID == id);
        DataSource.OrdersList.Remove(a);
    }

    public Enumerable<Order?> GetAll()
    {
        List<Order?> list = new List<Order?>();
        foreach (var item in DataSource.OrdersList)
            list.Add(item);
        return list;
    }

}
