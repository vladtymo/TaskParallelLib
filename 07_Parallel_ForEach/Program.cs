using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _07_Parallel_ForEach
{
    class Program
    {
        static Random rnd = new Random();
        public class Author
        {
            public string Name { get; set; }
            public int[] ratings;
            public Author(string name = "no name")
            {
                Name = name;
                ratings = new int[5]
                {
                    rnd.Next(6),
                    rnd.Next(6),
                    rnd.Next(6),
                    rnd.Next(6),
                    rnd.Next(6)
                };
            }
        }
        static void Main(string[] args)
        {
            //var list = new List<int>() { 1, 3, 5, 8 };

            //Parallel.ForEach(list, Factorial);

            List<Author> authors = new List<Author>()
            {
                new Author("William"),
                new Author("Roberto"),
                new Author("Harry"),
                new Author("William"),
                new Author("Roberto"),
                new Author("Harry"),
                new Author("Roberto"),
                new Author("William"),
                new Author("Roberto"),
                new Author("William")
            };

            Parallel.ForEach(authors, AverageRating);

            //foreach (var a in authors)
            //{
            //    AverageRating(a);
            //}

            DateTime start = DateTime.Now;
            ParallelLoopResult result = Parallel.ForEach<Author>(authors, AverageRating);

            if (result.IsCompleted)
            {
                Console.WriteLine("Duration: " + (DateTime.Now - start).TotalSeconds);
                Console.WriteLine("All Tasks had comple ted!");
            }

            Console.ReadLine();
        }

        static void AverageRating(Author author)
        {
            var avg = author.ratings.Average();
            Thread.Sleep(3000);
            Console.WriteLine($"Author {author.Name} average rating = {avg}");
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
