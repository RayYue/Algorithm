using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray.Example.Algorithm.BeautifulCode
{
    /// <summary>
    /// 问题：给定一个十进制数N，计算比他小的正整数里所有1的个数
    /// 扩展问题：满足条件f(N)=N的数字，其中f(N)为上诉问题所诉条件
    /// </summary>
    /// <remarks>
    /// http://blog.csdn.net/zcsylj/article/details/6393315
    /// 1203
    /// 
    /// 对于百位（100-999）来说（包含了N=203）：1的个数为，
     
    /// 假设有一个正数abcde,1的总数=个位上出现1的次数+十位上出现1的次数+百位上出现1的次数+......
    /// 比如百位上的c来计算，
    /// 假若c是"1",那么百位上1的个数是由它的高位和低位来决定的。等于ab*100+cde+1;
    /// 假若c是"0",那么百位上1的个数是ab*100；
    /// 假如c是大于1，那么 百位上1的个数是（ab+1）*100；
    /// </remarks>
    public class Count1UnderNum
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>

        public static int Solution(int num)
        {
            int sum = 0;
            int low = 0; //低位数字
            int current=0; //当前数字
            int factor=1; //当前在哪位
            //从个位开始
            while (num != 0)
            {
                current = num % 10;
                num= num / 10; //高位数字
                
                if(current ==0)
                {
                    sum += num * factor;
                }
                else if(current ==1)
                {
                    sum += num * factor + low + 1;
                }
                else
                {
                    sum += (num + 1) * factor;
                }
                low = low + current * factor;
                factor *= 10;
            }

            return sum;
        }
        /// <summary>
        /// 遍历小于N的所有数，计算1出现的次数。效率很差
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int BadPerformanceSolution(int num)
        {
            int sum = 0;
            for (int i = 1; i < num; i++)
            {
                sum += CountNumber(i, 1);
            }
            return sum;
        }
        /// <summary>
        /// 计算某个数中数字出现的次数。
        /// traget必须为0~9
        /// </summary>
        /// <param name="num"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private static int CountNumber(int num, int target)
        {
            int sum=0;
            while (num != 0)
            {
                if (num % 10 == target)
                {
                    sum++;
                }
                num = num / 10;
            }
            return sum;
        }

    }
}
