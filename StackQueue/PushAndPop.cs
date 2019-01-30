using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray.Example.Algorithm.StackAndQueue
{
    class PushAndPop
    {
        public static bool MatchPushAndPop(int[] push, int[] pop,int n)
        {
            Stack<int> s = new Stack<int>();
            int i1 = 0, i2 = 0;
            while (i2 < n && (s.Count == 0 || s.Peek() != pop[i2]))
            {
                if (i1 < n)
                    s.Push(push[i1++]);
                else
                    return false;
                while (s.Count > 0 && s.Peek() == pop[i2])
                {
                    s.Pop();
                    i2++;
                }
            }
            return true;

        }
    }
}
