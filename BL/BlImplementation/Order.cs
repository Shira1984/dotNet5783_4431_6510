using BlApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation;

internal class Order : IOrder
{
    DalApi.IDal dal = new Dal.DalList();

    public IEnumerable<BO.OrderForList> GetListedOrdersm()
    {
        IEnumerable<DO.Order?> orders = dal.Order.GetAll();
        IEnumerable<DO.OrderItem?> items = dal.OrderItem.GetAll();

        return from DO.Order item in orders
               let x = items.Where(items => items.Value.OrderItemID == item.ID)
               select new BO.OrderForList()
               {
                   ID = item.ID,
                   CustomerName = item.CustomerName,
                   Status = orderStatus(item),
                   AmountOfItems = x.Count(),
                   TotalPrice = x.Sum(items => items.Value.Amount * items.Value.Price)
               };

    }
    private BO.Enums.OrderStatus orderStatus(DO.Order order)
    {
        BO.Enums.OrderStatus status;
        if (order.DeliveryDate != null)
            status = BO.Enums.OrderStatus.Delivered;
        if(order.ShipDate!=null)
            status = BO.Enums.OrderStatus.Shipped;
        else
            status = BO.Enums.OrderStatus.Ordered;
        return status;

    }

    public BO.Order GetByOrderIdM(int orderId)
    {
        DO.Order order= new DO.Order();

        if (orderId < 0)
            throw new BO.BlNagtiveException("ID can not be nagtive");
        try
        {
            order = dal.Order.GetById(orderId);
        }
        catch (DO.DlNoFindException e) { throw new BO.BlNoFindException("There is no product with that id", e); }

        return new BO.Order()
        {
            ID = order.ID,
            CustomerName = order.CustomerName,
            CustomerAdress = order.CustomerAdress,
            CustomerEmail = order.CustomerAdress,
            Status= orderStatus(order),
            DeliveryDate = order.DeliveryDate,
            OrderDate = order.OrderDate,
            ShipDate = order.ShipDate,
            Items= ListOrderItens(dal.OrderItem.GetAll().Where(x=>x.Value.OrderItemID==order.ID)),
            TotalPrice= ListOrderItens(dal.OrderItem.GetAll().Where(x => x.Value.OrderItemID == order.ID)).Sum(x=>x.TotalPrice)

        };
        

    }
    private IEnumerable<BO.OrderItem?> ListOrderItens(IEnumerable<DO.OrderItem?> list)
    {
        return from DO.OrderItem item in list
               select new BO.OrderItem()
               {
                   OrderItemID = item.OrderItemID,
                   Name=dal.Product.GetById(item.ProductID).Name,
                   Price=item.Price,
                   Amount=item.Amount,
                   TotalPrice=item.Price*item.Amount,
                   ProductID= dal.Product.GetById(item.ProductID).ID
               };
    }

    public BO.Order UpdateDeliveryDateM (int orderId)
    {
        DO.Order order = new DO.Order();
        try
        {
            order = dal.Order.GetById(orderId);
        }
        catch(DO.DlNoFindException ex)
        {
            throw new BO.BlNoFindException("There is no product with that id", ex);
        }
        try
        {
            if (order.ShipDate != null) ;
        }
        catch (DO.DlNotGoodValueException ex)
        {
            throw new BO.BlNotGoodValueException("The order already shiped", ex);
        }
        order.ShipDate = DateTime.Now;
        dal.Order.Update(order);
        return new BO.Order()
        {
            ID = order.ID,
            CustomerName = order.CustomerName,
            CustomerAdress = order.CustomerAdress,
            CustomerEmail = order.CustomerAdress,
            Status = orderStatus(order),
            DeliveryDate = order.DeliveryDate,
            OrderDate = order.OrderDate,
            ShipDate = order.ShipDate,
            Items = ListOrderItens(dal.OrderItem.GetAll().Where(x => x.Value.OrderItemID == order.ID)),
            TotalPrice = ListOrderItens(dal.OrderItem.GetAll().Where(x => x.Value.OrderItemID == order.ID)).Sum(x => x.TotalPrice)

        };

    }

    public BO.Order UpdateShipDateM(int orderId)
    {

    }

    public BO.OrderTracking FollowOrderM(int orderId)
    {

    }
}
