using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _04_Task_Result
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            ////////////////// Factorial
            Task<int> task1 = new Task<int>(() => Factorial(5)); // 5! = 1 * 2 * 3 * 4 * 5 = 120
            task1.ContinueWith(Summ);

            task1.Start();
            
            //task1.Wait();
            Console.WriteLine($"Факторіал числа 5 = {task1.Result}"); // wait until task complete

            ////////////////////// Book
            Task<Book> task2 = new Task<Book>(() =>
            {
                return new Book { Title = "Війна і мир", Author = "Л. Толстой" };
            });

            //string separator = new string('-', 10);
            //Task<Book> task2 = new Task<Book>(
            //    delegate (object obj)
            //    {
            //        Book book = obj as Book;
            //        book.Title = "Deal Souls";
            //        book.Author = "Gogol";
            //        return book;
            //    },
            //    new Book());

            task2.Start();

            Book b = task2.Result;  // ожидаем получение результата
            Console.WriteLine($"Назва книги: {b.Title}, автор: {b.Author}");

            Console.WriteLine("Main continue working...");
            Task.WaitAll(task1, task2);
        }

        static int Factorial(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
                Thread.Sleep(1000);
            }

            return result;
        }
        static int Summ(Task<int> prevTask)
        {
            int summ = prevTask.Result * 2;
            Console.WriteLine(summ);
            return summ;
        }
    }


    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public override string ToString()
        {
            return $"{Title} by {Author}";
        }
    }
}