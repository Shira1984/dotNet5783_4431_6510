using BlApi;
using BO;
using DalApi;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation;

internal class Cart : ICart
{
    DalApi.IDal dal = new Dal.DalList();

    public BO.Cart AddProductToCart(BO.Cart cart, int IdProduct)
    {

        List<OrderItem?> list =(List<OrderItem?>) cart.Items;
        DO.Product P = dal.Product.GetById(IdProduct);
        try
        {
            P = dal.Product.GetById(IdProduct);
        }
        catch (DO.DlNoFindException e)
        {
            throw new BO.BlNoFindException("There is no product with that id",e);
        }
        if(!list.Exists(x=>x.ProductID== IdProduct))
        {
            if (P.InStock > 0)
            {
                BO.OrderItem oi = new BO.OrderItem();
                {
                    oi.ProductID = IdProduct;
                    oi.Name = P.Name;
                    oi.Amount = 1;
                    oi.OrderItemID = 000000;
                    oi.Price = P.Price;
                    oi.TotalPrice = P.Price;

                };
                list.Add(oi);
                cart.TotalPrice += P.Price;
            }       
        }
        else if(P.InStock > 0)
        {
            int i = list.FindIndex(x => x.ProductID == IdProduct);
            list[i].Amount += 1;
            list[i].TotalPrice += list[i].Price;
            cart.TotalPrice += list[i].Price;
        }
        return cart;
    }
    public BO.Cart UpdateProductInCartCV(BO.Cart cart, int IdProduct, int n)
    {
        List<OrderItem?> list = (List<OrderItem?>)cart.Items;
        DO.Product p = new DO.Product();
        try
        {
            p = dal.Product.GetById(IdProduct);
        }
        catch (DO.DlNoFindException e)
        {
            throw new BO.BlNoFindException("There is no product with that id", e);
        }
        
        int i = list.FindIndex(x => x.ProductID == IdProduct);
        int j = p.InStock;
        BO.OrderItem oi= cart.Items.FirstOrDefault(x => x.ProductID == IdProduct);
        if (list[i].Amount<=n)
        {
            int r = list[i].Amount - n;
             
                if(p.InStock >=r )
                {

                   oi.Amount += r;
                       
                   oi.TotalPrice += r*p.Price;
                   p.InStock--;
                  
                   cart.TotalPrice += r*p.Price;
                    
                }
                else
                    throw  new BO.BlNotGoodValueException("we can't add this amount becouse ther is not enaf in the stok");
            
              
        }
        
        if (list[i].Amount > n)
        {
            int r = n - list[i].Amount;
            oi.Amount -= r;
            oi.TotalPrice -= r* p.Price;
            cart.TotalPrice -= r * p.Price;
            
        }
        else if (n == 0)
        {

            oi.TotalPrice -= oi.Amount * p.Price;
            cart.TotalPrice -= oi.Amount * p.Price;
            list[i]= null;
            list.RemoveAt(i);
        }
        
        return cart;
    }
    public void OrderCart(BO.Cart cart, string? name, string? email, string? address)
    {
        if (name == null || new EmailAddressAttribute().IsValid(email) || address == null)
            throw new BO.BlNoFindException("the values not exist in the system");
        DO.Order order = new DO.Order() {CustomerName= name, CustomerEmail= email, CustomerAdress=address,
        OrderDate=DateTime.Now, DeliveryDate=null, ShipDate=null};
        int oId= dal.Order.Add(order);
        DO.Product p = new DO.Product();
        foreach (BO.OrderItem oi in cart.Items)
        {
            //new DO.OrderItem() { OrderID = oId, ProductID = oi.ProductID, Amount = oi.Amount, Price = oi.Price });
            if (p.InStock == 0)
                throw new BO.BlNotGoodValueException("The product in the cart are not in stock");
            dal.OrderItem.Add(new DO.OrderItem() { OrderID = oId, ProductID = oi.ProductID, Amount = oi.Amount, Price = oi.Price });
            p = dal.Product.GetById(oi.ProductID);
            p.InStock -= oi.Amount;
            dal.Product.Update(p);

        }

    }
   
}




