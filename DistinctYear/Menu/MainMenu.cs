using DistinctYear.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;


namespace DistinctYear.Menu
{
    public class MainMenu
    {
        //============================================ Fields ==============================================================
        private Check check;
        private DistinctYear distinctYear;
        private Stopwatch watch = Stopwatch.StartNew();
        private short yearResult;
        private string inputMenu;
        private string inputYear;
        private bool doYouWantToContinue;
        private string doYouWantToContinueInput;



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

            Seperator();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\tWould you like to add a specific year or a range of random years?");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("\t1. One year");
            Console.WriteLine("\t2. Random range of years");
            do
            {
                //Check Input
                Console.WriteLine();
                Console.Write("\tPress the number of your choice: ");
                inputMenu = Console.ReadLine().Trim();
                theInputIsCorrect = check.CheckMenuInput(inputMenu);

                if (!theInputIsCorrect)
                {
                    WrongInputMenu();
                }

            } while (!theInputIsCorrect);
            Console.WriteLine();

            switch (inputMenu)
            {
                default:
                    SelectOneYear();
                    break;
            }









        }

        private void Seperator()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t==================================================================");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void WrongInputMenu()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\tPlease enter a valid input.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void SelectOneYear()
        {
            Int16 inputToInt;
            bool isTheInputValid;
            do
            {
                Seperator();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\tThe valid year that you can put is between 1000 and 9800.");
                Console.ForegroundColor = ConsoleColor.White;
                do
                {
                    Console.WriteLine();
                    Console.Write("\tPlease input the year: ");
                    inputYear = Console.ReadLine().Trim();

                    isTheInputValid = check.CheckYearInput(inputYear, out inputToInt);
                    if (!isTheInputValid)
                    {
                        WrongInputMenu();
                    }
                } while (!isTheInputValid);
               
                yearResult = distinctYear.FindNext(inputToInt);

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"\tInput : ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(inputToInt);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"\tOutput : ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(yearResult);
                Console.WriteLine();
            } while (AskToContinue());
        }

        private bool AskToContinue()
        {
            Seperator();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (inputMenu == "1")
            {
                Console.WriteLine("\tWould you like to try another year? Yes/No");
            }
            else
            {
                Console.WriteLine("\tWould you like to try another range of years? Yes/No");
            }
            Console.ForegroundColor = ConsoleColor.White;
            do
            {
                Console.WriteLine();
                Console.Write("\tGive your answer: ");
                doYouWantToContinueInput = Console.ReadLine().Trim();
                doYouWantToContinue = check.CheckYesOrNO(doYouWantToContinueInput);
                if (!doYouWantToContinue)
                {
                    WrongInputMenu();
                }
            } while (!doYouWantToContinue);

            return doYouWantToContinueInput.ToLower() == "yes" ? true : false;
        }
    }
}
