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
using System.Text;

namespace wksht3Solutions
{	
	
	
	public static class ExtClass {
		public static string ModifyString(this string source, int multiplier)//https://stackoverflow.com/questions/532892/can-i-multiply-a-string-in-c/532912#532912
		{
			
			if (multiplier > 0)
			{
				StringBuilder sb = new StringBuilder(multiplier * source.Length);

				for (int i = 0; i < multiplier; i++)
				{
					sb.Append(source+",");
				}
				sb.Remove(sb.Length-1, 1);
				return sb.ToString();
			}
			else
			{
				  return source.Replace(source, "");
			//	sb.Insert(0, "Rmoved");
			}
			
		}

	}


	public class Program
	{
		public delegate bool Del1(string str);
		
		static Func<List<int>, List<int>> addOne = n => n.Select(i => Applyoperator(i, "+")).ToList();
		static Func<List<int>, List<int>> multiply = n => n.Select(i => Applyoperator(i, "*")).ToList();
		static Func<List<int>, List<int>> subtractOne = n => n.Select(i => Applyoperator(i, "-")).ToList();

		static Func<List<string>, string, string, IEnumerable<string>> Double = (n, condition, s) => n.Select(i =>  conditionTester(condition, i, s) == true ? i = Applyoperator(i, "Double") : i=i ).ToList();


	 	static Func<List<string>, string, string, int> Remove = (n, condition, s) => n.RemoveAll(i => conditionTester(condition, i, s) == true);


		static public bool conditionTester(string nameOfCond, string s1, string s2)
		{
			int property;
 			if (int.TryParse(s2, out property))
			{
				
				return (int)typeof(string).GetProperty(nameOfCond).GetValue(s1, null) == property;
			}
			else
			{
				Del1 condition;
				Delegate del = Delegate.CreateDelegate(typeof(Del1), s1, nameOfCond );
				condition = (Del1)del;
				return condition(s2);
			}

			
		}

		 

		

		static public T Applyoperator<T>(T v, string symbol)  //https://stackoverflow.com/questions/756954/arithmetic-operator-overloading-for-a-generic-class-in-c-sharp
		{
			switch (typeof(T).Name)
			{

				case "Int32":
					{
						switch (symbol)
						{
							case "+": return (T)(object)((int)(object)v + 1) ;
							case "-": return (T)(object)((int)(object)v - 1) ;
							case "*": return (T)(object)((int)(object)v * 2 );
							default:
								throw new InvalidOperationException("Unknown symbol");
						}
					 
					}
					 
				
				case "String":
					{

						switch (symbol)
						{
 							case "Remove": return (T)(object)ExtClass.ModifyString((string)(object)v,-1 ) ;
							case "Double": return (T)(object)ExtClass.ModifyString((string)(object)v, 2 ) ;
							default:
								throw new InvalidOperationException("Unknown symbol");
						}

					}
					 

				default:
					throw new InvalidOperationException("Unknown type");
			}

		}


			


		static Func<List<int>, Predicate<int>, List<int>> predTester = (n, p) => n.Where(i => p(i) == true).Select(i => i).Reverse().ToList();
		static Func<IEnumerable<string>, string, IEnumerable<string>> itemConcatenater = (n, s) => n.Select(i => i = s + i);
		static Action<List<int>> print = n => n.ForEach(i => Console.Write(" " + i.ToString()));
		//Func<List<int>, List<int>> addOne = n => n.Select(i => i + 1).ToList();
		//  Func<List<int>, List<int>> multiply = n => n.Select(i => i * 2).ToList();
		//  Func<List<int>, List<int>> subtractOne = n => n.Select(i => i - 1).ToList();
		static Func<int, List<int>> returnList = n => Enumerable.Range(0, n).ToList();
	
		public static void Main(String[] args)
		{
			List<int> nums = new List<int>() { 1, 2, 3, 4 };
			List<string> ls = new List<string>() { "Kurnelia", "Qnaki", "Geo", "Muk", "Ivan" };
		
			// IEnumerable<string> newls = Double(ls, "Length", "5");
			//Console.WriteLine("[{0}]", string.Join(",", newls));


			Remove(ls, "Length", "5");
			Console.WriteLine("[{0}]", string.Join(",", ls));













			//	int[] ar = { 1, 2, 3, 4, 5, 6 };

			List<string> commands = new List<string>();// { "addOne" };
			List<int> parameters = new List<int>();
			string userInput = "";
			int intVal;


			while (userInput != "end")
			{

				Console.Write("Enter integer or string value, press 'end' to stop: ");
				userInput = Console.ReadLine();
				if (int.TryParse(userInput, out intVal))
					parameters.Add(intVal);

			}
			userInput = "";
			Program prg = new Program();
			FieldInfo field;
			List<string> funcLst = new List<string>();
			while (userInput != "end")
			{
				Console.Write("Enter function: eg 'addOne', 'multiply', 'subtractOne'; and press 'end' to stop: ");
				userInput = Console.ReadLine();
				field = prg.GetType().GetField(userInput, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

				if (field != null)
				{
					funcLst.Add(userInput);

				}
				else
				{
					Console.WriteLine("The command you entered is not recognised");
				}

			}

			prg.Execute(funcLst, parameters);







		}

		//	public  T[][] ProcessInput<T>() {

		//		T[][] array = commandsAndData = new Array(



		//}


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
		
		static IEnumerable<int>  Iter(IEnumerable<int> collec)
		{
			foreach (int n in collec)
			{
			    yield return n;
			}
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
