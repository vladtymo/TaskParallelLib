using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01_Task
{
    /*
     * AsyncState : повертає об'єкт стану завдання
     * CurrentId  : повертає ідентифікатор поточного завдання
     * Exception  : повертає об'єкт виключення, що виник при виконанні завдання
     * Status     : повертає статус завдання
     */
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            Task task1 = new Task(() => Console.WriteLine($"Task 1 is executed in Thread: {Thread.CurrentThread.ManagedThreadId}"));
            task1.Start();

            // start automatically
            Task task2 = Task.Factory.StartNew(() => Console.WriteLine($"Task 2 is executed in Thread: {Thread.CurrentThread.ManagedThreadId}"));
            // start automatically
            Task task3 = Task.Run(() => Console.WriteLine($"Task 3 is executed in Thread: {Thread.CurrentThread.ManagedThreadId}"));

            Console.ReadLine();

            Task task = new Task(Display);
            task.Start();
            //task.Wait(); // waiting...

            Console.WriteLine("Завершення метода Main");

            Console.ReadLine();
        }
        
        static void Display()
        {
            Console.WriteLine("Початок роботи метода Display");
            // ...
            Console.WriteLine("Завершення роботи метода Display");
        }
    }
}
