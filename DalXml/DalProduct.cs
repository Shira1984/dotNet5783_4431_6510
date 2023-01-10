using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    internal class DalProduct : IProduct
    {
        string s_products = "products";
        public int Add(Product p)
        {
            List<DO.Product?> listprods = XMLTools.LoadListFromXMLSerializer<DO.Product>(s_products);
            bool a = listprods.Any(pro => pro?.ID == p.ID);
            if (a == true)
            {
                throw new Exception("ID already exist");
            }
            else
            {
                listprods.Add(p);
                XMLTools.SaveListToXMLSerializer(listprods, s_products);
                return p.ID;
            }
        }

        public void Delete(int id)
        {
            List<DO.Product?> listprods = XMLTools.LoadListFromXMLSerializer<DO.Product>(s_products);
            Product? a = listprods.Find(pro => pro?.ID == id);
            listprods.Remove(a);
        }

        public IEnumerable<Product?> GetAll(Func<Product?, bool>? filter = null)
        {
            List<DO.Product?> listprods = XMLTools.LoadListFromXMLSerializer<DO.Product>(s_products);

            if (filter != null)
                return listprods.Where(item => filter(item));
            return listprods.Select(item => item);
        }

        public Product GetById(int id)
        {
            List<DO.Product?> listprods = XMLTools.LoadListFromXMLSerializer<DO.Product>(s_products);
            Product p = listprods.Find(pro => pro?.ID == id) ?? throw new Exception("Product not exist");
            return p;


        }

        public void Update(Product p)
        {
            List<DO.Product?> listprods = XMLTools.LoadListFromXMLSerializer<DO.Product>(s_products);
            bool a = listprods.Exists(pro => pro?.ID == p.ID);
            if (a == true)
            {
                Product oldP = (Product)listprods.Find(pro => pro?.ID == p.ID);
                oldP.ID = p.ID;
                oldP.Name = p.Name;
                oldP.InStock = p.InStock;
                oldP.Price = p.Price;
                oldP.Category = p.Category;
            }
            else
                throw new Exception("No Product to update");
        }
    }
}
