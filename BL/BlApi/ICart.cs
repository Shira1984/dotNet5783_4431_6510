using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi;

public interface ICart
{
    Cart AddProductToCart(Cart cart, int IdProduct);
    Cart UpdateProductInCartCV(Cart cart, int IdProduct, int n);
    int OrderCart(Cart cart, string? name, string? email, string? address);
    
}
