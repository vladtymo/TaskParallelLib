using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _12_CancelationToken
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            new Task(() =>
            {
                Thread.Sleep(500);
                cts.Cancel();
            }).Start();

            try
            {
                int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 1, 2, 3, 4, 5, 6, 7, 8, };
                var factorials = from n in numbers.AsParallel().WithCancellation(cts.Token)
                                 select Factorial(n);

                foreach (var n in factorials)
                    Console.WriteLine(n);
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine("Operation was stoped.");
            }
            catch (AggregateException ex)
            {
                if (ex.InnerExceptions != null)
                {
                    foreach (Exception e in ex.InnerExceptions)
                        Console.WriteLine(e.Message);
                }
            }
            finally
            {
                cts.Dispose();
            }
            Console.ReadLine();
        }

        static int Factorial(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            Console.WriteLine($"Factorial {x} = {result}");
            Thread.Sleep(1000);
            return result;
        }
    }
}
