using BlApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation;

internal class Order : IOrder
{
    DalApi.IDal dal = DalApi.Factory.Get();
    public IEnumerable<BO.OrderForList> GetOrderForListM() //1
    {
        IEnumerable<DO.Order?> orders = dal.Order.GetAll();//all the product from do
        IEnumerable<DO.OrderItem?> items = dal.OrderItem.GetAll();//craete new

        return from DO.Order? item in orders
               let x = items.Where(items => items.Value.OrderID == item.Value.ID)
               select new BO.OrderForList()
               {
                   ID = item.Value.ID,
                   CustomerName = item.Value.CustomerName,
                   Status = orderStatus(item.Value),
                   //AmountOfItems = x.Count(),
                   //TotalPrice = x.Sum(items => items.Value.Amount * items.Value.Price)
                   //TotalPrice=dal.
                   AmountOfItems = dal.OrderItem.GetAll(x => x?.OrderID == item?.ID).Sum(x => x?.Amount) ?? 0,
                   TotalPrice = dal.OrderItem.GetAll(x => (x?.OrderID == item?.ID)).Sum(x => x?.Amount * x?.Price) ?? 0,
               };

    }
    private BO.Enums.OrderStatus orderStatus(DO.Order order) //a func for help
    {
        BO.Enums.OrderStatus status;
        if (order.DeliveryDate != null)
        {
            status = BO.Enums.OrderStatus.Delivered;
        }
        else
        {
            if (order.ShipDate != null)
            {
                status = BO.Enums.OrderStatus.Shipped;
            }
            else
                status = BO.Enums.OrderStatus.Ordered;
        }
        return status;

    }

    public BO.Order GetByOrderIdM(int orderId) //2
    {
        DO.Order order = new DO.Order();

        try
        {

            if (orderId < 0)
                throw new BO.BlNagtiveException("ID can not be nagtive");
        
            order = dal.Order.GetById(orderId);
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
        catch (DO.DlNoFindException e) { throw new BO.BlNoFindException("There is no product with that id", e); }

        


    }
    private IEnumerable<BO.OrderItem?> ListOrderItens(IEnumerable<DO.OrderItem?> list) //func for help
    {
        return from DO.OrderItem item in list
               select new BO.OrderItem()
               {
                   OrderItemID = item.OrderItemID,
                   Name = dal.Product.GetById(item.ProductID).Name,
                   Price = item.Price,
                   Amount = item.Amount,
                   TotalPrice = item.Price * item.Amount,
                   ProductID = dal.Product.GetById(item.ProductID).ID
               };
    }

    public BO.Order UpdateDeliveryDateM(int orderId) //3
    {
        DO.Order order = new DO.Order();
        try
        {
            order = dal.Order.GetById(orderId);
        }
        catch (DO.DlNoFindException ex)
        {
            throw new BO.BlNoFindException("There is no product with that id", ex);
        }
        try
        {
            if (order.ShipDate != null) ;
        }
        catch (DO.DlNoFindException ex)
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

    public BO.Order UpdateShipDateM(int orderId) //4
    {
        DO.Order order = new DO.Order();
        try
        {
            order = dal.Order.GetById(orderId);
        }
        catch (DO.DlNoFindException ex)
        {
            throw new BO.BlNoFindException("There is no product with that id", ex);
        }
        try
        {
            if (order.DeliveryDate != null) ;
        }
        catch (DO.DlNoFindException ex)
        {
            throw new BO.BlNotGoodValueException("The order already shiped", ex);
        }
        order.DeliveryDate = DateTime.Now;
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

    public BO.OrderTracking FollowOrderM(int orderId) //5
    {
        DO.Order order = new DO.Order();
        try
        {
            order = dal.Order.GetById(orderId);
        }
        catch (DO.DlNoFindException ex)
        {
            throw new BO.BlNoFindException("There is no product with that id", ex);
        }
        BO.OrderTracking ot = new BO.OrderTracking()
        {
            ID = order.ID,
            Status = orderStatus(order),
            Tracking = new List<Tuple<DateTime?, string>>()
            { new Tuple<DateTime?, string>( order.OrderDate, "order date "),
                    new Tuple<DateTime?, string>( order.ShipDate, "ship date "),
                    new Tuple<DateTime?, string>( order.DeliveryDate, "delivery date ")}
        };
        return ot;
    }
}

