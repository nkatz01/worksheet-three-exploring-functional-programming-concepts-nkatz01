using System;
using System.Collections.Generic;
using System.Linq;
namespace QuestionFour
{
    class Program
    {
        static void Main(string[] args)
        {
			   myFilter(0, 10, n => n % 2 == 0).ToList().ForEach(i => Console.WriteLine(i.ToString()));
			  myFilter(0, 10, n => n % 2 == 1).ToList().ForEach(i => Console.WriteLine(i.ToString()));
			 
		}

		public static List<int> myFilter(int min, int max, Predicate<int> pred)
		{
			List<int> ls = new List<int>();
			int i = 0;
			if (pred(min))
			{
				for (i = min; i <= max; i += 2)
				{
					ls.Add(i);
				}
			}
			else
			{
				for (i = min + 1; i <= max; i += 2)
				{
					ls.Add(i);
				}

			}
			return ls;
		}
	}
}
