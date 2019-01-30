using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray.Example.Algorithm.Backtrack
{
    /*问题描述：在8*8的方格中摆放8个皇后，使其不能互相攻击：即任意两个皇后不能在同行、同列和同斜线。问有多少种摆法
     * */
    class EightQueen
    {

        const int SIZE = 8;//皇后数
        #region 解法1
  //      public static void Solution_1()
  //      {
  //          int[] Queen = new int [SIZE];//每行皇后的位置
  //          int y,x,i,j,d,t=0;
  //          y = 0;
  //          Queen[0] = -1;
  //          while( true )
  //          {
  //              for (x=Queen[y]+1; x

  //{

  //for (i=0;i

  //{

  //j = Queen[i];

  //d = y-i;

  ////检查新皇后是否与以前的皇后能相互攻击

  //if ((j==x)||(j==x-d)||(j==x+d))

  //break;

  //}

  //if (i>=y)

  //break;//不攻击

  //}

  //if (x == SIZE) //没有合适的位置

  //{

  //if (0==y)

  //{

  ////回朔到了第一行

  //Console.WriteLine("Done");

  //break; //结束

  //}

  ////回朔

  //Queen[y]=-1;

  //y--;

  //}

  //else

  //{

  //Queen[y]=x;//确定皇后的位置

  //y++;//下一个皇后

  //if (y

  //Queen[y]=-1;

  //else

  //{

  ////所有的皇后都排完了，输出

  //Console.WriteLine("\n" + ++t +':');

  //for(i=0;i

  //{

  //for (j=0;j

  //if(Queen[i] == j)

  //Console.Write('Q');

  //else

  //Console.Write('.');

  //Console.WriteLine();

  //}

  //y = SIZE -1;//回朔

  //}

  //}

  //}

  //}
        #endregion

        #region 解法2
        //public static void Solution_2()
        //{
        //    bool[] column = new bool[SIZE + 1];//同列是否有皇后
        //    bool[] rup = new bool[SIZE * 2 + 1];//右上左下是否有皇后

        //    bool[] lup = new bool[SIZE * 2 + 1];//左上右下
        //    int[] queen = new int[SIZE + 1];//答案

        //    int num;//答案编号

        //    for(int i=0;i<=SIZE;i++)
        //    {
        //        column[i]=true;
        //    }
        //    for(int i=0;i<=2*SIZE;i++)
        //    {
        //        rup[i]=lup[i]=true;
        //    }
        //}
        //private static void backtrack(int i)
        //{
        //    if (i > 8)
        //    {
        //        showAnswer();
        //    }
        //    else
        //    {
        //        for (int j = 1; j <= 8; j++)
        //        {
        //            if (column[j] == 1 &&
        //               rup[i + j] == 1 &&
        //               lup[i - j + 8] == 1)
        //            {
        //                queen[i] = j;
        //                // 设定为占用 
        //                column[j] = rup[i + j] = lup[i - j + 8] = 0;
        //                backtrack(i + 1);
        //                column[j] = rup[i + j] = lup[i - j + 8] = 1;
        //            }
        //        }
        //    }
        //}
        //private static void showAnswer() 
        //{         num++;         
        //    System.out.println("\n解答 " + num);         
        //    for(int y = 1; y <= 8; y++) {             
        //        for(int x = 1; x <= 8; x++) {                 
        //            if(queen[y] == x) {                     System.out.print(" Q");                 }                 
        //            else {                     System.out.print(" .");                 }             }             
        //        System.out.println();         }     
        //}
        #endregion


    }
}
