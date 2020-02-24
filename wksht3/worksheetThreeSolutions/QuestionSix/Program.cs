using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
namespace QuestionSix
{
    class Program
    {
		static Expression<Func<int, int, bool>> isDivisable = (dvdnd, dvsr) => dvdnd % dvsr == 0;

		static void Main(string[] args)
        {
			int[] arr = { 1, 2, 3, 4, 5, 6 };
			Console.WriteLine("{0}", string.Join(",", removeDivisablesAndReverse(arr, 2)));
		}

		static IEnumerable<int> removeDivisablesAndReverse(IEnumerable<int> arr, int divisor)
		{
			Func<int, int, bool> deleg = Program.isDivisable.Compile();

			IEnumerable<int> Results =
				from i in arr
				where deleg(i, divisor) == false
				select i;

			return Results.Reverse();
		}

	}
}
