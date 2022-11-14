using Dal;

internal class Main
{

    class Program

    {
        enum MainMenu { EXIT, Product, Order, OrderItem }
        enum ProductMenu { EXIT, Add, GetById, Update, Delete }
        enum OrderMenu { EXIT, Add, GetById, Update, Delete }
        enum OrderItemMenu { EXIT, Add, GetById, Update, Delete, GetAll, ItemsInOrder, GetByOrNumNProNum }
        static void Main(string[] args)
        {
            MainMenu mo;
            Console.WriteLine(@"Welcom!
Enter 0 to EXIT,
1 for product options,
2 for Order options,
3 for OrderItem options");

            int opt;
            bool b= int. TryParse(Console.ReadLine(), out opt);
            mo = (MainMenu)opt;
            //bool flag = true;
            DO.Product p= new DO.Product();
            
            switch (mo)
                {
                    case MainMenu.EXIT:
                        break;
                    case MainMenu.Product:
                    {
                        ProductMenu moP;
                        Console.WriteLine(@"
Enter 0 to EXIT,
Enter 1 to add,
2 to get by ID,
3 to update,
4 to delete");
                        int optP;
                        bool bP = int.TryParse(Console.ReadLine(), out opt);
                        moP = (ProductMenu)opt;
                        //bool flag = true;
                        switch (moP)
                        {
                            case ProductMenu.EXIT:
                                break;
                            case ProductMenu.Add:
                                {
                                    
                                    Console.WriteLine("Please enter: ID,name, category, price, inStock");
                                    p.ID = Console.Read();
                                    p.Name = Console.ReadLine();
                                    p.Category = 
                                    p.Price=Console.Read();
                                    p.InStock=Console.Read();

                                    return;
                               
                                }
                            case ProductMenu.GetById:
                                {

                                }
                            case ProductMenu.Update:
                                {

                                }
                            case ProductMenu.Delete:
                                {

                                }

                               
                        }
                           
                    }
                    case MainMenu.Order:
                    {

                    }
                    case MainMenu.OrderItem:
                    {

                    }
                }
                
            
        }
    }
}