using Dal;
using DO;
using System.Linq.Expressions;
using static DO.Enums;
using System;
using System.Collections.Generic;
using System.Collections;
using DalApi;


internal class Main
{

    class Program

    {
        enum MainMenu { EXIT, Product, Order, OrderItem }
        enum ProductMenu { EXIT, Add, GetById, Update, Delete, GetAll }
        enum OrderMenu { EXIT, Add, GetById, Update, Delete, GetAll }
        enum OrderItemMenu { EXIT, Add, GetById, Update, Delete, GetAll, ItemsInOrder, GetByOrNumNProNum }
        static void Main(string[] args)
        {
            //DalProduct dalp = new DalProduct();
            //DalOrder dalo = new DalOrder();
            //DalOrderItem daloi = new DalOrderItem();
            IDal dal= new DalList();
            Console.WriteLine(@"Welcome!
Enter a to EXIT,
b for product options,
c for Order options,
d for OrderItem options");

            string? c;
            c = Console.ReadLine();
            char m;
            if (!char.TryParse(c, out m))
                throw new Exception("couldnt parse");

            while (m != 'a')
            {
                try
                {
                    switch (m)
                    {
                        case 'a':  //EXIT
                            break;
                        case 'b':   //Product
                            {

                                Console.WriteLine(@"
Enter
a to EXIT,
b to add,
c to get by ID,
d to update,
e to delete,
f to GetAll");


                                c = Console.ReadLine();

                                if (!char.TryParse(c, out m))
                                    throw new Exception("couldnt parse");
                                try
                                {
                                    switch (m)
                                    {
                                        case 'a': //EXIT
                                            break;
                                        case 'b': //add
                                            {

                                                Product p = new Product();
                                                Console.WriteLine("Please enter ID");
                                                p.ID = int.Parse(Console.ReadLine());
                                                Console.WriteLine("Please enter name");
                                                p.Name = Console.ReadLine();
                                                Console.WriteLine("Enter 0 to Philosophy, 1 to Holocaust, 2 to Psychoanalysis, 3 to RussianLiterature:");
                                                DO.Enums.Category cat;
                                                int ca = int.Parse(Console.ReadLine());
                                                cat = (DO.Enums.Category)ca;


                                                switch (cat)
                                                {
                                                    case DO.Enums.Category.Philosophy:
                                                        {
                                                            p.Category = DO.Enums.Category.Philosophy;
                                                            break;
                                                        }
                                                    case DO.Enums.Category.Holocaust:
                                                        {
                                                            p.Category = DO.Enums.Category.Holocaust;
                                                            break;
                                                        }
                                                    case DO.Enums.Category.Psychoanalysis:
                                                        {
                                                            p.Category = DO.Enums.Category.Psychoanalysis;
                                                            break;
                                                        }
                                                    case DO.Enums.Category.RussianLiterature:
                                                        {
                                                            p.Category = DO.Enums.Category.RussianLiterature;
                                                            break;
                                                        }


                                                }

                                                Console.WriteLine("Please enter price");
                                                p.Price = double.Parse(Console.ReadLine());
                                                Console.WriteLine("Please enter inStok");
                                                p.InStock = int.Parse(Console.ReadLine());
                                                dal.Product.Add(p);
                                                break;

                                            }
                                        case 'c': //get by ID
                                            {
                                                Console.WriteLine("Please enter ID: ");
                                                int y = int.Parse(Console.ReadLine());
                                                Product p = dal.Product.GetById(y);
                                                Console.WriteLine(p);
                                                break;
                                            }
                                        case 'd': //update
                                            {
                                                Product p = new Product();
                                                Console.WriteLine("Please enter ID");
                                                p.ID = int.Parse(Console.ReadLine());
                                                Console.WriteLine("Please enter name");
                                                p.Name = Console.ReadLine();
                                                Console.WriteLine("Enter 0 to Philosophy, 1 to Holocaust, 2 to Psychoanalysis, 3 to RussianLiterature:");
                                                DO.Enums.Category cat;
                                                int ca = int.Parse(Console.ReadLine());
                                                cat = (DO.Enums.Category)ca;


                                                switch (cat)
                                                {
                                                    case DO.Enums.Category.Philosophy:
                                                        {
                                                            p.Category = DO.Enums.Category.Philosophy;
                                                            break;
                                                        }
                                                    case DO.Enums.Category.Holocaust:
                                                        {
                                                            p.Category = DO.Enums.Category.Holocaust;
                                                            break;
                                                        }
                                                    case DO.Enums.Category.Psychoanalysis:
                                                        {
                                                            p.Category = DO.Enums.Category.Psychoanalysis;
                                                            break;
                                                        }
                                                    case DO.Enums.Category.RussianLiterature:
                                                        {
                                                            p.Category = DO.Enums.Category.RussianLiterature;
                                                            break;
                                                        }


                                                }

                                                Console.WriteLine("Please enter price");
                                                p.Price = double.Parse(Console.ReadLine());
                                                Console.WriteLine("Please enter inStok");
                                                p.InStock = int.Parse(Console.ReadLine());
                                                dal.Product.Update(p);
                                                break;


                                                //Console.WriteLine("Please enter ID, name, category, price, inStock: ");//לשנות כמו מה שנעשה בהוספה למעלה
                                                //Product p = new Product();
                                                //p.ID = int.Parse(Console.ReadLine());
                                                //p.Name = Console.ReadLine();
                                                //int x;
                                                //bool k = int.TryParse(Console.ReadLine(), out x);
                                                //Console.WriteLine("Enter 0 to Philosophy, 1 to Holocaust, 2 to Psychoanalysis, 3 to RussianLiterature:");
                                                //DO.Enums.Category cat;
                                                //int ca = int.Parse(Console.ReadLine());
                                                //cat = (DO.Enums.Category)ca;


                                                //switch (cat)
                                                //{
                                                //    case DO.Enums.Category.Philosophy:
                                                //        {
                                                //            p.Category = DO.Enums.Category.Philosophy;
                                                //            break;
                                                //        }
                                                //    case DO.Enums.Category.Holocaust:
                                                //        {
                                                //            p.Category = DO.Enums.Category.Holocaust;
                                                //            break;
                                                //        }
                                                //    case DO.Enums.Category.Psychoanalysis:
                                                //        {
                                                //            p.Category = DO.Enums.Category.Psychoanalysis;
                                                //            break;
                                                //        }
                                                //    case DO.Enums.Category.RussianLiterature:
                                                //        {
                                                //            p.Category = DO.Enums.Category.RussianLiterature;
                                                //            break;
                                                //        }
                                                //}
                                                //break;
                                                //Console.WriteLine("Please enter price, inStock: ");
                                                //p.Price = int.Parse(Console.ReadLine());
                                                //p.InStock = int.Parse(Console.ReadLine());
                                                //dal.Product.Update(p);
                                                //break;
                                            }
                                        case 'e'://delete
                                            {
                                                Console.WriteLine("Please enter ID: ");
                                                int y = int.Parse(Console.ReadLine());

                                                dal.Product.Delete(y);
                                                break;
                                            }

                                        case 'f': //getall
                                            {
                                                IEnumerable<Product?> p = (IEnumerable<Product?>)dal.Product.GetAll();
                                                foreach (Product pr in p)
                                                    Console.WriteLine(pr);
                                                break;
                                            }
                                    }

                                }
                                catch (Exception e) { Console.WriteLine(e.Message); }
                                break;
                            }
                        case 'c':  //order
                            {

                                Console.WriteLine(@"
Enter 'a' to EXIT,
'b' to add,
'c' to get by ID,
'd' to update,
'e' to delete,
f to GetAll");

                                c = Console.ReadLine();

                                if (!char.TryParse(c, out m))
                                    throw new Exception("couldnt parse");
                                try
                                {
                                    switch (m)
                                    {
                                        case 'a': //EXIT
                                            break;
                                        case 'b': //add
                                            {
                                                Order o = new Order();
                                                Console.WriteLine("Please enter: ID");
                                                o.ID = int.Parse(Console.ReadLine());
                                                Console.WriteLine("Please enter: costumerName");
                                                o.CustomerName = Console.ReadLine();
                                                Console.WriteLine("Please enter: costumerEmaill");
                                                o.CustomerEmail = Console.ReadLine();
                                                Console.WriteLine("Please enter: costumerAdress");
                                                o.CustomerAdress = Console.ReadLine();
                                                o.OrderDate = DateTime.Now;
                                                int r = dal.Order.Add(o);

                                                break;
                                            }
                                        case 'c': //get by id
                                            {
                                                Console.WriteLine("Please enter ID: ");
                                                int y = int.Parse(Console.ReadLine());
                                                Order o = dal.Order.GetById(y);
                                                break;
                                            }
                                        case 'd'://update
                                            {
                                                Order o = new Order();
                                                Console.WriteLine("Please enter: ID");
                                                o.ID = int.Parse(Console.ReadLine());
                                                Console.WriteLine("Please enter: costumerName");
                                                o.CustomerName = Console.ReadLine();
                                                Console.WriteLine("Please enter: costumerEmaill");
                                                o.CustomerEmail = Console.ReadLine();
                                                Console.WriteLine("Please enter: costumerAdress");
                                                o.CustomerAdress = Console.ReadLine();
                                                o.OrderDate = DateTime.Now;
                                                dal.Order.Update(o);
                                                break;
                                            }
                                        case 'e': //delete
                                            {
                                                Console.WriteLine("Please enter ID: ");
                                                int y = int.Parse(Console.ReadLine());

                                                dal.Order.Delete(y);
                                                break;
                                            }
                                        case 'f': //get all
                                            {
                                                IEnumerable<Order?> ord = (IEnumerable<Order?>)dal.Order.GetAll();
                                                foreach (Order or in ord)
                                                    Console.WriteLine(or);
                                                break;
                                            }

                                    }
                                }
                                catch (Exception e) { Console.WriteLine(e.Message); }
                                break;
                            }


                        case 'd': //OrderItem
                            {

                                Console.WriteLine(@"
Enter a to EXIT,
b to add,
c to get by ID,
d to update,
e to delete,
f to GetAll,
g to ItemsInOrder,
h to GetByOrNumNProNum ");

                                if (!char.TryParse(c, out m))
                                    throw new Exception("couldnt parse");
                                try
                                {
                                    switch (m)
                                    {
                                        case 'a'://EXIT
                                            break;
                                        case 'b'://all
                                            {

                                                OrderItem oi = new OrderItem();
                                                Console.WriteLine("Please enter: OrderItemID");
                                                oi.OrderID = int.Parse(Console.ReadLine());
                                                Console.WriteLine("Please enter: ProductID");
                                                oi.ProductID = int.Parse(Console.ReadLine());
                                                Console.WriteLine("Please enter: OrderID");
                                                oi.OrderID = int.Parse(Console.ReadLine());
                                                Console.WriteLine("Please enter: Price");
                                                oi.Price = double.Parse(Console.ReadLine());
                                                Console.WriteLine("Please enter: Amount");
                                                oi.Amount = int.Parse(Console.ReadLine());
                                                int w = dal.OrderItem.Add(oi);
                                                Console.WriteLine(w);
                                                break;

                                            }
                                        case 'c'://get by id
                                            {
                                                Console.WriteLine("Please enter ID: ");
                                                int y = int.Parse(Console.ReadLine());
                                                OrderItem o = dal.OrderItem.GetById(y);
                                                break;
                                            }
                                        case 'd'://update
                                            {

                                                OrderItem oi = new OrderItem();
                                                Console.WriteLine("Please enter: OrderItemID");
                                                oi.OrderID = int.Parse(Console.ReadLine());
                                                Console.WriteLine("Please enter: ProductID");
                                                oi.ProductID = int.Parse(Console.ReadLine());
                                                Console.WriteLine("Please enter: OrderID");
                                                oi.OrderID = int.Parse(Console.ReadLine());
                                                Console.WriteLine("Please enter: Price");
                                                oi.Price = double.Parse(Console.ReadLine());
                                                Console.WriteLine("Please enter: Amount");
                                                oi.Amount = int.Parse(Console.ReadLine());
                                                dal.OrderItem.Update(oi);
                                                break;
                                            }
                                        case 'e'://delete
                                            {
                                                Console.WriteLine("Please enter ID: ");
                                                int y = int.Parse(Console.ReadLine());

                                                dal.OrderItem.Delete(y);
                                                break;
                                            }
                                        case 'f'://get all
                                            {
                                                IEnumerable<OrderItem?> p = (IEnumerable<OrderItem?>)dal.OrderItem.GetAll();
                                                break;
                                            }
                                        case 'g': //ItemsInOrder
                                            {

                                                Console.WriteLine("Please enter ID: ");
                                                int y = int.Parse(Console.ReadLine());

                                                IEnumerable<OrderItem?> products = dal.OrderItem.ItemsInOrder(y);
                                                break;
                                            }
                                        case 'h': //GetByOrNumNProNum
                                            {
                                                Console.WriteLine("Please enter order ID and product ID:");
                                                int y = int.Parse(Console.ReadLine()); //order ID
                                                int z = int.Parse(Console.ReadLine());//product ID
                                                OrderItem? op = dal.OrderItem.GetByOrNumNProNum(y, z);
                                                break;
                                            }
                                    }
                                }
                                catch (Exception e) { Console.WriteLine(e.Message); }
                                break;
                            }
                    }
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
                Console.WriteLine("Enter a to EXIT,'b' for product options,'c' for Order options,'d' for OrderItem options");
                c = Console.ReadLine();

                if (!char.TryParse(c, out m))
                    throw new Exception("couldnt parse");

            }

        }
    }
}
