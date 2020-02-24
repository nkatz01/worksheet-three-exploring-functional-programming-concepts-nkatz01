using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestionNine
{
    class Program
    {      static   Func<int, List<int>, bool> pred = (d, fctrs) => fctrs.TrueForAll(f => d % f == 0);
        static Func<int, List<int>> returnList = n => Enumerable.Range(0, n).ToList();
        static void Main(string[] args)
        {
            List<int> dividends = Program.returnList(11);
            List<int> fctrs = new List<int> { 1, 1, 1, 2 };
            IEnumerable<int> newlst = dividends.FindAll(i => pred(i, fctrs) == true);
            Console.WriteLine("[{0}]", string.Join(",", newlst));
        }
    }
}
