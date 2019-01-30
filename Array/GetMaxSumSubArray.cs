using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray.Example.Algorithm.Array
{
    class GetMaxSumSubArray
    {
        /// <summary>
        /// 求数组中子数组的和为最大的子数组，并输出该子数组
        /// 
        /// 当和为负时，说明前面的结果对后面的结果作用为负，抛弃
        /// 当加的下一项会将当前结果减小时，不更新max
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int GetMaxSumSubArray_1(int[] array)
        {
            int sum = 0; int max = 0;
            int cur = 0;
            while(cur<array.Length)
            {
                sum += array[cur++];
                if (sum > max)
                {
    
                    max = sum;
                }
                else if (sum < 0) { sum = 0; }
            }
            return max;
        }
    }
}
