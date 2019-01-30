using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray.Example.Algorithm.Maths
{
    /// <summary>
    /// 因子只有1，2，3，5的数位丑数，比如6，8
    /// </summary>
    class UglyNumber
    {
        public static void test()
        {
            int[] heap = new int[4500];
            heap[0]=2;
            heap[1] = 3;
            heap[2] = 4;
            int size = 3;
            for(int i=1;i<1500;i++)
            {
                int s = heap[0];
                heap[0] = s * 2;
                siftDown(heap, 0, size);
                heap[size] = s * 3;
                siftUp(heap, size, size + 1);
                heap[size + 1] = s * 5;
                siftUp(heap, size + 1, size + 2);
                size += 2;
            }
        }
        private static void siftDown(int[] heap, int from, int size)
        {
            int c = from * 2 + 1;
            while(c<size)
            {
                if (c + 1 < size && heap[c + 1] < heap[c]) c++;
                if (heap[c] < heap[from]) swap(heap, c, from);
                from = c; 
                c = from * 2 + 1;
            }
        }
        private static void siftUp(int[] heap, int from, int size)
        {
            while(from>0)
            {
                int p = (from - 1) / 2;
                if (heap[p] > heap[from]) swap(heap, p, from);
                from = p;
            }
        }

        private static void swap(int[] heap, int a, int b)
        {
            int mid = (b - a) / 2;
            for (int i = a; i < mid; i++)
            {
                heap[i] = heap[b - a + i];
            }
        }
    }
}
