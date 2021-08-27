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
            // itertions: [1...9]
            Parallel.For(1, 10, Factorial);

            //for (int i = 1; i < 10; i++)
            //{
            //    Task.Run(() => Factorial(i));
            //}

            Console.ReadLine();
        }

        static void Factorial(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;               
            }
            Console.WriteLine($"Task executing {Task.CurrentId}");
            Thread.Sleep(3000);
            Console.WriteLine($"Factorial {x} = {result}");
        }
    }
}
