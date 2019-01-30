using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray.Example.Algorithm.List
{
    class RevertLinkedList
    {
        public class MYLinkedListNode
        {
            public int value;
            public MYLinkedListNode next;
        }
        /// <summary>
        ///  revert linked list on original
        /// </summary>
        /// <param name="ll"></param>
        public static void Revert(MYLinkedListNode ll)
        {
            MYLinkedListNode current = ll.next;
            MYLinkedListNode pre = ll;
            MYLinkedListNode next = null;

            ll.next = null;
            while (current.next != null)
            {
                next = current.next;
                current.next = pre;
                pre = current;
                current = next;
            }
            current.next = pre;
        }
    }
}

