using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray.Example.Algorithm
{
    /// <summary>
    /// 关于使用位操作与使用取模操作求奇偶数的性能比较。 
    /// </summary>
    public class ModLessThanBitwise
    {

        public static bool IsEvenByBitwise(int a)
        {
            return ((a & 1) == 0);
        }

        public static bool IsOddByBitwise(int a)
        {
            return !IsEvenByBitwise(a);
        }



        public static bool IsEvenByMod(int a)
        {
            return ((a % 2) == 0);
        }

        public static bool IsOddByMod(int a)
        {
            return !IsEvenByMod(a);
        }
    }
}