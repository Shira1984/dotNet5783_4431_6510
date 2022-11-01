using System;
using System.Reflection.Metadata;

namespace Stage0
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Welcome4431();
            Welcome6510();
            Console.ReadKey();
        }

        static partial void Welcome6510();

        private static void Welcome4431()
        {
            Console.Write("Enter your name: ");
            string user = Console.ReadLine();
            Console.WriteLine("{0}, welcome to my first console application", user);
        }
    }
}