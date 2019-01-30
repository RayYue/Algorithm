using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray.Example.Algorithm
{
    /// <summary>
    /// 最大公约数
    /// </summary>
    public class GreatestCommonDivisor
    {
        /// <summary>
        /// 相除法：从2开始到两个数之间小的那个截至，余数为零的就是
        /// </summary>
        /// <returns></returns>
        public static long Normal(long num1, long num2)
        {
            if (num1 == 0 || num2 == 0)
            {
                return 0;
            }
            long result = 1;
            long max = num1 > num2 ? num1 : num2;
            long min = num1 > num2 ? num2 : num1;
            for (int i = 2; i <= min; i++)
            {
                if (max % i == 0 && min % i == 0)
                {
                    result = i;
                }
            }
            return result;
        }

        /*辗转相除法又名欧几里德算法*/
        /*1:当min!=0是，用大数对小数求余，并再用小数对余数求余，直到余数为零。
         * for example：260，104
         * (1)260/104余52，104/52余0，所以余数为最后一次的被除数52.
         * */
        public static long Euclid(long num1, long num2)
        {
            if (num1 == 0 || num2 == 0)
            {
                return 0;
            }
            long max = num1 > num2 ? num1 : num2;
            long min = num1 > num2 ? num2 : num1;

            long temp;
            while (min != 0)/*利用辗除法，直到b为0为止*/
            {
                temp = max % min;
                max = min;
                min = temp;
            }
            return max;
        }
        /*
         *  1、如果An=Bn,那么An(或Bn)*Cn是最大公约数,算法结束
            2、如果An=0，Bn是最大公约数，算法结束
            3、如果Bn=0，An是最大公约数，算法结束
            4、设置A1=A、B1=B和C1=1
            5、如果An和Bn都是偶数，则An+1=An/2，Bn+1=Bn/2，Cn+1=Cn*2(注意，乘2只要把整数左移一位即可，除2只要把整数右移一位即可)
            6、如果An是偶数，Bn不是偶数，则An+1=An/2，Bn+1=Bn，Cn+1=Cn(很显然啦，2不是奇数的约数)
            7、如果Bn是偶数，An不是偶数，则Bn+1=Bn/2，An+1=An，Cn+1=Cn(很显然啦，2不是奇数的约数)
            8、如果An和Bn都不是偶数，则An+1=|An-Bn|/2，Bn+1=min(An,Bn)，Cn+1=Cn
            9、n加1，转1
         * */
        public static long Stein(long num1, long num2)
        {
            long max = num1 > num2 ? num1 : num2;
            long min = num1 > num2 ? num2 : num1;
            if (min == 0)
                return max;
            if ((max & 0x1) == 0 && (min & 0x1) == 0)            // a，b均为偶数(避免使用除法和取模运算)
                return 2 * Stein(max >> 1, min >> 1);
            else if ((max & 0x1) == 0 && (min & 0x1) != 0)       // a为偶数，b为奇数
                return Stein(max >> 1, min);
            else if ((max & 0x1) != 0 && (min & 0x1) == 0)       // a为奇数，b为偶数
                return Stein(max, min >> 1);
            else        // a，b均为奇数
                return Stein((max - min) >> 1, min);
        }

        /*更相减损法*/
        /*第一步：任意给定两个正整数；判断它们是否都是偶数。若是，则用2约简；若不是则执行第二步。
          第二步：以较大的数减较小的数，接着把所得的差与较小的数比较，并以大数减小数。继续这个操作，直到所得的减数和差相等为止。
          第三步：第一步中约掉的若干个2与第二步中等数的乘积就是所求的最大公约数。
          因为其中所说的“等数”，就是最大公约数。求“等数”的办法是“更相减损”法。所以更相减损法也叫等值算法。
         * for example:260，104
         * (1)260/2=130/2=65,104/2=52/2=26==>2*2=4
         * (2)65-26=39>26=>39-26=13<26,互换26-13=13.减数和差相等，推出。
         * (3)13*4=52
         */
        public static long Equivalent(long num1, long num2)
        {
            if (num1 == 0 || num2 == 0)
            {
                return 0;
            }
            long max = num1 > num2 ? num1 : num2;
            long min = num1 > num2 ? num2 : num1;
            long result=1;
            while (max % 2 == 0 && min % 2 == 0)
            {
                result <<=1;
                max >>= 2;
                min >>= 2;
            }
            while (max > min)
            {
                max -= min;
                if (max < min)
                {
                    long temp = max;
                    max = min;
                    min = temp;
                }
            }
            return result*=max;
        }

    }
}
