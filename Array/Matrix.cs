using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray.Example.Algorithm.Array
{
    /// <summary>
    /// 
    /// </summary>
    class Matrix
    {
        /// <summary>
        /// 给定队伍编号：0~n-1   ??????????????
        /// 对应实力对比[x,y]=x 代表如果此两队对决，x胜，反之为y获胜
        /// 对应出场顺序order=4，3，5，8.....代表4和3对决，胜者和5与8的胜者对决
        /// 求最后的胜利者
        /// </summary>
        /// <param name="contingent"></param>
        /// <param name="strength"></param>
        /// <param name="order"></param>
        public static int GetGameResult(int[] contingent, int[,] strength, int[] order)
        {
           
            int round = order.Length;
            int step = 1;
            while(round>1)
            {
                for (int i = 0;i<round;i=i+step )
                {
                    int team = strength[order[i], order[i + step]];
                    order[i] = team;
                    order[i + step] = team;
                }
                round = round / 2;
            }
            return order[0];
        }
        /// <summary>
        /// 通过额外构建队列
        /// </summary>
        /// <param name="contingent"></param>
        /// <param name="strength"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public static int GetGameWinnerByQueue(int[] contingent, int[,] strength, int[] order)
        {
            Queue<int> queue = new Queue<int>();
            foreach (int i in order)
            {
                queue.Enqueue(i);
            }
            while (queue.Count != 1)
            {
                Queue<int> tmp = new Queue<int>();
                while (queue.Count > 1)
                {
                    int winner = strength[queue.Dequeue(), queue.Dequeue()];
                    tmp.Enqueue(winner);
                }
                if (queue.Count == 1)
                {
                    tmp.Enqueue(queue.Dequeue());
                }
                queue = tmp;
            }
            return queue.Dequeue();

        }
        
    }
}
