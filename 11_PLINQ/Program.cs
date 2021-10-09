using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_PLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, };

            //var factorials = from n in numbers.AsParallel()
            //                 where n > 0
            //                 //orderby n
            //                 select Factorial(n);

            var factorials = numbers.AsParallel()
                                    .AsOrdered()
                                    .Where(n => n > 0);
                                    //.Select(n => Factorial(n));

            //var query = from n in factorials.AsUnordered()
            //            where n > 100
            //            select n;

            //var query = factorials.AsUnordered().Where(n => n > 100);

            var watch = System.Diagnostics.Stopwatch.StartNew();

            foreach (var n in factorials)
                Console.WriteLine(n);

            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms\n");

            //foreach (var n in query)
            //    Console.WriteLine("\t\t" + n);

            Console.Read();
        }
        static int Factorial(int x)
        {
            //Random r = new Random();
            //for (int i = 0; i < 10_000_000; i++)
            //{
            //    r.Next();
            //    r.GetHashCode();
            //    r.NextDouble();
            //}
            int result = 1;

            //for (int i = 1; i <= x; i++)
            //{
            //    result *= i;
            //}
            return result;
        }

        static int HardWork(int x)
        {
            int f = Factorial(x);
            using (FileStream fs = new FileStream($"test_{x}.txt", FileMode.Create, FileAccess.Write))
            {
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine($"Factorial of {x} = {f}\n");

                StreamReader sr = new StreamReader("Lorem.txt");
                while (!sr.EndOfStream)
                {
                    sw.WriteLine(sr.ReadLine());
                }
                sr.Close();
                sw.Close();
            }
            return f;
        }
    }
}
