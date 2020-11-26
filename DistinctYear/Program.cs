using DistinctYear.Menu;
using System;
using System.Collections.Generic;

namespace DistinctYear
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu menu = new MainMenu();
            menu.Start();
            Console.ReadKey();
        }
    }
}
