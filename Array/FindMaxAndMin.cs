using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray.Example.Algorithm.Array
{
    /// <summary>
    /// 在一个数组中查找最大最小值
    /// </summary>
    class FindMaxAndMin
    {
        /// <summary>
        /// 两个变量，遍历一遍O(n)，比较次数最好n，最坏2n
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="max"></param>
        /// <param name="min"></param>
        public static void GetMaxAndMin_Standard(int[] arr, out int max, out int min)
        {
            if (arr.Length == 0)
            {
                throw new InvalidOperationException();
            }
            max = min = arr[0];
            for (int i=0;i<arr.Length;i++)
            {
                if (arr[i] > max) max = arr[i];
                else if (arr[i] < min) min = arr[i];
            }
        }

        /// <summary>
        /// 两个变量，遍历一遍O(n),比较次数？？存疑
        /// 先将
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="max"></param>
        /// <param name="min"></param>
        public static void GetMaxAndMin_HalfCompare(int[] arr, out int max, out int min)
        {
            if (arr.Length == 0)
            {
                throw new InvalidOperationException();
            }
            max = min = arr[0];
            //判断数组元素为奇偶数：与1按位与，如果为1，说明二进制末尾为1，奇数，否则为偶数
            //来保证i+2不会越界
            int i = (arr.Length & 1)==1 ? 1 : 0;
            for (; i < arr.Length; i+=2)
            {
                if (arr[i] > arr[i + 1])
                {
                    if (arr[i] > max)
                        max = arr[i];
                    if (arr[i + 1] < min)
                        min = arr[i + 1];
                }
                else
                {
                    if (arr[i + 1] > max)
                        max = arr[i + 1];
                    if (arr[i] < min)
                        min = arr[i];
                }

            }
        }

    }
}
