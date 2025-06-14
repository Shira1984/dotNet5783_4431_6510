﻿using BlImplementation;
using BlApi;
using BO;
using System.Threading.Tasks.Dataflow;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace BlTest
{
    internal class Program
    {
        enum MenuOptions { EXIT, PRODOCT, ORDER, CART }

        //enum MainMenu { EXIT, Product, Order, OrderItem }
        //enum OrderItemMenu { Main_Menu, Add, GetById, Update, Delete, GetAll, ItemsInOrder, GetByOrNumNProNum }

        enum ProductMenu { Main_Menu, Add, Update, Delete, Get_products_list, Get_product_for_manager, Get_product_for_client }
        enum OrderMenu { Main_Menu, Get_orders_list, Get_order_by_id_for_manager, Update_delivery_date_for_manager, Update_ship_date_for_manager, Follow_order_for_manager }
        enum CartMenu { Main_Menu, Add, Update, Order_cart }
        static Cart cartForFunc = new Cart() {CustomerName=" Yehoshua", CustomerEmail= "YehoshuaPfewalla.com", CustomerAdress="Ramot", Items=new List<OrderItem>(), TotalPrice=0 };
        static void Main(string[] args)
        {
            BlApi.IBl bl = BlApi.Factory.Get();
            //IBl bl = new Bl();
            MenuOptions mo;

           // IEnumerable<ProductForList?> productFL = bl.Product.GetListedProducts();

            Console.WriteLine(@"Welcome!
Enter
0 for EXIT
1 for Product Options
2 for Order Options
3 for Cart Options");

            int opt;
            bool b = int.TryParse(Console.ReadLine(), out opt);
            mo = (MenuOptions)opt;
           // bool flag = true;
            while (mo != 0)
            {
                switch (mo)
                {
                    case MenuOptions.EXIT:
                        break;
                    case MenuOptions.PRODOCT:
                        {
                            ProductMenu pm;
                            Console.WriteLine(@"Please press:
0 for menu options
1 for add
2 for update
3 for delete
4 for get products list
5 for get product (Manager option)
6 for get product (Client option)");
                            int optP;
                            b = int.TryParse(Console.ReadLine(), out optP);
                            pm = (ProductMenu)optP;
                            switch(pm)
                            {
                                case ProductMenu.Main_Menu:
                                    break;
                                case ProductMenu.Add:
                                    {
                                        Console.WriteLine("Please enter id: ");
                                        Product p = new Product();
                                       // flag = true;
                                      // while (flag)
                                       // {
                                            try
                                            {
                                                p.Id = int.Parse(Console.ReadLine());
                                        //        flag = false;
                                            }
                                            catch (FormatException)
                                            {
                                                BO.BlNotGoodValueException excep = new BlNotGoodValueException();
                                                Console.WriteLine(excep);
                                                Console.WriteLine("Please enter id again: ");
                                            }
                                        // }
                                        Console.WriteLine("Please enter name: ");
                                        p.Name = Console.ReadLine();

                                        Console.WriteLine("Please enter price: ");
                                       // flag = true;
                                       // while (flag)
                                        {
                                            try
                                            {
                                                p.Price = int.Parse(Console.ReadLine());
                                         //       flag = false;
                                            }
                                            catch(FormatException)
                                            {
                                                BO.BlNotGoodValueException excep = new BlNotGoodValueException();
                                                Console.WriteLine(excep);
                                                Console.WriteLine("Please enter another price: ");
                                            }
                                        }

                                        Console.WriteLine("Please enter 0 for Philosophy, 1 for Holocaust, 2 for Psychoanalysis and 3 for Russian literature: ");
                                        Enums.Category bc;
                                        int cat = int.Parse(Console.ReadLine());
                                        bc = (Enums.Category)cat;
                                        switch (bc)
                                        {
                                            case Enums.Category.Philosophy:
                                                {
                                                    p.Category = Enums.Category.Philosophy;
                                                    break;
                                                }
                                            case Enums.Category.Holocaust:
                                                {
                                                    p.Category = Enums.Category.Holocaust;
                                                    break;
                                                }
                                            case Enums.Category.Psychoanalysis:
                                                {
                                                    p.Category = Enums.Category.Psychoanalysis;
                                                    break;
                                                }
                                            case Enums.Category.RussianLiterature:
                                                {
                                                    p.Category = Enums.Category.RussianLiterature;
                                                    break;
                                                }
                                            default:
                                                break;
                                        }

                                        try
                                        {
                                            bl.Product.AddProductM(p);
                                            Console.WriteLine("Added sucessfully\n");
                                        }
                                        catch(BO.BlNotGoodValueException ex)
                                        {
                                            Console.WriteLine(ex);
                                        }
                                        catch (BO.BlAlredyFindException ex)
                                        {
                                            Console.WriteLine(ex);
                                        }
                                        catch (BO.BlNoFindException ex)
                                        {
                                            Console.WriteLine(ex);
                                        }
                                        break;
                                    }
                                case ProductMenu.Update:
                                    {
                                        Product p = new Product();
                                        Console.WriteLine("Please enter product's id: ");
                                       
                                            try
                                            {
                                                p.Id = int.Parse(Console.ReadLine());
                                        
                                            }
                                            catch(FormatException)
                                            {
                                                BO.BlNotGoodValueException excep = new BlNotGoodValueException();
                                                Console.WriteLine(excep);
                                                Console.WriteLine("Please enter another id: ");
                                            }
                                        // }
                                        Console.WriteLine("Please enter product's name: ");
                                        p.Name = Console.ReadLine();

                                        Console.WriteLine("Please enter price: ");
                                        // flag = true;
                                        // while (flag)
                                        {
                                            try
                                            {
                                                p.Price = int.Parse(Console.ReadLine());
                                                //       flag = false;
                                            }
                                            catch (FormatException)
                                            {
                                                BO.BlNotGoodValueException excep = new BlNotGoodValueException();
                                                Console.WriteLine(excep);
                                                Console.WriteLine("Please enter another price: ");
                                            }
                                        }

                                        Console.WriteLine("Please enter 0 for Philosophy, 1 for Holocaust, 2 for Psychoanalysis and 3 for Russian literature: ");
                                        Enums.Category bc;
                                        int cat = int.Parse(Console.ReadLine());
                                        bc = (Enums.Category)cat;
                                        switch (bc)
                                        {
                                            case Enums.Category.Philosophy:
                                                {
                                                    p.Category = Enums.Category.Philosophy;
                                                    break;
                                                }
                                            case Enums.Category.Holocaust:
                                                {
                                                    p.Category = Enums.Category.Holocaust;
                                                    break;
                                                }
                                            case Enums.Category.Psychoanalysis:
                                                {
                                                    p.Category = Enums.Category.Psychoanalysis;
                                                    break;
                                                }
                                            case Enums.Category.RussianLiterature:
                                                {
                                                    p.Category = Enums.Category.RussianLiterature;
                                                    break;
                                                }
                                            default:
                                                break;
                                        }

                                        try
                                        {
                                            bl.Product.UpdateProductM(p);
                                            Console.WriteLine("Updated sucessfully\n");
                                        }
                                        catch (BO.BlNotGoodValueException ex)
                                        {
                                            Console.WriteLine(ex);
                                        }
                                        catch (BO.BlAlredyFindException ex)
                                        {
                                            Console.WriteLine(ex);
                                        }
                                        catch (BO.BlNoFindException ex)
                                        {
                                            Console.WriteLine(ex);
                                        }
                                        break;
                                    }
                                case ProductMenu.Delete: // כאן לא עשיתי חריגות(!)
                                    {
                                        Console.WriteLine("Please enter product's id: ");
                                        int pid = int.Parse(Console.ReadLine());
                                        bl.Product.DeleteProductM(pid);
                                        Console.WriteLine("Deleted sueccessfully");
                                        break;
                                    }
                                case ProductMenu.Get_products_list: // נראה קל מדי, לבדוק אם נכון
                                    {
                                        IEnumerable<ProductForList?> proF = new List<ProductForList?>();
                                        proF = bl.Product.GetListedProducts();
                                        foreach (ProductForList p in proF)
                                        {
                                            Console.WriteLine(p);
                                        }

                                        break;
                                    }
                                case ProductMenu.Get_product_for_manager: // ללא חריגות
                                    {
                                        Product p = new Product();
                                        Console.WriteLine("Please enter product's id: ");
                                        int pid = int.Parse(Console.ReadLine());
                                        p=bl.Product.GetProductM(pid);
                                        Console.WriteLine(p);
                                        break;
                                    }
                                case ProductMenu.Get_product_for_client:
                                    {
                                        ProductItem p = new ProductItem();
                                        Console.WriteLine("Please enter product's id: ");
                                        int pid = int.Parse(Console.ReadLine());
                                        p=bl.Product.GetProductC(pid, cartForFunc);
                                        Console.WriteLine(p);
                                        break;
                                    }
                                default:
                                    break;
                            }
                            break;
                        }
                    case MenuOptions.ORDER:
                        {
                            OrderMenu om;
                            Console.WriteLine(@"
Please press:
0 for main menu
1 for get orders list
2 for get order by id (Manager option)
3 for update delivery date (Manager option)
4 for update ship date (Manager option)
5 for follow order (Manager option)");
                            int optO;
                            b = int.TryParse(Console.ReadLine(), out optO);
                            om = (OrderMenu)optO;
                            switch (om)
                            {
                                case OrderMenu.Main_Menu:
                                    break;
                                case OrderMenu.Get_orders_list:
                                    {
                                        try
                                        {
                                            IEnumerable<BO.OrderForList> neli = bl.Order.GetOrderForListM();
                                        }

                                        catch (BO.BlNoFindException ex)
                                        {
                                            Console.WriteLine(ex);
                                        }
                                        IEnumerable<OrderForList?> li = bl.Order.GetOrderForListM();
                                        foreach (BO.OrderForList m in li)
                                        {
                                            Console.WriteLine(m);
                                        }
                                       
                                        break;
                                    }
                                case OrderMenu.Get_order_by_id_for_manager:
                                    {
                                        Console.WriteLine("please enter id of order");
                                        BO.Order newO = new BO.Order();
                                        int idO = int.Parse(Console.ReadLine());

                                        try
                                        {
                                            newO = bl.Order.GetByOrderIdM(idO);
                                        }

                                        catch (BO.BlNoFindException ex)
                                        {
                                            Console.WriteLine(ex);
                                        }
                                        
                                        Console.WriteLine("newO");
                                        break;
                                    }
                                case OrderMenu.Update_delivery_date_for_manager:
                                    {
                                        Console.WriteLine("please enter id of order");
                                        int idO = int.Parse(Console.ReadLine());
                                        BO.Order newO = new BO.Order();
                                        
                                        try
                                        {
                                            newO = bl.Order.UpdateDeliveryDateM(idO);
                                        }

                                        catch (BO.BlNoFindException ex)
                                        {
                                            Console.WriteLine(ex);
                                        }
                                        Console.WriteLine("newO");
                                        break;
                                    }
                                case OrderMenu.Update_ship_date_for_manager:
                                    {
                                        Console.WriteLine("please enter id of order");
                                        int idO = int.Parse(Console.ReadLine());
                                        BO.Order newO = new BO.Order();
                                       
                                        try
                                        {
                                            newO = bl.Order.UpdateShipDateM(idO);

                                        }

                                        catch (BO.BlNoFindException ex)
                                        {
                                            Console.WriteLine(ex);
                                        }
                                        Console.WriteLine("newO");
                                        break;
                                    }
                                case OrderMenu.Follow_order_for_manager:
                                    {

                                        Console.WriteLine("please enter id of order");
                                        int idO = int.Parse(Console.ReadLine());
                                        BO.OrderTracking ot = new BO.OrderTracking();
                                        
                                        try
                                        {
                                            ot = bl.Order.FollowOrderM(idO);

                                        }

                                        catch (BO.BlNoFindException ex)
                                        {
                                            Console.WriteLine(ex);
                                        }
                                        Console.WriteLine("ot");
                                        break;
                                    }
                                default:
                                    break;
                            }
                            break;
                        }
                    case MenuOptions.CART: //cart
                        {
                            CartMenu cm;
                            Console.WriteLine(@"
Please press:
0 for main menu
1 for add
2 for update
3 for order cart");
                            int optC;
                            b = int.TryParse(Console.ReadLine(), out optC);
                            cm = (CartMenu)optC;
                            switch (cm)
                            {
                                case CartMenu.Main_Menu:
                                    break;
                                case CartMenu.Add:
                                    {
                                        Console.WriteLine("plesse enter product id");
                                        int pid = int.Parse(Console.ReadLine());
                                        bl.Cart.AddProductToCart(cartForFunc, pid);
                                        Console.WriteLine(cartForFunc);
                                        break;
                                    }
                                case CartMenu.Update:
                                    {
                                        Console.WriteLine("plesse enter product id");
                                        int pid = int.Parse(Console.ReadLine());
                                        Console.WriteLine("plesse enter the amount you want to update");
                                        int n = int.Parse(Console.ReadLine());
                                        try
                                        {
                                            bl.Cart.UpdateProductInCartCV(cartForFunc, pid, n);
                                        }
                                        catch(BO.BlNotGoodValueException ex)
                                        {
                                            Console.WriteLine(ex);
                                        }
                                        Console.WriteLine(cartForFunc);

                                        break;
                                    }
                                case CartMenu.Order_cart:
                                    {
                                        Console.WriteLine("plesse enter name");
                                        String name=Console.ReadLine();
                                        Console.WriteLine("plesse enter email");
                                        String email = Console.ReadLine();
                                        Console.WriteLine("plesse enter adress");
                                        String adress = Console.ReadLine();
                                        
                                        bl.Cart.OrderCart(cartForFunc, name, email, adress);
                                        Console.WriteLine("Order_cart done");
                                        break;
                                    }
                                default:
                                    break;
                            }
                            break;
                        }
                    default:
                        break;
                }
                Console.WriteLine(@"Welcome!
Enter
0 for EXIT
1 for Product Options
2 for Order Options
3 for Cart Options");
                b = int.TryParse(Console.ReadLine(), out opt);
                mo = (MenuOptions)opt;
            }

        }
    }
}