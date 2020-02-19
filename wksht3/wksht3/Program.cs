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
	

		static Func<List<int>, Predicate<int>, List<int>> predTester = (n, p) => n.Where(i => p(i) == true).Select(i => i).Reverse().ToList();

		static Func<IEnumerable<string>, string, IEnumerable<string>> itemConcatenater = (n, s) => n.Select(i => i = s + i);
		static Action<List<int>> print = n => n.ForEach(i => Console.Write(" " + i.ToString()));
		Func<List<int>, List<int>> addOne = n => n.Select(i => i + 1).ToList();
		Func<List<int>, List<int>> multiply = n => n.Select(i => i * 2).ToList();
		Func<List<int>, List<int>> subtractOne = n => n.Select(i => i - 1).ToList();

		static Func<int, List<int>> returnList = n => Enumerable.Range(0, n).ToList();
		//Func<IEnumerable<int>, IEnumerable<int>>(fctrs,n) => fctrs.Where(i => n).Select(i => i).Reverse().ToList()

		public static void Main(String[] args)
		{

		//	predClass<int,int> pc = new predClass();
			//	int[] ar = { 1, 2, 3, 4, 5, 6 };
			Predicate<List<int>> pred = (n) => n.Where(i => i < 5).Select(i => i).ToList();
			List<int> fctrs = new List<int>{ 1, 2, 3, 4, 5, 6 };
			List<int> dividends = Program.returnList(10);
			//Console.WriteLine(ls.FindAll(i => pred(i) == true));
			//List<int> newls = ls.FindAll(i => pred(i) == true).Where(i => i< 5).Select(i => i).ToList();
			dividends.FindAll(pred(fctrs));
			IEnumerable<int> newls = dividends.FindAll(i => fctrs.TrueForAll() == true).Where(i => i < 5).Select(i => i).ToList();

			Console.WriteLine("[{0}]", string.Join(",", newls));
		}




		static IEnumerable<int>  Iter(IEnumerable<int> collec)
		{
			foreach (int n in collec)
			{
			    yield return n;
			}
		}

	 
	}

	//class predClass<T, U> {
	//	T A { get; set; }
	//	U B { get; set; }
	//	public predClass(T t, U u) {
	//		A = t;
	//		B = u;
	//	}
	//}

 
}
