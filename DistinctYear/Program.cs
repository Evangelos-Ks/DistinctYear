using DistinctYear.Menu;
using System;
using System.Collections.Generic;

namespace DistinctYear
{
    class Program
    {
        static void Main(string[] args)
        {
            //Given a year, Find The next distinct year or the closest year 
            //Distinct year is the year with only distinct digits , (e.g) 2018
            //Year Of Course is always Positive .
            //Input Year with in range(1000  ≤  y ≤  9800)
            MainMenu menu = new MainMenu();
            menu.Start();

            
            //int examples = 10000;
            //int runTimes = 10;

            //DistinctYear distinctYear = new DistinctYear();
            //Random random = new Random();
            //List<int> a = new List<int>();

            //var watch = System.Diagnostics.Stopwatch.StartNew();
            //for (int i = 0; i < examples; i++)
            //{
            //    a.Add(random.Next(1000, 9800));
            //}
            //watch.Stop();
            //Console.WriteLine($"Generate Time: {watch.ElapsedMilliseconds} ms");

            //if (!watch.IsRunning)
            //    watch.Restart();

            //for (int i = 0; i < runTimes; i++)
            //{
            //    foreach (short item in a)
            //    {
            //        distinctYear.FindNext(item);
            //    }
            //}
            //watch.Stop();


            //Console.WriteLine($"Execution Time for {examples} examples: {watch.ElapsedMilliseconds / runTimes } ms");
            Console.ReadKey();
        }
    }
}
