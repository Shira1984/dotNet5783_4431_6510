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

            string? c;
            c = Console.ReadLine();
            char m;
            if (!char.TryParse(c, out m))
                throw new Exception("couldnt parse");
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
                                            p.ID = Console.Read();
                                            Console.WriteLine("Please enter name");
                                            p.Name = Console.ReadLine();
                                            Console.WriteLine("Enter 0 to Philosophy, 1 to Holocaust, 2 to Psychoanalysis, 3 to Biography, 4 to RussianLiterature:");
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
                                                case DO.Enums.Category.Biography:
                                                    {
                                                        p.Category = DO.Enums.Category.Biography;
                                                        break;
                                                    }
                                                case DO.Enums.Category.RussianLiterature:
                                                    {
                                                        p.Category = DO.Enums.Category.RussianLiterature;
                                                        break;
                                                    }
                                            }
                                            break;
                                        }
                                    case 'c': //get by ID
                                        {
                                            Console.WriteLine("Please enter ID: ");
                                            int y = Console.Read();
                                            Product p = dalp.GetById(y);
                                            break;
                                        }
                                    case 'd': //update
                                        {
                                            Console.WriteLine("Please enter ID, name, category, price, inStock: ");//לשנות כמו מה שנעשה בהוספה למעלה
                                            Product p = new Product();
                                            p.ID = Console.Read();
                                            p.Name = Console.ReadLine();
                                            int x;
                                            bool k = int.TryParse(Console.ReadLine(), out x);
                                            Console.WriteLine("Enter 0 to Philosophy, 1 to Holocaust, 2 to Psychoanalysis, 3 to Biography, 4 to RussianLiterature:");
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
                                                case DO.Enums.Category.Biography:
                                                    {
                                                        p.Category = DO.Enums.Category.Biography;
                                                        break;
                                                    }
                                                case DO.Enums.Category.RussianLiterature:
                                                    {
                                                        p.Category = DO.Enums.Category.RussianLiterature;
                                                        break;
                                                    }
                                            }
                                            break;
                                            Console.WriteLine("Please enter price, inStock: ");
                                            p.Price = Console.Read();
                                            p.InStock = Console.Read();
                                            dalp.Update(p);
                                            break;
                                        }
                                    case 'e'://delete
                                        {
                                            Console.WriteLine("Please enter ID: ");
                                            int y = Console.Read();

                                            dalp.Delete(y);
                                            break;
                                        }

                                    case 'f': //getall
                                        {
                                            List<Product?> p = (List<Product?>)dalp.GetAll();
                                            foreach(Product pr in p)
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

                                            Console.WriteLine("Please enter: ID,costumerName, costumerEmaill, costumerAdress, OrderDate");
                                            Order o = new Order();
                                            o.ID = Console.Read();
                                            o.CustomerName = Console.ReadLine();
                                            o.CustomerEmail = Console.ReadLine();
                                            o.CustomerAdress = Console.ReadLine();
                                            o.OrderDate = DateTime.Now;
                                    
                                                int r = dalo.Add(o);

                                            break;

                                        }
                                    case 'c': //get by id
                                        {
                                            Console.WriteLine("Please enter ID: ");
                                            int y = Console.Read();
                                            Order o = dalo.GetById(y);
                                            break;
                                        }
                                    case 'd'://update
                                        {

                                            Console.WriteLine("Please enter ID, name, category, price, inStock: ");
                                            Order o= new Order();
                                            o.ID = Console.Read();
                                            o.CustomerName= Console.ReadLine();
                                            o.CustomerAdress= Console.ReadLine();
                                            o.OrderDate = DateTime.Now;
                                            dalo.Update(o);
                                            break;
                                        }
                                    case 'e': //delete
                                        {
                                            Console.WriteLine("Please enter ID: ");
                                            int y = Console.Read();

                                            dalo.Delete(y);
                                            break;
                                        }
                                    case 'f': //get all
                                        {
                                            List<Order?> ord = (List<Order?>)dalo.GetAll();
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
                                    case 'c'://get by id
                                        {
                                            Console.WriteLine("Please enter ID: ");
                                            int y = Console.Read();
                                            OrderItem o = daloi.GetById(y);
                                            break;
                                        }
                                    case 'd'://update
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
                                    case 'e'://delete
                                        {
                                            Console.WriteLine("Please enter ID: ");
                                            int y = Console.Read();

                                            daloi.Delete(y);
                                            break;
                                        }
                                    case 'f'://get all
                                        {
                                            List<OrderItem?> p = (List<OrderItem?>)daloi.GetAll();
                                            break;
                                        }
                                    case 'g': //ItemsInOrder
                                        {

                                            Console.WriteLine("Please enter ID: ");
                                            int y = Console.Read();

                                            IEnumerable<OrderItem?> products=daloi.ItemsInOrder(y);
                                            break;
                                        }
                                    case 'h': //GetByOrNumNProNum
                                        {
                                            Console.WriteLine("Please enter order ID and product ID:");
                                            int y = Console.Read(); //order ID
                                            int z = Console.Read();//product ID
                                            OrderItem? op = daloi.GetByOrNumNProNum(y, z);
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
           

        }
        
    }
}
