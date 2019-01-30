using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray.Example.Algorithm
{
    public class Reverse
    {
        /*Q1: 给定数组{1~n}，倒置为{n~1}
         Example:{1,2,3,4,5}->{5,4,3,2,1}
         * 思路：切记要除以2
         */
        public static void ReverseArrayWithAdditionalTemp(int[] array)
        {
            int temp;
            for (int i = 0; i < (array.Length / 2); i++)
            {
                temp = array[i];
                array[i] = array[array.Length - 1 - i];
                array[array.Length - 1 - i] = temp;
            }
        }
        public static void ReverseArrayWithOutAdditionalTemp(int[] array)
        {
            for (int i = 0; i < (array.Length / 2); i++)
            {
                array[i] += array[array.Length - 1 - i];
                array[array.Length - 1 - i] = array[i] - array[array.Length - 1 - i];
                array[i] = array[i] - array[array.Length - 1 - i];
            }
        }
        /*Q2_1: 给定数组{1~n}，将前m个数字移到数组尾部，其他项目前移m位 (m<n)
         Example:m=3， {1,2,3,4,5,6,7,8,9,10,11}->{4,5,,6,7,8,9,10,11,1,2,3}
         *思路1：将m个数字看成整体，就变成{123,456,789,10/11}->{456,123,789,10/11}->{456,789,123,10/11}->{456,789,10/11/3,12}
         *只需要记住最后一次移动可能不整齐。
         *这样，前面的数组元素（前n - m个元素一定满足条件）。
        
         */
        public static void ArrayMove_ON(int[] array,int m, int n)
        {
            int temp;
            for (int i = m; i < array.Length; i+=n)
            {
                if (array.Length - i > n*2)
                {
                    for (int j = 0; j < n; j++)
                    {
                        temp = array[i + j];
                        array[i + j] = array[i + j + n];
                        array[i + j + n] = temp;
                    }
                }
                else
                {
                    for (int j = 0; j < array.Length - i - m; j++)
                    {

                    }
                }
            }
        }
        /*Q2_2: 给定数组{1~n}，将前m个数字移到数组尾部，其他项目前移m位 (m<n)
        Example:m=2， {1,2,3,4,5}->{3,4,5,1,2}
         *思路2：整个数组倒置{5,4,3,2,1}。
         *       将n-m个倒置 {3,4,5,2,1}
         *       将最后m个倒置 {3,4,5,1,2} */
        public static void ArrayMoveReverse3time(int[] array,int m)
        {
            ArrayReverseWithStartAndEnd(array, 0, array.Length - 1);
            ArrayReverseWithStartAndEnd(array, 0, array.Length - m-1);
            ArrayReverseWithStartAndEnd(array, array.Length - m, array.Length - 1);
           
        }
        private static void ArrayReverseWithStartAndEnd(int[] array, int start, int end)
        {
            int temp;
            for (int i = start; i < (end-start) / 2; i++)
            {
                temp = array[i];
                array[i] = array[array.Length - 1 - i];
                array[array.Length - 1 - i] = temp;
            }
        }
       
        /*Q2_3: 给定数组{1~n}，将从m开始的x个数字后移到数组尾部，
         x之后的项目前移x-m位，移出的x-m个数字按原顺序放在数组最后 (m<x<n)
       Example:m=2，x=3 {1,2,3,4,5,6,7,8,9}->{1,5,6,7,8,9,2,3,4}
         * 思路：以x-m的数字为一组，从m开始作如下交换
         * {1,5,6,7,2,3,4,8,9}--指针从m开始2,5互换;3,6互换;4,7互换
         * {1,5,6,7,8,9,2,3,4}--指针前进x位，继续。当需要替换的数字超出数组长度时，从当前开始，
       */
        public static void ArrayMoveFromMToN(int[] array,int m,int x)
        {
            if (m > array.Length || x > array.Length || m > x)
            {
                throw new Exception();
            }
            int temp;
            for (int i = m; i < array.Length; i += x)
            {
                for (int j = 0; j < x; j++)
                {
                    temp = array[i + j];
                    if ((i + j + x) < array.Length)
                    {
                        array[i + j] = array[i + j + x];
                        array[i + j + x] = temp;
                    }
                    else
                    {

                    }

                }
            }
        }

        /*Q3: 给定数组{1~n}，将前m个数字倒置后移到数组尾部，其他项目前移m位 (m<n)
         Example:m=2， {1,2,3,4,5}->{3,4,5,3,1}
         */

        /*Q4: 给定数组{1~n}，将前m个数字后移到数组尾部，其他项目倒置后前移m位 (m<n)
        Example:m=2， {1,2,3,4,5}->{5,4,3,1,2}
        */

        
    }
}
