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
		public delegate bool Del(string str);

		//static Func<List<string>, string, int> removeAllstartswith = (n, s) => n.RemoveAll(i => i.StartsWith(s)==true);
		// static Func<List<string>, string, int> removeAllendsswith = (n, s) => n.RemoveAll(i => i.EndsWith(s) == true);
	//	static Func<List<string>, string, Func<string, bool>, int> removeAllstartsOrEndsWith = (n, s,p) => n.RemoveAll(i => i.p(s) == true);

		//Func<IEnumerable<string>, int, List<string>> Results = (l, n) => l.Where(i => i.Length <= n).Select(i => i).ToList();




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
		//	Console.WriteLine(typeof(System.String.StartsWith())
			//removeAllstartswith(ls,"Kur");
			//Console.WriteLine("[{0}]", string.Join(",", ls));
 
			string MethodName = "StartsWith";
			////string	TypeName = "String";
			//String StringClass = new String("abcd");
			//Console.WriteLine(StringClass.ToString());
			//	Type.GetType("System.String");

			//Console.WriteLine("{0}", fullType);



			//field = this.GetType().GetField(funcName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
			//method = field.GetValue(this) as Delegate;
			//parameters = (List<int>)method.Method.Invoke(method.Target, new object[1] { parameters });

			// Type StringClass = "System.String".GetType();
			//MethodInfo[] MetInfo = typeof(string).GetMethods( BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance| BindingFlags.DeclaredOnly);
			// Console.WriteLine(StringClass.FullName);
			//String StringInstance = (String)Activator.CreateInstance(StringClass, "abc");
			//Delegate method = field.GetValue("abc") as Delegate;
			//bool tru = (bool)method.Method.Invoke(method.Target, new object[1] { "abcd" });


			
		bool tru =(bool)typeof(string).InvokeMember("StartsWith",BindingFlags.InvokeMethod | BindingFlags.Public |  BindingFlags.Instance,null,
				"bcd",
				new Object[1] { "abc" });

			MethodInfo  meth = typeof(string).GetMethod("EndsWith", BindingFlags.Public |     BindingFlags.Instance, null, CallingConventions.Any,new Type[] { typeof(string) },null);
			//Console.WriteLine(meth);
		 	Del myStartsWith;
			Delegate test = Delegate.CreateDelegate(typeof(Del), "abcd", meth);
			 myStartsWith =(Del) test; 
		//	Console.WriteLine(test != null);

			//foreach(MethodInfo mi in Iter(meth))
			//{
			//	Console.WriteLine(mi);
			//}
			//	 Delegate method = memb.GetValue(0) as ;
			//Console.WriteLine(meth[0].GetType());
		  Console.WriteLine( myStartsWith("abcd"));
			//	Del startsWith = new Del(typeof());

			//Delegate(string.StartsWith);

			//parameters = 




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
