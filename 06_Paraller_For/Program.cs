using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _06_Paraller_For
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            Console.ReadKey();
            Console.WriteLine("Started!");

            //for (int i = 0; i < 20; i++)
            //{
            //    Factorial(i);
            //}

            // itertions: [1...19]
            Parallel.For(1, 20, Factorial);


            //for (int i = 1; i < 50; i++)
            //{
            //    Task.Run(() => Factorial(i));
            //}

            Console.ReadLine();
        }

        static void Factorial(int x)
        {
            Random r = new Random();
            for (int i = 0; i < 10_000_000; i++)
            {
                r.Next();
                r.GetHashCode();
                r.NextDouble();
            }

            int result = 1;
            for (int i = 1; i <= x; i++)
            {
                result *= i;               
            }

            Console.WriteLine($"Task executing {Task.CurrentId}");
            //Thread.Sleep(3000);
            Console.WriteLine($"Factorial {x} = {result}");
        }
    }
}
