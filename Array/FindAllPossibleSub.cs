using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray.Example.Algorithm.Array
{
    /// <summary>
    /// 给定自然数n，m，求小于n的所有自然数中，和等于m的组合。
    /// </summary>
    class FindAllPossibleSub
    {
        #region solution 1
        public static IList<string> list = new List<string>();
        public static void GetAllPossibleSub(int n,int m)
        {
            if(m<n)
            {
                GetAllPossibleSub(m, m);
            }
            int[] aux = new int[n];
            helper(m,0,aux,n);

        }
        public static void helper(int dest, int idx, int[] aux,int n)
        {
            if (dest == 0)
                list.Add(dump(aux, n));
            if (dest <= 0 || idx == n) return;
            helper(dest, idx + 1, aux, n);
            aux[idx] = 1;
            helper(dest - idx - 1, idx + 1, aux, n);
            aux[idx] = 0;
        }
        public static string dump(int[] aux, int n)
        {
            StringBuilder sb = new StringBuilder();
            for(int i=0;i<n;i++)
                if(aux[i]>0) sb.Append((i+1)+",");
            return sb.ToString();
        }
        #endregion

        #region solution 2

        #endregion
    }
}
