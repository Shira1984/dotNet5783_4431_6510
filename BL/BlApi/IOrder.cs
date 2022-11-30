using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi;

public interface IOrder
{
    IEnumerable<OrderForList?> GetOrderForList();
    Order GetByOrderIdM(int orderId);
    Order UpdateDeliveryDateM(int orderId);
    Order UpdateShipDateM(int orderId);
    OrderTracking FollowOrderM(int orderId);
}
