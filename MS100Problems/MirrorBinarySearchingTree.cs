using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray.Example.Algorithm.MS100Problems
{
   
    public class MirrorBinarySearchingTree
    {
        public class BSTreeNode
        {
            public int value;
            public BSTreeNode left;
            public BSTreeNode right;
        }

        public static void Mirror(BSTreeNode node)
        {
            BSTreeNode tmp;
            if (node.left != null && node.right!=null)
            {
                tmp = node.right;
                node.right = node.left;
                node.left = tmp;
                
            }
            if (node.left != null)
                Mirror(node.left);
            if (node.right != null)
                Mirror(node.right);

        }

        public static void MirrorIteratively(BSTreeNode node)
        {
            Stack<BSTreeNode> stack = new Stack<BSTreeNode>();
            stack.Push(node);
            while(stack.Count>0)
            {
                BSTreeNode n = stack.Pop();
                BSTreeNode tmp = n.right;
                n.right = n.left;
                n.left = tmp;

                if (n.left != null)
                    stack.Push(n.left);
                if (n.right != null)
                    stack.Push(n.right);
            }
        }
    }
}
