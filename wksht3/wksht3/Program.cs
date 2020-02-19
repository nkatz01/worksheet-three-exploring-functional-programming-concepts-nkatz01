using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Data;
using System.Linq.Expressions;

namespace wksht3Solutions
{

	public class Program
	{
		//Func<Func<int, int, bool>, IEnumerable<int>> applyPredOnList = (d,l) => FindAll() d(i) == true  % n == 0);
	

		static Func<IEnumerable<int>, Predicate<int>, IEnumerable<int>> predTester = (n, p) => n.Where(i => p(i) == true).Select(i => i);

		static Func<IEnumerable<string>, string, IEnumerable<string>> itemConcatenater = (n, s) => n.Select(i => i = s + i);
		Action<List<int>> print = n => n.ForEach(i => Console.Write(" " + i.ToString()));
		Func<List<int>, List<int>> addOne = n => n.Select(i => i + 1).ToList();
		Func<List<int>, List<int>> multiply = n => n.Select(i => i * 2).ToList();
		Func<List<int>, List<int>> subtractOne = n => n.Select(i => i - 1).ToList();



		public static void Main(String[] args)
		{
			int[] ar = {1, 2,3,4,5,6};
			
			//Predicate<int> predicate = new Predicate<int>(isDivisable);

			//Console.WriteLine(deleg(10, 2) == true) ;

			foreach (int s in Iter(removeDivisablesAndReverse(ar,2)))
			{
				Console.Write(" " + s);
			}



			//foreach (int s in Iter(Program.predTester(ar, predicate)))
			//{
			//	Console.Write(s);
			//}

		}
		static IEnumerable<int>  Iter(IEnumerable<int> collec)
		{
			foreach (int n in collec)
			{
			    yield return n;
			}
		}

		static IEnumerable<int> removeDivisablesAndReverse(IEnumerable<int> arr, int divisor) {
			Func<int, int, bool> deleg = Program.isDivisable.Compile();
			 
			IEnumerable<int> Results =
				from i in arr
				where deleg(i, divisor) == false
				select i;

			return Results.Reverse();
		}

		static Expression<Func<int,int, bool>> isDivisable = (dvdnd, dvsr)  =>    dvdnd % dvsr == 0;
	}

}
