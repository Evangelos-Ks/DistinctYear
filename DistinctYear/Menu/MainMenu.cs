using DistinctYear.Tools;
using System;
using System.Collections.Generic;
using System.Text;


namespace DistinctYear.Menu
{
    public class MainMenu
    {
        //============================================ Fields ==============================================================
        private Check check;
        private DistinctYear distinctYear;

        //============================================ Constructor =========================================================
        public MainMenu()
        {
            this.check = new Check();
            this.distinctYear = new DistinctYear();
        }

        //============================================ Methods =============================================================
        public void Start()
        {
            bool theInputIsCorrect;

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t==================================================================");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("\tWould you like to add a specific year or a range of random years?");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("\t1. One year");
            Console.WriteLine("\t2. Random range of years");
            Console.WriteLine();
            Console.Write("\tPress the number of your choice: ");
            do
            {
                //Check Input
                theInputIsCorrect = check.CheckInput(Console.ReadLine());
                Console.WriteLine();

                if (!theInputIsCorrect)
                {
                    WrongSelection();
                }

            } while (!theInputIsCorrect);
            Console.WriteLine();






        }

        private void WrongSelection()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\tPlease select a valid number.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.Write("\tPress the number of your choice: ");
        }

        private void SelectOneYear()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t==================================================================");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("\tThe valid years that you can put are between 1000 and 9800.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.Write("\tPlease input the year: ");
            distinctYear.FindNext(Convert.ToInt16(Console.ReadLine()));
            //TODO Menu for after input
        }
    }
}
