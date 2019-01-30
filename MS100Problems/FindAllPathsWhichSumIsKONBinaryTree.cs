using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray.Example.Algorithm.MS100Problems
{
    class FindAllPathsWhichSumIsKONBinaryTree
    {
        public class BinaryTree
        {
            public int value;
            public BinaryTree left;
            public BinaryTree right;
        }

        public static void GetAllPathWhichSumIsK(BinaryTree tree, int k)
        {
            IList<string> list = new List<string>();
            list.Add("");
            Helper(tree, k, list, 0);
        }
        private static void Helper(BinaryTree tree, int sum,IList<string> list, int top)
        {
            sum-=tree.value;
            list[top] += "," + tree.value;
            if(tree.left==null && tree.right==null)
            {
                if (sum == 0) list[top]+=".";
            }
            else
            {
                top++;
                if (tree.left != null) Helper(tree.left, sum, list, top);
                if (tree.right != null) Helper(tree.right, sum, list, top);
            }
            top--;
            sum += tree.value;
        }
    }
}
