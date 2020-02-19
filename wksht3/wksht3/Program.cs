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
			int[] ar = { 1, 2, 3, 4, 5, 6 };

			//mySorter ms = new mySorter();
			Array.Sort(ar, new mySorter());
			//Console.Write(ms.Compare(2,1));
			Console.WriteLine("[{0}]", string.Join("," ,ar));
		}
		static IEnumerable<int>  Iter(IEnumerable<int> collec)
		{
			foreach (int n in collec)
			{
			    yield return n;
			}
		}

	 
	}

	class mySorter : IComparer<int>
	{

		public int Compare(int i, int j)
		{
			if (i == j)
				return 0;
			else if (i % 2 == 0 && j % 2 != 0 || i % 2 == 0 && j % 2 == 0 && i < j || i % 2 != 0 && j % 2 != 0 && i < j)
				return  -1;
			else return 1;
		}

	}
}
