using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray.Example.Algorithm.StackQueue
{
    class StackImplementQueue
    {
        //用两个堆栈实现队列
        // 方法：push没有变化，pop时从一个堆栈导入到另一个堆栈，输出新栈的栈顶之后从新压入原栈
        // 这里有个小技巧：
        //  假定s1为正常堆栈，s2为s1的出栈后压入顺序。则入栈总是压入是s1，出栈总是从s2出栈，当s2为空时，将s1的所有元素出栈到s2

        private Stack<int> s1,s2;

        public StackImplementQueue()
        {
            s1 = new Stack<int>();
            s2 = new Stack<int>();
        }
        public void Push(int n)
        {
            s1.Push(n);
        }
        public int GetHead()
        {
            if(s2.Count>0)
                return s2.Pop();
            if(s1.Count==0) throw new Exception();
            while(s1.Count>0)
            {
                s2.Push(s1.Pop());
            }
            return s2.Pop();
        }


    }
}
