using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray.Example.Algorithm.Array
{
    /// <summary>
    /// 问题: 给定无序数组S,里面存储有N个数字，从中找出第K大的数字。其中K>0.N>=K
    /// </summary>
    class Find_The_K_LargestNum
    {
        /// <summary>
        /// 部分排序(选择排序和交换排序) 时间复杂度O(N*K)
        /// </summary>
        /// <param name="array"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        /// <remarks>
        /// 如果采用快排和堆排序，时间复杂度是O(N*log2N),所以可以依据K和log2N的大小来决定采用哪种
        /// </remarks>
        public static long Solution_Sort(long[] array, int k)
        {
            
            return 0;
        }
        /// <summary>
        /// 改良快排
        /// 快排会依据随机元素X分成两部分，大于X的Sa和小于X的Sb.
        /// 如果Sa的个数>=K,则只需要返回Sa中最大K元素
        /// 如果Sa的个数小于K,则Sa+Sb中K-|Sa|就是前K个最大数
        /// O(N*log2K)
        /// </summary>
        /// <param name="array"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static long Solution_(long[] array, int k)
        {
            Random r = new Random();
            int start =0;
            int length = array.Length-1;
            while (true)
            {
                int x = r.Next(0, length);
                for (int i = start, j = length; i != j; )
                {

                }
            }
            
            return 0;
        }

        private static bool CheckInput(int n, int k)
        {
            return k > 0 && k <= n;
        }

    }

    /// <summary>
    /// 问题: 给定无序数组S,里面存储有N个数字，从中找出前K大的数字。其中K>0.N>=K
    /// </summary>
    class Find_Max_K_LargestNum
    {
        /// <summary>
        /// 循环一遍arr，取出的值和输出数组的内容对比，输出数组小则替换，否则继续
        /// O(nlogn)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int[] GetMaxKNumbersBySmallArray(int[] arr, int k)
        {
            return arr;
        }

        /// <summary>
        /// 循环n遍，每次挑选一个最大的放在数组前面,类似于排序，会影响源数组结构。
        /// o(kn)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int[] GetMaxNumbersByIterative(int[] arr, int k)
        {
            return arr;
        }

        /// <summary>
        /// 构建一个有序堆，堆的根节点是最小元素，如果当前元素比堆的根大，则替换。
        /// 此方法类似于小数组，但会减少小数组的遍历次数
        /// o(n+klogn)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int[] GetMaxNumbersByMaxHeap(int[] arr, int k)
        {
            return arr;
        }

        
    }
}
