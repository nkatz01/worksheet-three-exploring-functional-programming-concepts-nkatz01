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
		//Expression<Predicate<int>> predicate = (i,n) => i % n == 0);
	

	//	static Expression<Func<int, int, bool>> composePred = (i, n) => i % n == 0;
		static Func<IEnumerable<int>, Predicate<int>, IEnumerable<int>> predTester = (n, p) => n.Where(i => p(i) == true).Select(i => i);

		static Func<IEnumerable<string>, string, IEnumerable<string>> itemConcatenater = (n, s) => n.Select(i => i = s + i);
		Action<List<int>> print = n => n.ForEach(i => Console.Write(" " + i.ToString()));
		Func<List<int>, List<int>> addOne = n => n.Select(i => i + 1).ToList();
		Func<List<int>, List<int>> multiply = n => n.Select(i => i * 2).ToList();
		Func<List<int>, List<int>> subtractOne = n => n.Select(i => i - 1).ToList();

	

		 public static void Main(String[] args)
		 {
			int[] ar = { 5, 10, 15, 20 };
			Predicate<int> predicate = (i) => i % 10 == 0;
			 
			foreach (int s in Iter(Program.predTester(ar, predicate)))
			{
				Console.Write(s);
			}

		}
		static IEnumerable<int>  Iter(IEnumerable<int> collec)
		{
			foreach (int n in collec)
			{
			    yield return n;
			}
		}



	}

}
