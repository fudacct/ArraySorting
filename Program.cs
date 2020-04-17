using System;
using System.Collections.Generic;

namespace ArraySorting
{
    class Program
    {
        /*******************
         * 有一个数组a,现在要对其进行排序。
         * 要求如下：
         * 1）无特殊情况下从大到小排序；
         * 2）若a2>0且a3=-a2，那么a3排在a2后面，但此规则只对a2后的第一个a3有效且a3尽可能靠前
         * 
         * 例子：{1,2,2,16，-5,5,4，-2，-5}排序后为{16,5，-5,4,2，-2,2,1，-5}
         *
         * 写出算法
         * *************************/
        static void Main(string[] args)
        {
            int[] array = new int[]{ 1, 2, 2, 16,-5, 5, 4,-2,-5 };
            Console.Write("原数组为：");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]+",");
            }
            Console.Write("\r\n");
            #region 向前冒泡
            for (int i = 0; i < array.Length-1; i++)
            {
                for (int j = i+1; j < array.Length; j++)
                {
                    if (array[j] > array[i])
                    {
                        int temp = array[j];
                        array[j] = array[i];
                        array[i] = temp;
                    }
                }
            }

            Console.Write("向前冒泡排序后数组为：");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + ",");
            }
            Console.Write("\r\n");
            #endregion
            #region 向后冒泡
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length-i-1; j++)
                {
                    if (array[j] < array[j+1])
                    {
                        int temp = array[j];
                        array[j] = array[j+1];
                        array[j+1] = temp;
                    }
                }
            }

            Console.Write("向后冒泡排序后数组为：");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + ",");
            }
            Console.Write("\r\n");
            #endregion
            #region 特殊情况调整数组顺序，若a2>0且a3=-a2，那么a3排在a2后面，但此规则只对a2后的第一个a3有效且a3尽可能靠前
            //将数组转为list
            List<int> list = new List<int>(array);
            Console.Write("转为list后顺序数组为：");
            foreach (var item in list)
            {
                Console.Write(item + ",");
            }
            Console.Write("\r\n");
            //根据特殊情况排序
            for (int i = 0; i < list.Count; i++)
            {
                int tempNumber = list[i];
                bool isSwitched = false;
                if (tempNumber > 0)
                {
                    for (int j = i+1; j < list.Count; j++)
                    {
                        if (tempNumber == list[j] * (-1))
                        {
                            list.Insert(i + 1, list[j]);
                            list.RemoveAt(j + 1);
                            isSwitched = true;                            
                            break;
                        }
                    }
                    if (isSwitched)
                        i++;
                }
            }

            Console.Write("特殊情况调整顺序后数组顺序为：");
            foreach (var item in list)
            {
                Console.Write(item + ",");
            }
            Console.Write("\r\n");
            #endregion

            Console.ReadKey();
        }
    }
}
