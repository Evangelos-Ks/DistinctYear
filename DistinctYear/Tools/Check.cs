using System;
using System.Collections.Generic;
using System.Text;

namespace DistinctYear.Tools
{
    public class Check
    {
        public bool CheckMenuInput(string input)
        {
            if (input == "1" || input == "2")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckYearInput(string input, out Int16 inputToInt)
        {
            try
            {
                inputToInt = Convert.ToInt16(input);
            }
            catch (Exception)
            {
                inputToInt = 0;
                return false;
            }

            if (inputToInt < 1000 || inputToInt > 9800)
            {
                return false;
            }

            return true;
        }

        public bool CheckYesOrNO(string input)
        {
            string inputLower = input.ToLower();
            if (inputLower == "yes" || inputLower == "no")
            {
                return true;
            }

            return false;
        }
    }
}
