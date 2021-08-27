using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _03_Task_Array
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            Task[] tasks1 = new Task[3]
            {
                new Task(() => Console.WriteLine("First Task")),
                new Task(() => Console.WriteLine("Second Task")),
                new Task(() => Console.WriteLine("Third Task"))
            };
            foreach (var t in tasks1)
                t.Start();

            Task.WaitAll(tasks1); // waiting all tasks
            Console.WriteLine("All Tasks have done!");

            Task[] tasks2 = new Task[3];

            int j = 1;
            for (int i = 0; i < tasks2.Length; i++)
                tasks2[i] = Task.Run(() => 
                {
                    Thread.Sleep(rnd.Next(5000));
                    Console.WriteLine($"Task {j++}"); 
                });

            Task.WaitAny(tasks2); // waiting any one task
            Console.WriteLine("Some Task has done!");

            Console.ReadLine();
        }
    }
}
