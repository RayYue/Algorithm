using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray.Example.Algorithm.List
{
    /// <summary>
    /// Question：
    /// 1. 判断两个链表是否交叉
    /// 2. 返回交叉的节点
    /// 
    /// 解决思路：如果两个链表交叉，则必然链表尾节点重合 (Y-型结构)
    /// 
    /// </summary>
    public class TwoListsAreCrossed
    {
        public class LinkedListNode
        {
            public int value;
            public LinkedListNode next;
        }

        public static bool IfCrossedLists(LinkedListNode list1, LinkedListNode list2)
        {
            while (list1.next != null) list1 = list1.next;
            while (list2.next != null) list2 = list2.next;
            return list1==list2;
        }

        public static LinkedListNode GetCrossedListItem(LinkedListNode list1, LinkedListNode list2)
        {

            return new LinkedListNode();
        }
        public static bool IfCrossedListsWithCycleList(LinkedListNode list1, LinkedListNode list2)
        {
            return true;
        }

        //判断一个链表内是否有环
        //解决思路，两个指针，一个每次一步，一个每次两步，当任意一个指针为空是表明没有环。当两个指针重合时表示存在环
        //判断环开始的位置：当相遇之后，p2从头开始不是两步，而是一次一步，当和p1再重合，可判定为环开始
        // 理由：


    }
}
