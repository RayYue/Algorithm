using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray.Example.Algorithm.MS100Problems
{
    /// <summary>
    /// 计算Fibonacci的第n项
    /// F(n)=F(n-1)+f(n-2)
    /// F(0)=1
    /// F(1)=1
    /// 
    /// </summary>
    class Fibonacci
    {
        /// <summary>
        /// f(n) = f(n-1)+f(n-2)
        /// [f(n), f(n-1)] = [f(n-1)+f(n-2), f(n-1)]=[f(n-1)*+f(n-2)*, f(n-1)*+f(n-2)*0]
        /// = [f(n-1),f(n-2)]*[1,1]
        ///                   [1,0]
        ///  设定上述矩阵为A
        ///  =[f(n-1),f(n-2)]*A=[f(n-2),f(n-3)]*A*A
        ///  =[f(1),f(0)]*A的(n-1)次方，时间复杂度log2N
        ///  
        /// 效率：
        ///     递归调用效率最差。n超过100就很难算出。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long CalculateFibonacciNItemByMatrix(int n)
        {
            long[] A = new long[2] { 1, 0 };
            int[,] B = new int[2, 2] { { 1, 1 }, { 1, 0 } };
            for(int i=0;i<n;i++)
            {
               A= multiply(A, B);
            }

            return A[0];

        }
        public static long[] multiply(long[] A, int[,] B)
        {
            long[] result = new long[2];

            result[0] = A[0] * B[0,0] + A[1] * B[1,0];
            result[1] = A[0] * B[0, 1] + A[1] * B[1, 1];
            
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long CalculateFibonacciNItemByRecursion(int n)
        {
            if (n == 1 || n==0)
                return 1;
            else
                return CalculateFibonacciNItemByRecursion(n - 1) + CalculateFibonacciNItemByRecursion(n - 2);
        }
        
        public static long CalculateFibonacciNItemByIteratively(int n)
        {
            int i=2;
            long fn_1=1;
            long fn_2 = 1;
            long result = fn_1 + fn_2; 
            while (i < n)
            {
                long temp = result;
                result += fn_1;
                fn_2 = fn_1;
                fn_1 = temp;
            }
            return result;
        }


    }
}
