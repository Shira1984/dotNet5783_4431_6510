using DalApi;
using DO;
using System.Diagnostics.Contracts;

namespace Dal;

internal class DalOrder : IOrder
{
    //craete
    public int Add(Order order)
    {
        bool a = DataSource.OrdersList.Any(or => or?.ID == order.ID);
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
    
    //request
    public Order GetById(int id)
    {
        Order? o = DataSource.OrdersList.Find(or => or?.ID == id);
        if (o == null)
            throw new Exception("Order not exist");
        else
            return (Order)o;
    }

    //update
    public void Update(Order order)
    {
        bool a = DataSource.OrdersList.Exists(or => or?.ID == order.ID);
        if (a == true)
        {
            Order oldO = (Order)DataSource.OrdersList.Find(pro => pro?.ID == order.ID);
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

    //delete
    public void Delete(int id)
    {
        Order? a = DataSource.OrdersList.Find(or => or?.ID == id);
        DataSource.OrdersList.Remove(a);
    }

    //get list
    //public IEnumerable<Order?> GetAll()
    //{
    //    List<Order?> list = new List<Order?>();
    //    foreach (var item in DataSource.OrdersList)
    //        list.Add(item);
    //    return list;
    //}
    public IEnumerable<Order?> GetAll(Func<Order?, bool>? filter = null)
    {
        if (filter != null)
            return DataSource.OrdersList.Where(item => filter(item));
        return DataSource.OrdersList.Select(item => item);
    }
}
