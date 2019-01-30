using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray.Example.Algorithm.MS100Problems
{
    /// <summary>
    /// ASCII value of 0~9 are 48~59
    /// </summary>
    class ConvertString2Number
    {

        public static int ConvertToLong(string str)
        {
            int factor = str.Length - 1;
            int result =0;
            foreach (char c in str)
            {
                if (c > 48 || c < 59)
                    throw new Exception();

                result += (c - 48) * Convert.ToInt32(System.Math.Pow(10,factor));
                factor--;
            }
            return result;
        }

        public static decimal ConvertToDecimal(string str)
        {
            return 0;
        }
    }
}
