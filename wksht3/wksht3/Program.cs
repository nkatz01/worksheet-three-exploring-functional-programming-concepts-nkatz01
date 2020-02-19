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
	

		static Func<List<int>, Predicate<int>, List<int>> predTester = (n, p) => n.Where(i => p(i) == true).Select(i => i).Reverse().ToList();

		static Func<IEnumerable<string>, string, IEnumerable<string>> itemConcatenater = (n, s) => n.Select(i => i = s + i);
		static Action<List<int>> print = n => n.ForEach(i => Console.Write(" " + i.ToString()));
		Func<List<int>, List<int>> addOne = n => n.Select(i => i + 1).ToList();
		Func<List<int>, List<int>> multiply = n => n.Select(i => i * 2).ToList();
		Func<List<int>, List<int>> subtractOne = n => n.Select(i => i - 1).ToList();



		public static void Main(String[] args)
		{
			int n = 4;
			List<string> ls = new List<string>() {"Kurnelia","Qnaki","Geo","Muk","Ivan" };
			Func<IEnumerable<string>, int, List<string>> Results = (l, n) => l.Where(i => i.Length <= n).Select(i => i).ToList();
			Results(ls, n).ForEach(i => Console.Write(" " + i));
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
