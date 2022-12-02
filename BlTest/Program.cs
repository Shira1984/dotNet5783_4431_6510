using BlImplementation;
using BlApi;
using BO;
using System.Threading.Tasks.Dataflow;

namespace BlTest
{
    internal class Program
    {
        enum MenuOptions { EXIT, PRODOCT, ORDER, CART }

        //enum MainMenu { EXIT, Product, Order, OrderItem }
        //enum OrderItemMenu { Main_Menu, Add, GetById, Update, Delete, GetAll, ItemsInOrder, GetByOrNumNProNum }

        enum ProductMenu { Main_Menu, Add, Delete, Update, Get_products_list, Get_product_for_manager, Get_product_for_client }
        enum OrderMenu { Main_Menu, Get_orders_list, Get_order_by_id_for_manager, Update_delivery_date_for_manager, Update_ship_date_for_manager, Follow_order_for_manager }
        enum CartMenu { Main_Menu, Add, Update, Order_cart}

        static void Main(string[] args)
        {
            IBl bl = new Bl();
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

                                        break;
                                    }
                                case ProductMenu.Update:
                                    {

                                        break;
                                    }
                                case ProductMenu.Delete:
                                    {

                                        break;
                                    }
                                case ProductMenu.Get_products_list:
                                    {

                                        break;
                                    }
                                case ProductMenu.Get_product_for_manager:
                                    {

                                        break;
                                    }
                                case ProductMenu.Get_product_for_client:
                                    {

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

                                        break;
                                    }
                                case OrderMenu.Get_order_by_id_for_manager:
                                    {

                                        break;
                                    }
                                case OrderMenu.Update_delivery_date_for_manager:
                                    {

                                        break;
                                    }
                                case OrderMenu.Update_ship_date_for_manager:
                                    {

                                        break;
                                    }
                                case OrderMenu.Follow_order_for_manager:
                                    {

                                        break;
                                    }
                                default:
                                    break;
                            }
                            break;
                        }
                    case MenuOptions.CART:
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

                                        break;
                                    }
                                case CartMenu.Update:
                                    {

                                        break;
                                    }
                                case CartMenu.Order_cart:
                                    {

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