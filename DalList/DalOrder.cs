using DalApi;
using DO;
using System.Diagnostics.Contracts;

namespace Dal;

internal class DalOrder : IOrder
{
    //craete
    public int Add(Order order)
    {
        order.ID = DataSource.Config.NextOrderNumber;
        bool a = DataSource.OrdersList.Any(or => or?.ID == order.ID);
        while (a == true)
        {
            order.ID = DataSource.Config.NextOrderNumber;
            a = DataSource.OrdersList.Any(or => or?.ID == order.ID);
        }
       
       DataSource.OrdersList.Add(order);
       return order.ID;
        
    }
    
    //request
    public Order GetById(int id)
    {
        
        try
        {
            Order? o = DataSource.OrdersList.Find(or => or?.ID == id);
            if (o == null)

                throw new Exception("Order not exist");
            else
                return (Order)o;
        }
        catch(Exception ex)
        {
            throw new DO.DlNoFindException("There is no order founded");
        }
    }

    //update
    public void Update(Order order)
    {
        bool a = DataSource.OrdersList.Exists(or => or?.ID == order.ID);
        if (a == true)
        {
            Order oldO = (Order)DataSource.OrdersList.Find(pro => pro?.ID == order.ID);
            DataSource.OrdersList.Remove(oldO);
            //oldO.ID = order.ID;
            //oldO.OrderDate = order.OrderDate;
            //oldO.ShipDate = order.ShipDate;
            //oldO.CustomerAdress = order.CustomerAdress;
            //oldO.CustomerEmail = order.CustomerEmail;
            //oldO.CustomerName = order.CustomerName;
            //oldO.DeliveryDate = order.DeliveryDate;
            DataSource.OrdersList.Add(order);

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
