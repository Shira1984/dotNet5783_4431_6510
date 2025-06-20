﻿using DalApi;
using DO;
using System.Collections.Generic;

namespace Dal;

internal class DalOrderItem : IOrderItem
{
    //craete
    public int Add(OrderItem oi)
    {
        oi.OrderItemID = DataSource.Config.NextOrderNumber;
        bool a = DataSource.OrderItemsList.Any(ori => ori?.OrderItemID == oi.OrderItemID);
        while (a == true)
        {
            oi.OrderItemID = DataSource.Config.NextOrderNumber;
             a = DataSource.OrderItemsList.Any(ori => ori?.OrderItemID == oi.OrderItemID);
        }
       
        
            DataSource.OrderItemsList.Add(oi);
            return oi.OrderItemID;
        
    }

    //request
    public OrderItem GetById(int id)
    {
        OrderItem? oi = DataSource.OrderItemsList.Find(ori => ori?.OrderItemID == id);
        if (oi == null)
            throw new Exception("Order not exist");
        else
            return (OrderItem)oi;
    }

    //update
    public void Update(OrderItem oi)
    {
        bool a = DataSource.OrderItemsList.Exists(ori => ori?.OrderItemID == oi.OrderItemID);
        if (a == true)
        {
            OrderItem oldOi = (OrderItem)DataSource.OrderItemsList.Find(ori => ori?.OrderItemID == oi.OrderItemID);
            oldOi.OrderItemID = oi.OrderItemID;
            oldOi.OrderID = oi.OrderID;
            oldOi.ProductID = oi.ProductID;
            oldOi.Price = oi.Price;
            oldOi.Amount = oi.Amount;
        }
        else
            throw new Exception("No Product to update");
    }

    //delete
    public void Delete(int id)
    {
        OrderItem? a = DataSource.OrderItemsList.Find(pro => pro?.OrderItemID == id);
        DataSource.OrderItemsList.Remove(a);

        //OrderItem? a = DataSource.OrderItemsList.Find(or => or.Value.OrderItemID == id);
        //DataSource.OrderItemsList.Remove(a);
    }

    //get list
    //public IEnumerable<OrderItem?> GetAll()
    //{
    //    List<OrderItem?> list = new List<OrderItem?>();
    //    foreach (var item in DataSource.OrderItemsList)
    //        list.Add(item);
    //    return list;
    //}
    public IEnumerable<OrderItem?> GetAll(Func<OrderItem?, bool>? filter = null)
    {
        if (filter != null)
            return DataSource.OrderItemsList.Where(item => filter(item));
        return DataSource.OrderItemsList.Select(item => item);
    }

        //get the order's items
        public IEnumerable<OrderItem?> ItemsInOrder(int id)
    {
        List<OrderItem?> products0 = DataSource.OrderItemsList.FindAll(it => it?.OrderID == id);
        List<OrderItem?> products1 = products0;
        return products1;
    }

    //request by order ID and product ID
    public OrderItem? GetByOrNumNProNum(int orNum, int proNum)
    {
        bool a = DataSource.OrderItemsList.Exists(p => p?.OrderID == orNum && p?.ProductID == proNum);
        if (a)
        {
            OrderItem? p = DataSource.OrderItemsList.Find(p => p?.OrderID == orNum && p?.ProductID == proNum);
            return p;
        }
        else
            throw new Exception("Not found");
    }
}
