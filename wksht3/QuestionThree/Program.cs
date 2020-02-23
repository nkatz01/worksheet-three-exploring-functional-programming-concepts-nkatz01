using System;
using System.Collections.Generic;
using System.Linq;
namespace QuestionThree
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 0)
            {
                if (int.TryParse(args[0], out _ )) {
                    Console.WriteLine(returnMinFrmCollec(args.Select(int.Parse).ToList()));
                }
                else
                {
                    throw new ArgumentException("input should be be integers");
                }
            }
        }
        public static Func<List<int>, int> returnMinFrmCollec = n => n.Min();

    }
}
