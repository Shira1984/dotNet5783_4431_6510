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

    public IEnumerable<BO.OrderForList> GetListedOrders()
    {

    }

    public BO.Order GetByOrderIdM(int orderId)
    {

    }

    public BO.Order UpdateDeliveryDateM (int orderId)
    {

    }

    public BO.Order UpdateShipDateM(int orderId)
    {

    }

    public BO.OrderTracking FollowOrderM(int orderId)
    {

    }
}
