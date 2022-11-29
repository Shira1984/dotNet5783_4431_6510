using DalApi;
using DO;
using System.Collections.Generic;
namespace Dal;

internal class DalProduct : IProduct
{
    //craete
    public int Add(Product p)
    {
        bool a = DataSource.ProductsList.Any(pro => pro?.ID == p.ID);
        if (a == true)
        {
            throw new Exception("ID already exist");
        }
        else
        {
            DataSource.ProductsList.Add(p);
            return p.ID;
        }
    }

    //request
    public Product GetById(int id)
    {
        

        Product p = DataSource.ProductsList.Find(pro => pro?.ID == id) ?? throw new Exception("Product not exist");
        //if (p == null)
        //    throw new Exception("Product not exist");
        
            return p;

        //else
        //    throw new Exception("Product not exist");
    }

    //update
    public void Update(Product p)
    {
        bool a = DataSource.ProductsList.Exists(pro => pro?.ID == p.ID);
        if (a == true)
        {
            Product oldP = (Product)DataSource.ProductsList.Find(pro => pro?.ID == p.ID);
            oldP.ID = p.ID;
            oldP.Name = p.Name;
            oldP.InStock = p.InStock;
            oldP.Price = p.Price;
            oldP.Category = p.Category;
        }
        else
            throw new Exception("No Product to update");
    }

    //delete
    public void Delete(int id)
    {
        Product? a = DataSource.ProductsList.Find(pro => pro?.ID == id);
        DataSource.ProductsList.Remove(a);
    }

    //get list
    public IEnumerable<Product?> GetAll()
    {
        List<Product?> list = new List<Product?>();
        foreach (var item in DataSource.ProductsList)
            list.Add(item);
        return list;
    }
}
