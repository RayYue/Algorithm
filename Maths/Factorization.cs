using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray.Example.Algorithm.Maths
{
    class Factorization
    {
        /// <summary>
        /// 因式分解
        /// 给定正整数，输出所有和为n的连续正数序列
        /// 
        /// n=i+(i+1)+..+(j-1)+j
        /// n=(i+j)(j-i+1)/2=(j*j-i*i+i+j)/2
        /// 由于j**2+j+(i-i**2-2n)=0  => j=sqrt(i**2+1/4+2n)-1/2
        /// 且1<=i<j<=n/2+1
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Find(int n)
        {
            int count = 0;
            for (int i = 0; i <= n / 2; i++)
            {
                int sqroot = Convert.ToInt32(System.Math.Sqrt(4 * i * i + 8 * n - 4 * i + 1));
                if (sqroot == -1) continue;
                if ((sqroot & 1) == 1)
                {
                    System.Console.WriteLine(i + "-" + ((sqroot - 1) / 2));
                    count++;
                }

            }
            return count;
        }
    }
}
