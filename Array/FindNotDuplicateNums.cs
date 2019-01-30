using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray.Example.Algorithm.Array
{
    /// <summary>

    /// 
    /// </summary>
    class FindNotDuplicateNums
    {
        /// <summary>
        /// 一个数组内只有两个元素A\B没有重复，其他都有两个
        /// 解决思路：从第一个元素开始对数组每个元素异或得到一个结果C(相同为0，不同为1)
        /// 因为其他元素都有重复的，所以得到的结果肯定是两个元素的异或结果，其他都为0
        /// 从结果C中任取一个二进制为1，其他位为0的数D与整个数组与比较，结果为D
        /// </summary>
        /// <param name="A"></param>
        /// <param name="first"></param>
        /// <param name="second"></param>
        public static void FindTwoNum(int[] A, out int first, out int second)
        {
            int excVal = A[0];
            for (int i = 1; i < A.Length; i++)
            {
                excVal ^= A[i];
            }
            int s1 = 1;
            int s2 = excVal;
            while ((s2 & 1) == 0)
            {
                s2 >>= 1;
                s1 <<= 1;
            }
            first = excVal;
            for (int i = 0; i < A.Length; i++)
            {
                if ((s1 & A[i])==s1)
                    first ^= A[i];
            }
            second = excVal ^ first;
        }

        /// <summary>
        /// 给定一个字符串，输出第一个不重复的字符
        /// 
        /// 变异问题：
        ///     输出第一个重复的字符
        ///     输出重复次数最多的字符
        ///     
        /// 前提：假定字符都是ASCII
        /// 如果前提不成立，则需要构建hash table（查找快，空间大）或者list（查找慢，空间小）
        /// </summary>
        public static void FindFirstNoDuplicateNum(string str)
        {
        }
    }
}
