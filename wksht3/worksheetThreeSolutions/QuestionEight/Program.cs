using System;
using System.Collections.Generic;

namespace QuestionEight
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ar = { 1, 2, 3, 4, 5, 6 };

            Array.Sort(ar, new mySorter());
            Console.WriteLine("[{0}]", string.Join(",", ar));//https://stackoverflow.com/questions/35394754/how-to-use-a-custom-comparer-to-sort-an-array-in-a-different-lexical-order

        }
    }
    class mySorter : IComparer<int>
    {

        public int Compare(int i, int j)
        {
            if (i == j)
                return 0;
            else if (i % 2 == 0 && j % 2 != 0 || i % 2 == 0 && j % 2 == 0 && i < j || i % 2 != 0 && j % 2 != 0 && i < j)
                return -1;
            else return 1;
        }

    }
}
