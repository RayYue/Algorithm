using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray.Example.Algorithm.List
{
    class Merge
    {
        public class MYLinkedListNode
        {
            public int value;
            public MYLinkedListNode next;
        }

        /// <summary>
        /// 两个排好序的链表，合成一个排好序的链表
        /// </summary>
        public static MYLinkedListNode MergeLinkedList(MYLinkedListNode a, MYLinkedListNode b)
        {
            if (a == null) return b;
            if (b == null) return a;
            MYLinkedListNode c;
            if (a.value > b.value)
            {
                c = a;
                a = a.next;
            }
            else
            {
                c = b;
                b = b.next;
            }
            while (a != null && b != null)
            {
                if (a.value > b.value)
                {
                    c.next = a;
                    a = a.next;
                }
                else
                {
                    c.next = b;
                    b = b.next;
                }
                c = c.next;
            }
            if (a != null)
            {
                c.next = a;
            }
            else if (b != null)
            {
                c.next = b;
            }
            return c;

        }
    }
}
