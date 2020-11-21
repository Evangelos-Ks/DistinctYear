using System;
using System.Collections.Generic;
using System.Text;

namespace DistinctYear.Tools
{
    public class Check
    {
        public bool CheckInput(string input)
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
    }
}
