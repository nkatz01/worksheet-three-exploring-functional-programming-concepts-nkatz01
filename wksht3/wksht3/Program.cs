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
using System.Runtime;
 

namespace wksht3Solutions
{
	
	public class Program
	{
		public delegate bool Del1(string str);
		//public delegate int Del2(int i, int j);
		//public delegate string Del3(string s);
		//static Func<List<string>, string, int> removeAllstartswith = (n, s) => n.RemoveAll(i => i.StartsWith(s)==true);
		// static Func<List<string>, string, int> removeAllendsswith = (n, s) => n.RemoveAll(i => i.EndsWith(s) == true);
		//  Func<Func<string, bool>,string, string, bool> p = (strtOrEnd,  s1, s2) => Del(s2) == true;
		static Func<List<string>, string, string, int> removeAllstartsOrEndsWith = (n, s ,funcName) => n.RemoveAll(i => myStartOrEndWith(funcName, i, s) == true);
		static Func<List<string>, string, string, int> copyAllstartsOrEndsWith = (n, s, funcName) => n.Insert(i => myStartWith(funcName, i, s) == true);

		Func<IEnumerable<string>, int,bool, List<string>> filterNamesWithGivenLen = (l, n, t) => l.Where(i => i.Length = n).Select(i => myLengthRemovOrDoublr().ToList();

		static public bool myStartOrEndWith(string nameOfFunc, string s1, string s2)
		{
			Del1 strtOrEndWith;
			Delegate del = Delegate.CreateDelegate(typeof(Del1), s1, nameOfFunc);
			strtOrEndWith =(Del1) del;
			return  strtOrEndWith(s2);
		}

		static public bool myLengthRemovOrDoublr(string nameOfFunc, string s1, string s2)
		{
			Del1 strtOrEndWith;
			Delegate del = Delegate.CreateDelegate(typeof(Del1), s1, nameOfFunc);
			strtOrEndWith = (Del1)del;
			return strtOrEndWith(s2);
		}
		//static public int Applyoperator(int i, int j , string symbol)
		//	{

		//		Del2 arithmeticSymbol;
		//		Delegate del = Delegate.CreateDelegate(typeof(Del2), exp, symbol);
		//		arithmeticSymbol = (Del2)del;
		//		return arithmeticSymbol(i, j).Compile();
		//	}
		//static public string Applyoperator(string s1, string s2, string symbol)
		//{
		//	Del3 stringOperand;
		//	Delegate del = Delegate.CreateDelegate(typeof(Del3), s1, symbol);
		//	stringOperand = (Del3)del;
		//	return (s2);
		//}

		//public void applyOperator() {
		//	Func<List<T>, List<T>> addOne = n => n.Select(i => i + 1).ToList();
		//	List<int>  lsInts = new List<int> { 1, 2, 3 };
		//	List<string> lsStrs = new List<string> { "hi", "itchy", "kitchy" }; 
		//	 List<int> lsIntsProc = addOne<int>(lsInts);
		//	  List<string> lststrProc = addOne<string>(lsStrs);

		//}


		static Func<List<int>, Predicate<int>, List<int>> predTester = (n, p) => n.Where(i => p(i) == true).Select(i => i).Reverse().ToList();
		static Func<IEnumerable<string>, string, IEnumerable<string>> itemConcatenater = (n, s) => n.Select(i => i = s + i);
		static Action<List<int>> print = n => n.ForEach(i => Console.Write(" " + i.ToString()));
		Func<List<int>, List<int>> addOne = n => n.Select(i => i + 1).ToList();
		  Func<List<int>, List<int>> multiply = n => n.Select(i => i * 2).ToList();
		  Func<List<int>, List<int>> subtractOne = n => n.Select(i => i - 1).ToList();
		static Func<int, List<int>> returnList = n => Enumerable.Range(0, n).ToList();
	
		public static void Main(String[] args)
		{
			List<string> ls = new List<string>() { "Kurnelia", "Qnaki", "Geo", "Muk", "Ivan" };
			removeAllstartsOrEndsWith(ls,"eo","EndsWith");
			 Console.WriteLine("[{0}]", string.Join(",", ls));

			//string MethodName = "StartsWith";

			// Console.WriteLine(Applyoperator(1, 2, "Add"));
		
			 Console.WriteLine(addOne("hey");







			//	Del myStartsWith;
			//Delegate test1 = Delegate.CreateDelegate(typeof(Del), "abc", "StartsWith");
			// myStartsWith =(Del) test1;
			//Console.WriteLine(myStartsWith("abc"));
			//Delegate test2 = Delegate.CreateDelegate(typeof(Del), "abc", "EndsWith");

			//	Console.WriteLine(test != null);

			//foreach(MethodInfo mi in Iter(meth))
			//{
			//	Console.WriteLine(mi);
			//}
			//	 Delegate method = memb.GetValue(0) as ;
			//Console.WriteLine(meth[0].GetType());





			// 	int[] ar = { 1, 2, 3, 4, 5, 6 };
			//List<int> nums = new List<int>() { 1, 2, 3, 4 };
			//List<string> commands = new List<string>() { "ddOne"};


			//List<int> parameters = new List<int>();
			//string userInput = "";
			//int intVal;


			//while (userInput != "end")
			//{

			//	Console.Write("Enter integer or string value, press 'end' to stop: ");
			//	userInput = Console.ReadLine();
			//	if (int.TryParse(userInput, out intVal))
			//		parameters.Add(intVal);

			//}
			//userInput = "";
			//Program prg = new Program();
			//FieldInfo field;
			//List<string> funcLst = new List<string>();
			//while (userInput != "end")
			//{
			//	Console.Write("Enter function: eg 'addOne', 'multiply', 'subtractOne'; and press 'end' to stop: ");
			//	userInput = Console.ReadLine();
			//	 field = prg.GetType().GetField(userInput ,BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

			//	if (field!=null) {
			//			funcLst.Add(userInput );

			//	}
			//	else
			//	{
			//		Console.WriteLine("The command you entered is not recognised");
			//	}

			//}

			//prg.Execute(funcLst, parameters);


			//	try {
			//		FieldInfo field = prg.GetType().GetField(commands[0]);

			//	prg.Execute(commands, nums);
			//}
			//	catch (Exception Ex)
			//	{
			//		Console.WriteLine("The command you entered is not recognised");
			//	}

		}


		public void Execute(List<string> funcLst, List<int> parameters)//https://stackoverflow.com/questions/6010555/how-to-call-delegate-from-string-in-c
		{
			FieldInfo field;
			Delegate method;
			List<int> ls = new List<int>();
			foreach (string funcName in funcLst)
			{
				 
					field = this.GetType().GetField(funcName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
					method = field.GetValue(this) as Delegate;
				parameters = (List<int>)method.Method.Invoke(method.Target, new object[1] { parameters });//print(modified.ToList())IEnumerable<int>
			}
			print(parameters);



		}
		
		static IEnumerable<MethodInfo>  Iter(IEnumerable<MethodInfo> collec)
		{
			foreach (MethodInfo n in collec)
			{
			    yield return n;
			}
		}


	 
	}

 

 
}
