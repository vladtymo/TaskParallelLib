using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _09_Parallel_Cancel
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;
            Console.OutputEncoding = Encoding.UTF8;

            int number = 6;

            Task task1 = new Task(() =>
            {
                int result = 1;
                for (int i = 1; i <= number; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Операция прервана");
                        return;
                    }

                    result *= i;
                    Console.WriteLine($"Факториал числа {i} равен {result}");
                    Thread.Sleep(2000);
                }

            }, token);

            task1.Start();

            Console.WriteLine("Press any key to stop the task:");
            Console.ReadKey();
            cancelTokenSource.Cancel();

            Console.WriteLine("Press any key to stop the App");
            Console.ReadKey();
        }
    }

}
