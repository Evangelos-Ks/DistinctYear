using System;
using System.Collections.Generic;
using System.Text;

namespace DistinctYear.Tools
{
    public class Check
    {
        public bool CheckMenuInput(string input)
        {
            if ((input == "1" || input == "2") || input == "3")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckYearInput(string input, out int inputToInt)
        {
            try
            {
                inputToInt = Convert.ToInt32(input);
            }
            catch (Exception)
            {
                inputToInt = 0;
                return false;
            }

            if (inputToInt < 10 || inputToInt > 2000000000)
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

        public bool CheckExamplesInput(string input, out int inputToInt)
        {

            try
            {
                inputToInt = Convert.ToInt32(input);
            }
            catch (Exception)
            {
                inputToInt = 0;
                return false;
            }

            if (inputToInt > 0 && inputToInt <= 2000000000)
            {
                return true;
            }
            else
            {
                inputToInt = 0;
                return false;
            }
        }

        public bool CheckRepetitionInput(string input, out int inputToByte)
        {
            try
            {
                inputToByte = Convert.ToByte(input);
            }
            catch (Exception)
            {
                inputToByte = 0;
                return false;
            }

            if (inputToByte > 0 && inputToByte <= 100)
            {
                return true;
            }
            else
            {
                inputToByte = 0;
                return false;
            }
        }

        public bool CheckMinMaxYearInput(string input, out int inputToInt)
        {
            try
            {
                inputToInt = Convert.ToInt32(input);
            }
            catch (Exception)
            {
                inputToInt = 0;
                return false;
            }

            if (inputToInt < 10 || inputToInt > 2000000000)
            {
                return false;
            }

            return true;
        }

    }
}
