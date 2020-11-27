using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistinctYear
{
    public class DistinctYear
    {
        public int FindNext(int year)
        {
            string yearStr = Convert.ToString(year);
            int yearLength = yearStr.Length;
            string newYear;
            byte[] digits;
            bool thereIsDouble;
            bool containTen;
            int distingDigits = 0;

            //Add one year
            year += 1;

            //Check if the next year contains double digits
            yearStr = Convert.ToString(year);
            distingDigits = yearStr.Distinct().Count();

            //if the next year doesn't contain double digits return it
            if (distingDigits == yearLength)
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
                    digits = new byte[yearLength];
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
                                digits[j] = (byte)(Convert.ToByte(newYear[j].ToString()) + 1);

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
                                if (digits[i] >= 10 && i != 0)
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
                    year = Convert.ToInt32(newYear);

                    //run until there is no double digit
                } while (thereIsDouble);
            }
            //return the year
            return year;
        }
    }
}
