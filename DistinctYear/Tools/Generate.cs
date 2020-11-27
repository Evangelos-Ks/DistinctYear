using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace DistinctYear.Tools
{
    public class Generate
    {  
        public int[] GenerateRandomExamples(int numberOfExaples, int min, int max, out long executionTime)
        {
            Stopwatch watch = new Stopwatch();
            Random random = new Random();
            int[] examples = new int[numberOfExaples];

            //Generate examples
            watch.Start();
            for (int i = 0; i < numberOfExaples; i++)
            {
                examples[i] = random.Next(min, max);
            }
            watch.Stop();


            executionTime = watch.ElapsedMilliseconds;

            return examples;
        }

        public int[] GenerateDistinctYears(int[] years, int repetition, out long executionTime)
        {
            Stopwatch watch = new Stopwatch();
            DistinctYear distinctYear = new DistinctYear();
            int numberOfYears = years.Length;
            int[] returnedYears = new int[numberOfYears];

            //Find the next year and asign the result in the outputArray
            watch.Start();
            for (int j = 0; j < repetition; j++)
            {
                if (j != 0)
                {
                    for (int i = 0; i < numberOfYears; i++)
                    {
                        distinctYear.FindNext(years[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < numberOfYears; i++)
                    {
                        returnedYears[i] = distinctYear.FindNext(years[i]);
                    }
                }
            }
            watch.Stop();


            executionTime = watch.ElapsedMilliseconds;

            return returnedYears;
        }

        public void GenerateConsoleResults(int[] examplesArray, int[] resultArray)
        {
            int numberOrRepetition = examplesArray.Length;

            for (int i = 0; i < numberOrRepetition; i++)
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
                Console.WriteLine(resultArray[i]);
            }
        }
    }
}
