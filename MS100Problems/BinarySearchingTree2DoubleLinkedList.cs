using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray.Example.Algorithm.MS100Problems
{
   
    public class BinarySearchingTree2DoubleLinkedList
    {
        public class BSTreeNode
        {
            public int value;
            public BSTreeNode left;
            public BSTreeNode right;
        }
        public class DLinkedListNode
        {
            public int value;
            public DLinkedListNode front;
            public DLinkedListNode next;
        }

        static DLinkedListNode head = null;
        public static DLinkedListNode BSTree2DlinkedList(BSTreeNode root)
        {
            DLinkedListNode current = null;

            if (root == null)
            {
                head = null;
            }
            heler(root, current);
            return head;
        }

        public static DLinkedListNode heler(BSTreeNode node, DLinkedListNode current)
        {
            if (node.left != null)
                current = heler(node.left, current);
           
            DLinkedListNode n = new DLinkedListNode();
            n.value = node.value;
            if (head == null)
            {
                head = current = n;
            }
            else
            {
                current.next = n;
                n.front = current;
                current = n;
            }

            if (node.right != null)
                current = heler(node.right, current);
            
            return current;
        }
    }
}
