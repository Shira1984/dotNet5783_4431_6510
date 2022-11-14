
using DO;
using System.Collections.Generic;
namespace Dal;

public class DalProduct
{
    public int Add(Product p)
    {
        bool a = DataSource.ProductsList.Any(pro => pro.Value.ID == p.ID);
        if (a == true)
        {
            throw new Exception("ID not exist");
        }
        else
        {
            DataSource.ProductsList.Add(p);
            return p.ID;
        }
    }

    public Product GetById(int id)
    {
        //bool a = DataSource.ProductsList.Exists(pro => pro.Value.ID == id);
        //if (a == true)
        
        Product? p = DataSource.ProductsList.Find(pro => pro.Value.ID == id);
        //if (p == null)
        //    throw new Exception("Product not exist");
        //else
        return (Product)p;

        //else
        //    throw new Exception("Product not exist");
    }

    public void Update(Product p)
    {
        bool a = DataSource.ProductsList.Exists(pro => pro.Value.ID == p.ID);
        if (a == true)
        {
            Product oldP = (Product)DataSource.ProductsList.Find(pro => pro.Value.ID == p.ID);
            oldP.ID = p.ID;
            oldP.Name = p.Name;
            oldP.InStock = p.InStock;
            oldP.Price = p.Price;
            oldP.Category = p.Category;
        }
        else
            throw new Exception("No Product to update");
    }
    public void Delete(int id)
    {
        Product? a = DataSource.ProductsList.Find(pro => pro.Value.ID == id);
        DataSource.ProductsList.Remove(a);
    }

    //public Enumerable<Product?> GetAll()
    //{
    //    return DataSource.ProductsList;
    //}
}
