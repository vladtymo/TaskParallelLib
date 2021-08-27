using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Parallel_Break
{
    /* ParallelLoopResult
     * IsCompleted          : определяет, завершилось ли полное выполнение параллельного цикла
     * LowestBreakIteration : возвращает индекс, на котором произошло прерывание работы цикла
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            ParallelLoopResult result = Parallel.For(1, 10, Factorial);

            if (!result.IsCompleted)
                Console.WriteLine($"Выполнение цикла завершено на итерации {result.LowestBreakIteration}");
            else
                Console.WriteLine("All iteration ended.");
            Console.ReadLine();
        }
        static void Factorial(int x, ParallelLoopState pls)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
                if (i == 5)
                    pls.Break();
            }
            Console.WriteLine($"Task executing {Task.CurrentId}");
            Console.WriteLine($"Факторіал числа {x} = {result}");
        }
    }
}
