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
        private Stopwatch watch;
        private string inputMenu;
        private bool isTheInputValid;
        private Random random;

        //============================================ Constructor =========================================================
        public MainMenu()
        {
            check = new Check();
            distinctYear = new DistinctYear();
            watch = new Stopwatch();
            random = new Random();
        }

        //============================================ Methods =============================================================
        public void Start()
        {
            bool theInputIsCorrect;

            do
            {
                theInputIsCorrect = false;
                Seperator();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\tWould you like to add a specific year or a range of random years?");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("\t1. One year");
                Console.WriteLine("\t2. Random range of years");
                Console.WriteLine("\t3. Exit");
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
                    case "1":
                        SelectOneYearMenu();
                        break;
                    case "2":
                        SelectRangeOfYearsMenu();
                        break;
                    default:
                        break;
                }
            } while (inputMenu != "3");

            Console.WriteLine();
            Console.WriteLine("\tThank you!!!");
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

        private void SelectOneYearMenu()
        {
            int inputToInt;
            string inputYear;
            int yearResult;

            do
            {
                isTheInputValid = false;
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

        private void SelectRangeOfYearsMenu()
        {
            do
            {
                string input;
                string showTheResults;
                bool validInput;
                int examplesInput;
                int repetitionInput;
                int[] examplesArray;
                int[] outputArray;

                Seperator();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\tThe valid examples that you can put are between 1 and 10000000.");
                Console.WriteLine();
                Console.WriteLine("\tThe number of times that the examples are run (repetition) that you can put are between 1 and 10.");
                Console.WriteLine("\t(This helps to take back the avarage execution time. More repetition means more accuracy)");
                Console.ForegroundColor = ConsoleColor.White;

                //Check examples input
                do
                {
                    isTheInputValid = false;
                    Console.WriteLine();
                    Console.Write("\tPlease input the random examples that you want: ");
                    input = Console.ReadLine().Trim();

                    isTheInputValid = check.CheckExamplesInput(input, out examplesInput);
                    if (!isTheInputValid)
                    {
                        WrongInputMenu();
                    }
                } while (!isTheInputValid);

                //make new arrays with the length of the examples
                examplesArray = new int[examplesInput];
                outputArray = new int[examplesInput];

                //Check repetition input
                do
                {
                    isTheInputValid = false;
                    Console.WriteLine();
                    Console.Write("\tPlease input the number of repetition: ");
                    input = Console.ReadLine().Trim();

                    isTheInputValid = check.CheckRepetitionInput(input, out repetitionInput);
                    if (!isTheInputValid)
                    {
                        WrongInputMenu();
                    }
                } while (!isTheInputValid);

                //check if the watch is running
                if (watch.IsRunning)
                {
                    watch.Restart();
                }
                else
                {
                    watch.Start();
                }

                //Generate examples
                for (int i = 0; i < examplesInput; i++)
                {
                    examplesArray[i] = random.Next(1000, 9800);
                }
                watch.Stop();

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"\tGenerate time of {examplesInput} examples: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{watch.ElapsedMilliseconds} ms");
                Console.WriteLine();

                //check if the watch is running
                if (watch.IsRunning)
                {
                    watch.Restart();
                }
                else
                {
                    watch.Start();
                }

                //Find the next year and asign the result in the outputArray
                for (int i = 0; i < examplesInput; i++)
                {
                    outputArray[i] = distinctYear.FindNext(examplesArray[i]);
                }
                watch.Stop();
                
                //Show the execution time
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"\tExecution time of {examplesInput} examples: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{watch.ElapsedMilliseconds/repetitionInput} ms");
                Console.WriteLine();

                //Ask if the user wants to see the results
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\tWhould you like to see the results? Yes/No");
                Console.ForegroundColor = ConsoleColor.White;
                do
                {
                    Console.WriteLine();
                    Console.Write("\tGive your answer: ");
                    showTheResults = Console.ReadLine().Trim();
                    validInput = check.CheckYesOrNO(showTheResults);
                    if (!validInput)
                    {
                        WrongInputMenu();
                    }
                } while (!validInput);

                //if the user wants to see the results
                if (showTheResults.ToLower() == "yes")
                {
                    for (int i = 0; i < examplesInput; i++)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"\t--------------- {i + 1} ---------------");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write($"\tInput : ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(examplesArray[i]);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write($"\tOutput : ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(outputArray[i]);
                    }
                }

                //Ask if the user wants to continue in this mode
            } while (AskToContinue());
        }

        private bool AskToContinue()
        {
            bool doYouWantToContinue;
            string doYouWantToContinueInput;

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
            Console.WriteLine();

            return doYouWantToContinueInput.ToLower() == "yes" ? true : false;
        }
    }
}
