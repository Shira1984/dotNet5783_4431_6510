using Dal;
using DO;
using System.Linq.Expressions;
using static DO.Enums;


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
            DalProduct dalp = new DalProduct();
            DalOrder dalo = new DalOrder();
            DalOrderItem daloi = new DalOrderItem();

            Console.WriteLine(@"Welcom!
Enter a to EXIT,
b for product options,
c for Order options,
d for OrderItem options");

            string c;
            c = Console.ReadLine();
            char m;
            if (!char.TryParse(c, out m))
                throw new Exception("couldnt parse");
            try
            {
                switch (m)
                {
                    case 'a':
                        break;
                    case 'b':   //Product
                        {

                            Console.WriteLine(@"
Enter a to EXIT,
Enter b to add,
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
                                    case 'a':
                                        break;
                                    case 'b':
                                        {

                                            Console.WriteLine("Please enter ID, name, category, price, inStock: ");
                                            Product p = new Product();
                                            p.ID = Console.Read();
                                            p.Name = Console.ReadLine();
                                            int x;
                                            bool k = int.TryParse(Console.ReadLine(), out x);
                                            p.Category = (Category)x;
                                            p.Price = Console.Read();
                                            p.InStock = Console.Read();
                                            int id = dalp.Add(p);
                                            break;

                                        }
                                    case 'c':
                                        {
                                            Console.WriteLine("Please enter ID: ");
                                            int y = Console.Read();
                                            Product p = dalp.GetById(y);
                                            break;
                                        }
                                    case 'd':
                                        {
                                            Console.WriteLine("Please enter ID, name, category, price, inStock: ");
                                            Product p = new Product();
                                            p.ID = Console.Read();
                                            p.Name = Console.ReadLine();
                                            int x;
                                            bool k = int.TryParse(Console.ReadLine(), out x);
                                            p.Category = (Category)x;
                                            p.Price = Console.Read();
                                            p.InStock = Console.Read();
                                            dalp.Update(p);
                                            break;
                                        }
                                    case 'e':
                                        {
                                            Console.WriteLine("Please enter ID: ");
                                            int y = Console.Read();

                                            dalp.Delete(y);
                                            break;
                                        }

                                    case 'f':
                                        {
                                            dalp.GetAll();
                                            break;
                                        }

                                        break;
                                }

                            }
                            catch (Exception e) { Console.WriteLine(e.Message); }
                            break;
                        }
                    case 'c':  //order
                        {

                            Console.WriteLine(@"
Enter 'a' to EXIT,
Enter 'b' to add,
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
                                    case 'a':
                                        break;
                                    case 'b':
                                        {

                                            Console.WriteLine("Please enter: ID,costumerName, costumerEmaill, costumerAdress, OrderDate");
                                            Order o = new Order();
                                            o.ID = Console.Read();
                                            o.CustomerName = Console.ReadLine();
                                            o.CustomerEmail = Console.ReadLine();
                                            o.CustomerAdress = Console.ReadLine();
                                            //string date = Console.ReadLine();
                                            //if (!DateTime.TryParse(date, out o.OrderDate))
                                                int r = dalo.Add(o);

                                            break;

                                        }
                                    case 'c':
                                        {
                                            Console.WriteLine("Please enter ID: ");
                                            int y = Console.Read();
                                            Order o = dalo.GetById(y);
                                            break;
                                        }
                                    case 'd':
                                        {

                                            Console.WriteLine("Please enter ID, name, category, price, inStock: ");
                                            Order o= new Order();
                                            o.ID = Console.Read();
                                            o.CustomerName= Console.ReadLine();
                                            o.CustomerAdress= Console.ReadLine();
                                            //o.OrderDate
                                            dalo.Update(o);
                                            break;
                                        }
                                    case 'e':
                                        {
                                            Console.WriteLine("Please enter ID: ");
                                            int y = Console.Read();

                                            dalo.Delete(y);
                                            break;
                                        }
                                    case 'f':
                                        {
                                            dalo.GetAll();
                                            break;
                                        }
                                        break;

                                }
                            }
                            catch (Exception e) { Console.WriteLine(e.Message); }
                            break;
                        }


                    case 'd':
                        {
                          
                            Console.WriteLine(@"
Enter a to EXIT,
Enter b to add,
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
                                    case 'a':
                                        break;
                                    case 'b':
                                        {

                                            Console.WriteLine("Please enter: OrderItemID,ProductID, OrderID, Price, Amount");
                                            OrderItem oi = new OrderItem();
                                            oi.OrderID = Console.Read();
                                            oi.ProductID = Console.Read();
                                            oi.OrderID = Console.Read();
                                            oi.Price = Console.Read();
                                            oi.Amount = Console.Read();
                                            int w = daloi.Add(oi);
                                            break;

                                        }
                                    case 'c':
                                        {
                                            Console.WriteLine("Please enter ID: ");
                                            int y = Console.Read();
                                            OrderItem o = daloi.GetById(y);
                                            break;
                                        }
                                    case 'd':
                                        {

                                            Console.WriteLine("Please enter: OrderItemID,ProductID, OrderID, Price, Amount");
                                            OrderItem oi = new OrderItem();
                                            oi.OrderItemID = Console.Read();
                                            oi.ProductID= Console.Read();
                                            oi.OrderID= Console.Read();
                                            oi.Price= Console.Read();
                                            oi.Amount= Console.Read();
                                            daloi.Update(oi);
                                            break;
                                        }
                                    case 'e':
                                        {
                                            Console.WriteLine("Please enter ID: ");
                                            int y = Console.Read();

                                            daloi.Delete(y);
                                            break;
                                        }
                                    case 'f':
                                        {
                                            daloi.GetAll();
                                            break;
                                        }
                                    case 'g':
                                        {

                                            Console.WriteLine("Please enter ID: ");
                                            int y = Console.Read();

                                            List<OrderItem?> products=daloi.ItemsInOrder(y);
                                            break;
                                        }
                                    case 'h':
                                        {
                                            Console.WriteLine("Please enter order ID and product ID:");
                                            int y = Console.Read(); //order ID
                                            int z = Console.Read();//product ID
                                            OrderItem? op = daloi.GetByOrNumNProNum(y, z);
                                            break;
                                        }

                                        break;
                                }
                            }
                            catch (Exception e) { Console.WriteLine(e.Message); }
                            break;
                        }
                        break;
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
           

        }
        
    }
}
