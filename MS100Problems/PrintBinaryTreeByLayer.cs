using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray.Example.Algorithm.MS100Problems
{
    public class PrintBinaryTreeByLayer
    {
         public class BSTreeNode
         {
            public int value;
            public BSTreeNode left;
            public BSTreeNode right;
        }

        public static IList<int> PrintByLayerIteratively(BSTreeNode root)
        {
            IList<int> list = new List<int>();
            Queue<BSTreeNode> que = new Queue<BSTreeNode>();
            que.Enqueue(root);
            while (que.Count>0)
            {
                BSTreeNode n = que.Dequeue();
                list.Add(n.value);

                if (n.left != null)
                    que.Enqueue(n.left);
                if (n.right != null)
                    que.Enqueue(n.right);
            }

            return list;
        }
    }
}
