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

            IEnumerable<ProductForList?> productFL = bl.Product.GetListedProducts();

            Console.WriteLine(@"Welcome!
Enter
0 for EXIT
1 for Product Options
2 for Order Options
3 for Cart Options");

            int opt;
            bool b = int.TryParse(Console.ReadLine(), out opt);
            mo = (MenuOptions)opt;
            while (mo != 0)
            {
                switch (mo)
                {
                    case MenuOptions.EXIT:
                        break;
                    case MenuOptions.PRODOCT:
                        {

                            break;
                        }
                    case MenuOptions.ORDER:
                        {

                            break;
                        }
                    case MenuOptions.CART:
                        {

                            break;
                        }
                    default:
                        break;
                }
            }

        }
    }
}