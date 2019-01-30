using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray.Example.Algorithm.StackQueue
{
    /// <summary>
    /// 设计一个栈，实现min、push和pop的时间复杂度都为o(1)
    /// 
    /// GetMin只能拿到当前stack的最小值，并不影响stack的结构。stack只能通过pop和push才能影响操作。
    /// 解决思路：增加一个min字段标记当前堆栈的最小值。每次压入堆栈时比较当前栈顶的min和压入的元素，
    ///         如果当前栈顶小，说明当前栈顶是最小元素，用此元素更新要压入栈的min字段，并压入堆栈。
    ///         如果当前栈顶大，说明要压入堆栈元素最小，用此元素值更新要压入栈的min字段，并压入堆栈。
    ///         
    /// </summary>
    public class MiniFunctionStack
    {
        public struct MinStackElement
        {
            public int value;
            public int min;
        }

        public IList<MinStackElement> data;
        public int size;
        public int top;

        public MiniFunctionStack(int maxSize)
        {
            this.data = new List<MinStackElement>(maxSize);
            this.size = maxSize;
            this.top = 0;
        }

        public void Push(MinStackElement e)
        {
            if (this.top == this.size) throw new Exception();

            e.min = this.top == 0 ? e.value : this.data[top - 1].min;
            if (e.min > e.value) e.min = e.value;
            this.data.Add(e);
            top++;
        }

        public int Pop()
        {
            if (this.top == 0) throw new Exception();
            return this.data[--this.top].value;
        }

        public int GetMin()
        {
            if (this.top == 0) throw new Exception();
            return this.data[this.top - 1].min;
        }
        
    }

    /// <summary>
    /// 设计一个栈，除了push和pop外，额外提供一个方法为minpop，每次都弹出最小的元素
    /// 
    /// 此例与上例的区别是：上例只需要得到当前栈的最小元素，不需要出栈。本例直接出栈最小元素
    /// 但本例无法实现O(1)时间复杂度
    /// </summary>
    public class MinifunctionStackWithMinPop
    {
        private Stack<int> stack = new Stack<int>();
        private Stack<int> miniStack = new Stack<int>();
    }
}
