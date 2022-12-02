using BlApi;
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
        DO.Product doProduct = new DO.Product();
        try
        {
            doProduct = dal.Product.GetById(id);
        }
        catch (DO.DlNoFindException ex)
        {
            throw new BO.BlNoFindException("There is no product with that id", ex);
        }
        return new BO.Product()
        {
            Id = doProduct.ID,
            Category = (BO.Enums.Category)doProduct.Category,
            Price = doProduct.Price,
            Name = doProduct.Name,
            InStock = doProduct.InStock
        };
    }

    public BO.ProductItem GetProductC(int id, BO.Cart c)
    {
        DO.Product doProduct = dal.Product.GetById(id);
        return new BO.ProductItem()
        {
            Id = doProduct.ID,
            Category = (BO.Enums.Category)doProduct.Category,
            Price = doProduct.Price,
            Name = doProduct.Name,
            InStock = doProduct.InStock,
            //Amount = 
        };
        throw new NotImplementedException();
    }

    public void AddProductM(BO.Product p)
    {
    if (p.Id < 100000 ||
        p.Id > 999999 ||
        p.Name.Length == 0 ||
        p.InStock < 0)
        throw new BO.BlNotGoodValueException();
       

        dal.Product.Add(new DO.Product()
        {
            ID = p.Id,
            Name = p.Name,
            InStock = p.InStock,
            Category = (DO.Enums.Category)p.Category,
            Price = p.Price
        });

    }

    public void DeleteProductM(int id)
    {
        DO.OrderItem? orderItems = dal.OrderItem.GetAll().FirstOrDefault(item => item.Value.OrderItemID == id);
        if (orderItems != null)
            throw new Exception();
        dal.Product.Delete(id);
    }

    public void UpdateProductM(BO.Product p)
    {
        if (p.Id < 100000 ||
            p.Id > 999999 ||
            p.Name.Length == 0 ||
            p.Price < 0 ||
            p.InStock < 1)
            throw new BO.BlNotGoodValueException("The values in product are rong");

        dal.Product.Update(new DO.Product()
        {
            ID = p.Id,
            Name = p.Name,
            InStock = p.InStock,
            Category = (DO.Enums.Category)p.Category,
            Price = p.Price
        });
        //throw new BO.BlNagtiveException("The ");
    }
}
