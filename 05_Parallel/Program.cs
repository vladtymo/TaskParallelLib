using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _05_Parallel
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.Invoke(
                Display,
                () => {
                            Console.WriteLine($"Task executing {Task.CurrentId}");
                            Thread.Sleep(3000);
                            Console.WriteLine($"Task ended  {Task.CurrentId}");
                      },
                () => Factorial(5));

            Console.ReadLine();
        }

        static void Display()
        {
            Console.WriteLine($"Task executing {Task.CurrentId}");
            Thread.Sleep(3000);
            Console.WriteLine($"Task ended {Task.CurrentId}");
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
            Console.WriteLine($"Result {result}");
        }
    }
}
