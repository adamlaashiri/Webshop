using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop
{
    class DataValidation
    {
        public static bool ValidateString(int maxLenth, string input)
        {
            if (string.Empty != input && input.Length <= maxLenth)
            {
                return true;
            }
            return false;
        }

        public static bool ValidateDecimal(string input)
        {
            if (decimal.TryParse(input, out _))
            {
                return true;
            }
            return false;
        }
    }
}
