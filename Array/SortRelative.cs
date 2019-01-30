using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray.Example.Algorithm.Array
{
    class SortRelative
    {
        /// <summary>
        /// 将数组中重复数字去掉并按递减排列
        /// 比如：{9，4，3，2，5，4，3，2} => {9,5,4,3,2}
        /// </summary>
        /// <param name="ary"></param>
        /// <returns></returns>
        public static int[] GetNoDuplicatedSortedArray(int[] ary)
        {
            int[] result = new int[ary.Length];
            int dsl = 0;
            int lastdsl = 0;
            for (int i = 0; i < ary.Length;i++ )
            {
                int s = 0;
                int t = dsl - 1;
                while(s<=t)
                {
                    int m = s + (t - s) / 2;
                    if (result[m] < ary[i])
                    {
                        t = m - 1;
                    }
                    else
                    {
                        s = m + 1;
                    }
                }
                result[s] = ary[i];
                if (s > dsl) { dsl = s; lastdsl = i; }
            }
            for (int i = lastdsl - 1, j = dsl - 1; i >= 0 && j >= 0; j++)
            {
                if (ary[i] == result[j])
                {
                    j--;
                }
                else if(ary[i]<result[j])
                {
                    result[j--] = ary[i];
                }
            }
            return result;
        }

        /// <summary>
        /// 某数组由递减数组左移若干位形成，求左移的位数
        /// 比如：{4,3,2,1,6,5}是由{6,5,4,3,2,1}左移而成
        /// 
        /// 解决方法：
        ///     由于是递减序列，从尾部开始向前，每一个值与数组头值比较，当出现不比头值大时，几位所求位置
        /// </summary>
        /// <param name="ary"></param>
        /// <returns></returns>
        public static int GetCrisisInSortedArray(int[] ary)
        {
            int position=ary.Length-1;
            while(ary[position] > ary[0])
            {
                position--;
            }
            return ary.Length - position;
        }

        /// <summary>
        /// 如上述，数组是有序数组(递减)左移若干位形成的，现在需要在数组中寻找指定的数的位置
        /// 
        /// 解决方法：
        ///     该数组的最后一位或者第一位和num比较，决定了num可能在哪半个数组里面，然后根据上面求出左移的位数，
        ///     从而得到折半查找的起始或终止位置。
        /// </summary>
        /// <param name="ary"></param>
        /// <returns></returns>
        public static int GetItemFromSortedMovingArray(int[] ary, int num)
        {
            int position = ary.Length - 1;
            while (ary[position] > ary[0])
            {
                position--;
            }
            if (num > ary[0])
            {
                int tail = ary.Length-1;
                int start = position;
                while (start < tail)
                {
                    int mid = (tail - start) / 2;
                    if (ary[start] == num) return start;
                    else if (ary[tail] == num) return tail;
                    else if (ary[mid] == num) return mid;
                    
                    if (ary[tail] < num && num < ary[mid])
                        start = mid-1;
                    else if (ary[mid] < num && num < ary[start])
                        tail = mid+1;
                    else
                        throw new Exception();

                }
                
            }
            else if (num < ary[0])
            {
                int tail = position;
                int start = 0;
                while (start < tail)
                {
                    int mid = (tail - start) / 2;
                    if (ary[start] == num) return start;
                    else if (ary[tail] == num) return tail;
                    else if (ary[mid] == num) return mid;
                    
                    if (ary[tail] < num && num < ary[mid])
                        start = mid - 1;
                    else if (ary[mid] < num && num < ary[start])
                        tail = mid + 1;
                    else
                        throw new Exception();

                }
            }
            else
                return 0;
            throw new Exception();
        }
    }
}
