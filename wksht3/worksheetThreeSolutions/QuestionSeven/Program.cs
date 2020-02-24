using System;
using System.Collections.Generic;
using System.Linq;
namespace QuestionSeven
{
    class Program
    {
       static Func<IEnumerable<string>, int, List<string>> Results = (l, n) => l.Where(i => i.Length <= n).Select(i => i).ToList();

        static void Main(string[] args)
        {
            int n = 4;
            List<string> ls = new List<string>() { "Kurnelia", "Qnaki", "Geo", "Muk", "Ivan" };
            Results(ls, n).ForEach(i => Console.Write(" " + i));
        }
    }
}
