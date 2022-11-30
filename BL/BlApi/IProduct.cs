using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi;

public interface IProduct
{
    ProductItem GetProductC(int id, Cart c); // for client
    //IEnumerable<ProductItem?> GetProductC(); // for client
    IEnumerable<ProductForList?> GetListedProducts();
    Product GetProductM(int id); //for manager
    //IEnumerable<Product?> GetProductM(int id);
    void AddProductM(Product p);
    void DeleteProductM(int id);
    void UpdateProductM(Product p);
}
