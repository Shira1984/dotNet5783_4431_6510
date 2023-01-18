
using DO;

using System;
using System.Data;
//using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Numerics;
using System.Text;
using System.Xml.Linq;

namespace Dal;

internal sealed class DataSource
{
    //internal static DataSource DSInstance { get; } = new DataSource();
    static DataSource()
    {
        s_Initialize();
    }
    private static readonly Random s_rand = new();

    internal static class Config
    {
        internal const int s_startOrderNumber = 1000;
        private static int s_nextOrderNumber = s_startOrderNumber;
        internal static int NextOrderNumber { get => s_nextOrderNumber++; }
        internal const int s_startOrderItemNumber = 1000;
        private static int s_nextOrderItemNumber = s_startOrderNumber;
        internal static int NextOrderItemNumber { get => s_nextOrderNumber++; }
    }
    /// <summary>
    /// Repositories initialization
    /// </summary>
    internal static List<Product?> ProductsList { get; } = new List<Product?>();
    internal static List<Order?> OrdersList { get; } = new List<Order?>();
    internal static List<OrderItem?> OrderItemsList { get; } = new List<OrderItem?>();

    /// <summary>
    /// The initialization functions
    /// </summary>
    private static void s_Initialize()
    {
        //ProductsList = new List<Product?>();
        //ProductsList.Add(new Product());
        createAndInitProducts();
        createAndInitOrders();
        createAndInitOrderItems();


    //    XMLTools.SaveListToXMLSerializer(ProductsList ,"products");
    //    XMLTools.SaveListToXMLSerializer(OrdersList, "orders");
    //    XMLTools.SaveListToXMLSerializer(OrderItemsList, "orderItems");
    }

    /// <summary>
    /// Products initialization
    /// </summary>
    private static void createAndInitProducts()
    {
        string[] philosophyBooks = new string[]
        {
            "The myth of Sisyphus", "Waiting for Godot", "Existentialism is Humanism",
            "Thus said Zarathustra", "Euthyferon", "Protagoras", "Phaedon",
            "Gorgias", "The birth of tragedy", "The nausea"
        };

        int[] philosophyInStock = new int[]
        {
            8, 15, 16, 17, 18, 19, 20, 21, 0, 24
        };

        for (int i = 0; i < 10; i++)
        {
            Product p = new Product();
            p.ID = 100000 + i;
            p.Name = philosophyBooks[i];
            p.Category = Enums.Category.Philosophy;
            p.InStock = philosophyInStock[i];
            p.Price = 100+i;

            ProductsList.Add(p);
        }



        //string[] BiographyBooks = new string[]
        //{
        //    "The shepherd", "Sharon", "Bibi", "The adviser", "Hitler", "Karl Marx",
        //    "Churchill", "Golda", "Ben Gurion", "Beyond the physical"
        //};

        //int[] BiographyInStock = new int[]
        //{
        //    8, 15, 16, 17, 18, 19, 20, 21, 0, 24
        //};

        //for (int i = 0; i < 10; i++)
        //{
        //    Product p = new Product();
        //    p.ID = s_rand.Next(100000, 9999999);
        //    p.Name = BiographyBooks[i];
        //    p.Category = Enums.Category.Biography;
        //    p.InStock = BiographyInStock[i];
        //    p.Price = s_rand.Next(50, 110);

        //    ProductsList.Add(p);
        //}
        


        string[] HolocaustBooks = new string[]
        {
            "The Dollhouse", "Salamander", "The Cipher", "Kristallnacht", "The Sky Inside Me",
            "The Clock", "Anatomy of Evil", "Female Murderers in Hitler's Service",
            "Encyclopedia of the Holocaust", "The Eichmann Trial in Jerusalem"
        };

        int[] HolocaustInStock = new int[]
        {
            8, 15, 16, 17, 18, 19, 20, 21, 0, 24
        };

        for (int i = 0; i < 10; i++)
        {
            Product p = new Product();
            p.ID = 200000 + i;
            p.Name = HolocaustBooks[i];
            p.Category = Enums.Category.Holocaust;
            p.InStock = HolocaustInStock[i];
            p.Price = 100 + i;

            DataSource.ProductsList.Add(p);
        }



        string[] PsychoanalysisBooks = new string[]
        {
            "Psychopathology of everyday life", "Beyond the pleasure principle",
            "Civilization and Its Discontents", "The Ego and the Id", "Psychology of the Unconscious",
            "The Joke and Its Relation to the Unconscious", "Psychoanalysis of children",
            "Ecrits_of_Lakan", "The interpretation of dreams", "Inhibitions, Symptoms and Anxiety"
        };
        for (int i = 0; i < 10; i++)
        {
            Product p = new Product();
            p.ID = 300000 + i;
            p.Name = PsychoanalysisBooks[i];
            p.Category = Enums.Category.Psychoanalysis;
            p.InStock = s_rand.Next(4, 10);
            p.Price = 100 + i;

            DataSource.ProductsList.Add(p);
        }



        string[] RussianLiteratureBooks = new string[]
        {
            "The Brothers Karamazov", "demons", "crime and Punishment", "Kholstomer", "The Cossacks",
            "The death of Ivan Ilyich", "The teenager", "the idiot", "A writer's diary", "war and Peace"
        };
        for (int i = 0; i < 10; i++)
        {
            Product p = new Product();
            p.ID = 400000 + i;
            p.Name = RussianLiteratureBooks[i];
            p.Category = Enums.Category.RussianLiterature;
            p.InStock = s_rand.Next(4, 10);
            p.Price = 100 + i;

            ProductsList.Add(p);
        }
    }

    /// <summary>
    /// Orders initialization
    /// </summary>
    private static void createAndInitOrders()
    {
        string[] CustomersNames = new string[]
        {
            "Avi", "Shneor", "David", "Elishah", "Yehoshua", "Dov", "Moshe", "Yosef", "Nadav", "Nechumale",
            "Neomi", "Shalom", "Mendi", "Baruch", "Gavriel", "Leo", "Tuval", "Tomas", "Doron", "Etan", "Tomas"
        };

        string[] CustomerAdresses = new string[]
        {
            "Jerusalem", "Ramat Gan", "Ofakim", "Nahlaot", "Herzelia", "Tel Aviv",
            "London", "Mexico", "Jerusalem", "Jerusalem", "Ofakim", "Nahlaot", "Herzelia",
            "Tel Aviv", "Bnei Braq", "Bnei Braq", "Bnei Braq", "Bnei Braq", "Bnei Braq", "Bnei Braq" , "Herzelia"
        };
        DateTime mydate = DateTime.Today;
        for (int i = 0; i < 4; i++)
        {
            Order o = new Order();
            o.ID = Config.NextOrderNumber;
            o.CustomerName = CustomersNames[i];
            o.CustomerEmail = CustomersNames[i] + "walla.com";
            o.CustomerAdress = CustomerAdresses[i];
            o.OrderDate = new DateTime(mydate.Year, mydate.Month, mydate.Day).AddDays(-i);
            
            o.DeliveryDate = null; //Date of being sent
            o.ShipDate = null; //Date of arrivial

           OrdersList.Add(o);

        }

        for (int i = 4; i < 8; i++)
        {
            Order o = new Order();
            o.ID = Config.NextOrderNumber;
            o.CustomerName = CustomersNames[i];
            o.CustomerEmail = CustomersNames[i] + "walla.com";
            o.CustomerAdress = CustomerAdresses[i];
            o.OrderDate = new DateTime(mydate.Year, mydate.Month, mydate.Day).AddDays(-i);
            o.ShipDate = new DateTime(mydate.Year, mydate.Month, mydate.Day).AddDays(-i + s_rand.Next(4, 8));
            o.DeliveryDate = null; //Date of arrivial

           OrdersList.Add(o);
        }
      
            for (int i = 8; i < 20; i++)
            {
                Order o = new Order();
                o.ID = Config.NextOrderNumber;
                o.CustomerName = CustomersNames[i];
                o.CustomerEmail = CustomersNames[i] + "walla.com";
                o.CustomerAdress = CustomerAdresses[i];

                o.OrderDate = new DateTime(mydate.Year, mydate.Month, mydate.Day).AddDays(-i);
                o.ShipDate = new DateTime(mydate.Year, mydate.Month, mydate.Day).AddDays(-i + s_rand.Next(2, 5));
                o.DeliveryDate = o.DeliveryDate.GetValueOrDefault().AddDays(s_rand.Next(1, 3));

                OrdersList.Add(o);

            }

    }

    /// <summary>
    /// Order Items initialization
    /// </summary>
    private static void createAndInitOrderItems()
    {
        foreach (Order or in OrdersList)
        {
            for (int i = 0; i < 2; i++)
            {
                OrderItem oi = new OrderItem();
                oi.OrderItemID = Config.NextOrderNumber;
                oi.OrderID = or.ID;
                int someProd = s_rand.Next(0, 40);
                oi.ProductID = ProductsList[someProd].Value.ID;
                oi.Price = ProductsList[someProd].Value.Price;
                oi.Amount = s_rand.Next(1, 3);
                OrderItemsList.Add(oi);
            }
            
        }
    }
}
