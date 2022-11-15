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
                    case 'b':
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

                                            Console.WriteLine("Please enter: ID,name, category, price, inStock");
                                            Product p= new Product();
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
                                            Console.WriteLine("Please enter: ID");
                                            int y=Console.Read();
                                            Product p = dalp.GetById(y);
                                            break;
                                        }
                                    case 'd':
                                        {
                                            Console.WriteLine("Please enter: ID,name, category, price, inStock");
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
                                            Console.WriteLine("Please enter: ID");
                                            int y = Console.Read();
                                            
                                            dalp.Delete(y);
                                            break;
                                        }

                                    case 'f':
                                        {
                                            break;
                                        }

                                        break;
                                }

                                catch(Exception e){ Console.WriteLine(e.Message); }

                                
                            }
                           break;
                        }
                    case 'c':
                        {
                            
                            Console.WriteLine(@"
Enter 'a' to EXIT,
Enter 'b' to add,
'c' to get by ID,
'd' to update,
'e' to delete");

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
                                            o.ID = Console.Read();
                                            o.CustomerName = Console.ReadLine();
                                            o.CustomerEmail = Console.ReadLine();
                                            o.CustomerAdress = Console.ReadLine();
                                    //        string date = Console.ReadLine();
                                    //if (!DateTime.TryParse(date, out OrderDate))
                                        int r = DalOrder.Add(o);


                                                break;

                                        }
                                    case 'c':
                                        {
                                            break;
                                        }
                                    case 'd':
                                        {
                                            break;
                                        }
                                    case 'e':
                                        {
                                            break;
                                        }
                                    case 'f':
                                        {
                                            break;
                                        }
                                        break;
                                }

                               

                                
                            }
                            break;
                        }
                            
                            

                    case 'd':
                        {
                            OrderItemMenu moOi;
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
                                            oi.OrderItemID = Console.Read();
                                            oi.ProductID = Console.Read();
                                            oi.OrderID = Console.Read();
                                            oi.Price = Console.Read();
                                            oi.Amount = Console.Read();
                                            int w = DalOrderItem.Add(oi);
                                            break;

                                        }
                                    case 'c':
                                        {
                                            break;
                                        }
                                    case 'd':
                                        {
                                            break;
                                        }
                                    case 'e':
                                        {
                                            break;
                                        }
                                    case 'f':
                                        {
                                            break;
                                        }
                                    case 'g':
                                        {
                                            break;
                                        }
                                    case 'h':
                                        {
                                            break;
                                        }

                                        break;
                                }
                                Catch(Exception  e){
                                    Console.WriteLine(e.Message);
                                }
                                break;
                            }
                            break;
                        }


            }
    }
    }
}
