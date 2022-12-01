using BlImplementation;
using BlApi;
using BO;
using System.Threading.Tasks.Dataflow;

namespace BlTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            IBl bl = new Bl();
            IEnumerable<ProductForList?> productFL = bl.Product.GetListedProducts();
        }
    }
}