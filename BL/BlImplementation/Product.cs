using BlApi;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation;

internal class Product : IProduct
{
    DalApi.IDal dal = new Dal.DalList();

    public IEnumerable<BO.ProductForList> GetListedProducts()
    {
        return from DO.Product? doProduct in dal.Product.GetAll()
               select new BO.ProductForList
               {
                   Id = doProduct?.ID ?? throw new NullReferenceException("Missing Id"),
                   Name = doProduct?.Name ?? throw new NullReferenceException("Missing Name"),
                   Category = (BO.Enums.Category?)doProduct?.Category ?? throw new NullReferenceException("Missing Category"),
                   Price = doProduct?.Price ?? 0
               };
    }

    public BO.Product GetProductM(int id)
    {
        DO.Product doProduct = dal.Product.GetById(id);
        return new BO.Product()
        {
            Id = doProduct.ID,
            Category = (BO.Enums.Category)doProduct.Category,
            Price = doProduct.Price,
            Name = doProduct.Name,
            InStock = doProduct.InStock
        };
    }

    public BO.ProductItem GetProductC(int id, Cart c)
    {
        DO.Product doProduct = dal.Product.GetById(id);
        return new BO.ProductItem()
        {
            Id=doProduct.ID,
            Category= (BO.Enums.Category)doProduct.Category,
            Price= doProduct.Price,
            Name= doProduct.Name,
            InStock= doProduct.InStock
        };
    }

    public void AddProductM(Product p)
    {
        DO.Product doProduct = dal.Product.Add(p);

    }

    public void DeleteProductM(int id)
    {

    }

    public void UpdateProductM(Product p)
    {

    }
}
