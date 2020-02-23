using System;
using System.Linq;
using System.Collections.Generic;

namespace QuestionTwo
{
	class Program
	{
		static Func<IEnumerable<string>, string, IEnumerable<string>> itemConcatenater = (n, s) => n.Select(i => i = s + i);

		static void Main(string[] args)
		{
			args.ToList().ForEach(i => Console.WriteLine("Sir " + i.ToString()));

			////alternatively

			//foreach (string s in Iter(Program.itemConcatenater(args, "Sir ")))
			//{
			//	Console.WriteLine(s);
			//}
		}

		static IEnumerable<string> Iter(IEnumerable<string> collec)
		{
			foreach (string n in collec)
			{
				yield return n;
			}
		}

	}
}
