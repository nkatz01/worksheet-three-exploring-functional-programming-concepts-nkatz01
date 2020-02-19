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

namespace wksht3Solutions
{

	public class Program
	{

		static Func<IEnumerable<string>, string, IEnumerable<string>> itemConcatenater = (n, s) => n.Select(i => i = s + i);

		Action<List<int>> print = n => n.ForEach(i => Console.Write(" " + i.ToString()));
		Func<List<int>, List<int>> addOne = n => n.Select(i => i + 1).ToList();
		Func<List<int>, List<int>> multiply = n => n.Select(i => i * 2).ToList();
		Func<List<int>, List<int>> subtractOne = n => n.Select(i => i - 1).ToList();


		public static void Main(String[] args)
		{

			

			//string[] ls =  { "rob", "ben", "shamuel" };
			//	Program prg = new Program();
			//Console.WriteLine(Program.itemConcatenater(ls, "Mr "));
			//Console.WriteLine(ls.ToString());
			 foreach (string s in Iter(Program.itemConcatenater(args, "Sir "))) {
			Console.WriteLine(s);
			 }




		}
		static IEnumerable<string>  Iter(IEnumerable<string> collec)
		{
			foreach (string n in collec)
			{
			    yield return n;
			}
		}


	}

}
