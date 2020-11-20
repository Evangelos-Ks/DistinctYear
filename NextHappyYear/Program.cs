using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextHappyYear
{
    //Given a year, Find The next distinct year or the closest year 
    //Distinct year is the year with only distinct digits , (e.g) 2018
    //Year Of Course is always Positive .
    //Input Year with in range(1000  ≤  y ≤  9800)
    class NextHappyYear
    {
        static void Main()
        {
            int examples = 10000;
            int runTimes = 10;

            DistinctYear happyYear = new DistinctYear();
            Random random = new Random();
            List<int> a = new List<int>();

            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < examples; i++)
            {
                a.Add(random.Next(1000, 9800));
            }
            watch.Stop();
            Console.WriteLine($"Generate Time: {watch.ElapsedMilliseconds} ms");

            if (!watch.IsRunning)
                watch.Restart();

            for (int i = 0; i < runTimes; i++)
            {
                foreach (short item in a)
                {
                    happyYear.FindNext(item);
                }
            }
            watch.Stop();


            Console.WriteLine($"Execution Time for {examples} examples: {watch.ElapsedMilliseconds / runTimes } ms");
            Console.ReadKey();
        }
    }

    public class DistinctYear
    {
        public short FindNext(short year)
        {
            string yearStr = Convert.ToString(year);
            int yearLength;
            string newYear;
            int[] digits;
            bool thereIsDouble;
            bool containTen;
            byte distingDigits = 0;

            //Check if the passed year contains double digits
            distingDigits = (byte)yearStr.Distinct().Count();

            //if the passed year doesn't contain double digits add one year
            if (distingDigits == 4)
            {
                year += 1;
            }

            //Check if the new year contains double digits
            distingDigits = 0;
            yearStr = Convert.ToString(year);
            distingDigits = (byte)yearStr.Distinct().Count();

            //if if the new year doesn't contain double digits return it
            if (distingDigits == 4)
            {
                return year;
            }
            else
            {
                //The new year contains double digits
                do
                {
                    //in every new "do - while" comming a new year 
                    yearStr = Convert.ToString(year);
                    newYear = Convert.ToString(year);
                    yearLength = yearStr.Length;
                    digits = new int[yearLength];
                    thereIsDouble = false;

                    //take the first digit of the year
                    digits[0] = Convert.ToByte(yearStr[0].ToString());

                    for (int i = 0; i < (yearLength - 1); i++)
                    {
                        //compere the first digit with the second,third,forth after the second with the third and fourth and finaly the third with the fourth
                        for (int j = (1 + i); j < yearLength; j++)
                        {
                            if (yearStr[i] == newYear[j])
                            {
                                thereIsDouble = true;
                                //take the double digit and put it in the j = i+1 possition 
                                digits[j] = Convert.ToByte(newYear[j].ToString()) + 1;

                                //make zero the following numbers
                                for (int z = (j + 1); z < yearLength; z++)
                                {
                                    digits[z] = 0;
                                }
                            }
                            else
                            {
                                //take the double digit and put it in the j = i+1 possition 
                                digits[j] = Convert.ToByte(newYear[j].ToString());
                            }

                            //if we find a double digit we have a new year so break the loop
                            if (thereIsDouble)
                            {
                                break;
                            }
                        }
                        //assign a new year
                        newYear = string.Concat(digits);

                        //if we find a double digit we have a new year so break the loop and go to the beginning
                        if (thereIsDouble)
                        {
                            break;
                        }
                    }

                    //if any digit is bigger than 10 we must change it
                    if (digits.Any(d => d >= 10))
                    {
                        do
                        {
                            containTen = false;

                            for (int i = 0; i < yearLength; i++)
                            {
                                if (digits[i] >= 10)
                                {
                                    containTen = true;
                                    //make the 10 digit equal to 0
                                    digits[i] = 0;
                                    //add 1 to the previous digit
                                    digits[i - 1] += 1;
                                }
                            }
                            //check again util there are no digits bigger than 10
                        } while (containTen);

                        //assign a new year
                        newYear = string.Concat(digits);
                    }

                    //make the new year int and assign it to the year
                    year = Convert.ToInt16(newYear);

                    //run until there is no double digit
                } while (thereIsDouble);
            }
            //return the year
            return year;
        }
    }
}
