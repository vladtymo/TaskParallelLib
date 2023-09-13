using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _04_Continuous_Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task1 = new Task(() => {
                Console.WriteLine($"Task Id: {Task.CurrentId}");
                Thread.Sleep(1000);
            });

            // автоматичний запуск завдання після завершення 1-го
            Task task2 = task1.ContinueWith(Display).ContinueWith(Display2);
            
            task1.Start();

            // чекаємо завершення 2-го завдання
            task2.Wait();
            Console.WriteLine("Main is working...");
            Console.ReadLine();
        }

        static void Display(Task prevTask)
        {
            Console.WriteLine($"Task Id: {Task.CurrentId}");
            Console.WriteLine($"Previous Task Id: {prevTask.Id}");
            Thread.Sleep(3000);
        }
        static void Display2(Task prevTask)
        {
            Console.WriteLine("Display 2");
        }
    }
}
