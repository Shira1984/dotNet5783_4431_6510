using BlApi;
using DalApi;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation;

internal class Cart : ICart
{
    DalApi.IDal dal = new Dal.DalList();

    public BO.Cart AddProductToCart(BO.Cart cart, int IdProduct)
    {
        DO.Product P = dal.Product.GetById(IdProduct);
        try
        {
            P = dal.Product.GetById(IdProduct);
        }
        catch (BO.NoFindException e)
        {
            throw new BO.NoFindException(e.Message);
        }
        if(!cart.Items.Exists(x=>x.ProductID== IdProduct))
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
                cart.Items.Add(oi);
                cart.TotalPrice += P.Price;
            }       
        }
        else if(P.InStock > 0)
        {
            int i = cart.Items.FindIndex(x => x.ProductID == IdProduct);
            cart.Items[i].Amount += 1;
            cart.Items[i].TotalPrice += cart.Items[i].Price;
            cart.TotalPrice += cart.Items[i].Price;
        }
        return cart;
    }
    public BO.Cart UpdateProductInCartCV(BO.Cart cart, int IdProduct, int n)
    {
        DO.Product p = new DO.Product();
        try
        {
            p = dal.Product.GetById(IdProduct);
        }
        catch (BO.NoFindException e)
        {
            throw new BO.NoFindException(e.Message);
        }
        int i = cart.Items.FindIndex(x => x.ProductID == IdProduct);
        BO.OrderItem oi= cart.Items.FirstOrDefault(x => x.ProductID == IdProduct);
        if (cart.Items[i].Amount<n)
        {
            int r = cart.Items[i].Amount - n;
             
                if(p.InStock >=r )
                {

                   oi.Amount += r;
                       
                   oi.TotalPrice += r*p.Price;
                   p.InStock--;
                  
                   cart.TotalPrice += r*p.Price;
                    
                }
                else
                    throw  new BO.NotGoodValueException("we can't add this amount becouse ther is not enaf in the stok");
            
              
        }
        
        if (cart.Items[i].Amount > n)
        {
            int r = n - cart.Items[i].Amount;
            oi.Amount -= r;
            oi.TotalPrice -= r* p.Price;
            cart.TotalPrice -= r * p.Price;
            
        }
        else if (n == 0)
        {

            oi.TotalPrice -= oi.Amount * p.Price;
            cart.TotalPrice -= oi.Amount * p.Price;
            cart.Items[i]= null;
            cart.Items.RemoveAt(i);
        }
        
        return cart;
    }
    public void OrderCart(BO.Cart cart, string? name, string? email, string? address)
    {
        if (name == null || new EmailAddressAttribute().IsValid(email) || address == null)
            throw new BO.NoFindException("the values not exist in the system");
        DO.Order order = new DO.Order() {CustomerName= name, CustomerEmail= email, CustomerAdress=address,
        OrderDate=DateTime.Now, DeliveryDate=null, ShipDate=null};
        int oId= dal.Order.Add(order);
        DO.Product p = new DO.Product();
        foreach (BO.OrderItem oi in cart.Items)
        {
            //new DO.OrderItem() { OrderID = oId, ProductID = oi.ProductID, Amount = oi.Amount, Price = oi.Price });
            if (p.InStock == 0)
                throw new BO.NotGoodValueException("The product in the cart are not in stock");
            dal.OrderItem.Add(new DO.OrderItem() { OrderID = oId, ProductID = oi.ProductID, Amount = oi.Amount, Price = oi.Price });
            p = dal.Product.GetById(oi.ProductID);
            p.InStock -= oi.Amount;
            dal.Product.Update(p);

        }

    }
}




