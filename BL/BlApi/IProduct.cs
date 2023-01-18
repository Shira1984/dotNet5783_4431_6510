using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi;

public interface IProduct
{
    IEnumerable<ProductForList?> GetListedProducts(Func<BO.ProductForList?, bool>? filter = null);
    IEnumerable<Product?> GetListedProductsM(Func<BO.Product?, bool>? filter = null);
    Product GetProductM(int id); //for manager
    //IEnumerable<Product?> GetProductM(int id);
    ProductItem GetProductC(int id, Cart c); // for client
    //IEnumerable<ProductItem?> GetProductC(); // for client
    void AddProductM(Product p);
    void DeleteProductM(int id);
    void UpdateProductM(Product p);
}
