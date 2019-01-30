using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray.Example.Algorithm.String
{
    class FindMaxSubstring
    {
        /// <summary>
        /// 给定一个字符串，返回最长的重复字串
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public static string GetMaxRepeatSubstring(string str)
        {
            return null;
        }
        /// <summary>
        /// 给定一个字符串，包含连续的数字，请给出最大的连续的数字字串
        /// 比如abc123dasdf12adf125451adasf,返回125451
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetMaxContinuousSubString(string str)
        {
            int output = 0, position = 0;
            int len = 0, max = 0;
            while (position < str.Length)
            {
                if (str[position] >= '0' && str[position] <= '9')
                {
                    len++;
                }
                else
                {
                    if (len > max)
                    {
                        max = len;
                        output = position - max;
                    }
                    len = 0;
                }
                position++;
            }
            return str.Substring(output, max);
        }
    }
}
