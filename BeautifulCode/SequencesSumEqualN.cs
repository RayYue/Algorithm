using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray.Example.Algorithm.BeautifulCode
{
    /// <summary>
    /// 问题：输出所有和为Num的连续正整数数列
    /// </summary>
    /// <remarks>
    /// 解题：任意自然数序列其实是公差为1的等差数列
    /// 即输入15： 1+2+3+4+5， 4+5+6， 7+8
    /// 数列前n项和公式有a1*n +n*(n-1)/2 = Sn ==> a1必定在集合【1，Num/2】
    /// n*n+(2a1-1)n-2input = 0
    /// </remarks>
    public class SequencesSumEqualN
    {

        public static IDictionary<int, string> Solution(int num)
        {
            IDictionary<int, string> dict = new Dictionary<int, string>();
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < num / 2; i++)
            {
                int sum = (2 * i - 1) * (2 * i - 1) + 8*num;
                double tmp = Math.Sqrt(1.0 * sum);
                if (tmp != (int)tmp)
                    continue;

                sum = 1 - 2 * i + (int)tmp;
                if (sum % 2 == 0 && sum > 0)
                {
                    sb.Clear();
                    for (int j = 0; j < sum / 2; j++)
                    {
                        sb.Append((i + j).ToString());
                        sb.Append(",");
                    }
                    dict.Add(i, sb.ToString());
                }
            }
            return dict;
        }
    }
}
