using BlApi;
using BO;
using System;
using System.Collections.Generic;
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
        catch (NoFindException e)
        {
            throw new NoFindException(e.Message);
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
        int i = cart.Items.FindIndex(x => x.ProductID == IdProduct);
        if (cart.Items[i].Amount<n)
        {
            for (int j = 0; j < n- cart.Items[i].Amount; j++)
            {
                DO.Product P = dal.Product.GetById(IdProduct);
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
        }
        
        else if (cart.Items[i].Amount > n)
        {
            for (int j = 0; j < cart.Items[i].Amount-n; j++)
            {
                cart.Items[i].Amount -= 1;
                cart.Items[i].TotalPrice -= cart.Items[i].Price;
                cart.TotalPrice -= cart.Items[i].Price;
            }
        }
    }
}
