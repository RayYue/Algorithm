using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray.Example.Algorithm.MS100Problems
{
    /// <summary>
    /// 在一个n个数字(0~n-1)组成的圆圈中，从0开始，每次从圆圈中删除第m个数字，求最后剩下的数字
    ///         
    ///     f(1,m)=0 (0是位置，因为只有一个数，所以返回位置0的数字)
    ///     f(2,m)={f(1,m)+m}%n
    /// 
    /// 变种：从k开始
    /// </summary>
    class DeleteNumbersUntilOneInCircle
    {
        /// <summary>
        /// 
        /// f(n,m)=[f(n-1,m)+m]%n
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static int GetLastOne(int n, int m)
        {
            int fn=0;
            for (int i=2; i<=n; i++) 
            {
                fn = (fn+m)%i; 
            }
            return fn;
        }

        public static int GetLastOneByStupid(int n, int m)
        {
            int[] arr = new int[n];
            for (int i = 1; i <= n; i++)
            {
                arr[i - 1] = i;
            }
            int count = n;
            int point = 0;
            int pointMove = m - 1;
            while (count > 1)
            {
                if (arr[point] != 0 && pointMove == 0)
                {
                    arr[point] = 0;
                    point = point == arr.Length - 1 ? 0 : point++;
                    pointMove = m - 1;
                    count--;
                }
                else if (arr[point] != 0 && pointMove > 0)
                {
                    point = point == arr.Length - 1 ? 0 : point++;
                    pointMove--;
                }
                else
                {
                    point = point == arr.Length - 1 ? 0 : point++;
                }
            }
            foreach (int i in arr)
                if (i != 0)
                    return i - 1;
            return 0;
        }

        public static int GetLastOneByLinkedList(int n, int m)
        {
            LinkedList<int> ll = new LinkedList<int>();
            for (int i = 0; i < n; i++)
            {
                ll.AddLast(i);
            }
            LinkedListNode<int> current = ll.First;
            LinkedListNode<int> head = current;
            int count = m - 1;
            while (ll.Count > 1)
            {
                if (count > 0 && current.Next != null)
                {
                    current = current.Next;
                    count--;
                }
                else if (count > 0 && current.Next == null)
                {
                    current = head;
                    count--;
                }
                else if (count == 0 && current.Next != null)
                {
                    if (current == head)
                        head = current.Next;
                    LinkedListNode<int> tmp = current.Next;
                    ll.Remove(current);
                    current = tmp;
                    count = m - 1;
                }
                else if (count == 0 && current.Next == null)
                {
                    ll.Remove(current);
                    current = head;
                    count = m - 1;
                }
            }
            return ll.First.Value;
        }
    }
}
