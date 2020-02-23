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

		static Func<List<string>, string, string, string, IEnumerable<string>> DoubleOrRemove = (n, fn, condition, s) => n.Select(i =>  conditionTester(condition, i, s) == true ? i = Applyoperator(i, fn) : i=i ).ToList();
	//	static Func<List<string>, string, string, IEnumerable<string>> Remove = (n, condition, s) => n.Select(i => conditionTester(condition, i, s) == true ? i = Applyoperator(i, "Remove") : i = i).ToList();


		//static Func<List<string>, string, string, int> Remove = (n, condition, s) => n.RemoveAll(i => conditionTester(condition, i, s) == true);


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
		 
		static Func<int, List<int>> returnList = n => Enumerable.Range(0, n).ToList();
	
		public static void Main(String[] args)
		{
			List<int> nums = new List<int>() { 1, 2, 3, 4 };
			List<string> ls = new List<string>() { "Kurnelia", "Qnaki", "Geo", "Muk", "Ivan" };

			// IEnumerable<string> newls = DoubleOrRemove(ls, "Double" "Length", "5");
			//Console.WriteLine("[{0}]", string.Join(",", newls));


			//DoubleOrRemove(ls, "Remove", "Length", "5");
			//Console.WriteLine("[{0}]", string.Join(",", ls));











			//int[] ar = { 1, 2, 3, 4, 5, 6 };



			//	List<int> parameters =  ProcessDataInput<int>("Enter integer or string value, press 'end' to stop: ", "end",false); 
			// List<string> commands = Program.ProcessCommandInput<string>("Enter function: eg 'addOne', 'multiply', 'subtractOne'; and press 'end' to stop: ", "end");

			//  Program.Execute(commands, parameters, false);

			List<string> parameters = ProcessDataInput<string>("Enter name of someone who comes to the party and press 'end' to finish entering: ", "end", true);
			List<string> commands = ProcessDataInput<string>("Enter function: eg 'Double', 'Remove', followed by the condition: eg, 'StartsWith', 'EndsWith', 'Length', followed by the value: eg 'wor', 'ord' or '5', all seperated by spaces; press 'party!' to stop: ", "party!",true);
			//  Console.WriteLine("{0}", string.Join(",", parameters));
 			

			 	Program.Execute(commands, parameters, true);

			


		}

		static  public List<T> ProcessDataInput<T>(string prompt, string stopper, bool partyMode)
        {
            List<T> parameters = new List<T>();
            string userInput = "";
            int intVal;
			string[] array = { };
			while (userInput != stopper)
            {

                Console.Write(prompt);
                userInput = Console.ReadLine();
				if (!partyMode)
				{
					if (int.TryParse(userInput, out intVal))
						parameters.Add((T)(object)intVal);
				}
				else
				{
					array = userInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);
					foreach (string s in array)
					{	if (userInput!=stopper)
						parameters.Add((T)(object)s);
					}
				}
            }

            return parameters;//(T)(List<T>)(List<T>)(List<Object>)


        }

	static	public List<T> ProcessCommandInput<T>(string prompt, string stopper)
		{
			List<T> commands = new List<T>();// { "addOne" };
			string userInput = "";
			Program prg = new Program();
			FieldInfo field;
		

			while (userInput != stopper)
			{
				Console.Write(prompt);

				//T[] array1 = getOneArray();
				//T[] array2 = getAnotherArray();
				//int array1OriginalLength = array1.Length;
				//Array.Resize<T>(ref array1, array1OriginalLength + array2.Length);
				//Array.Copy(array2, 0, array1, array1OriginalLength, array2.Length);

				userInput = Console.ReadLine();
				
				//if (array.Length ==1)
				field = prg.GetType().GetField(userInput, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

				if (field != null)
				{
				 
						commands.Add((T)(object)userInput);
					 
				}
				else
				{	if (userInput != stopper)
					Console.WriteLine("The command you entered is not recognised");
				}


			}
			return commands;
		}

	static	public void Execute<T>(List<string> funcLst, List<T> parameters, bool partyMode)//https://stackoverflow.com/questions/6010555/how-to-call-delegate-from-string-in-c
		{
			FieldInfo field;
			Delegate method;
			Program program = new Program();

			if (!partyMode)
			{
				foreach (string funcName in funcLst)
				{
					field = program.GetType().GetField(funcName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
					method = field.GetValue(program) as Delegate;
					parameters = (List<T>)(object)method.Method.Invoke(method.Target, new object[1] { parameters });//print(modified.ToList())IEnumerable<int>
				}
				print((List<int>)(object)parameters);
				return;
			}

			else
			{   Console.WriteLine(funcLst.Count());
				for (int i = 3; i <= funcLst.Count(); i += 3)
				{
					//Console.WriteLine(funcLst.ElementAt(i-3));
					field = program.GetType().GetField("DoubleOrRemove", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
					method = field.GetValue(program) as Delegate;
					parameters = (List<T>)(object)method.Method.Invoke(method.Target, new object[4] { parameters, funcLst[i - 3], funcLst[i-2],funcLst[i-1] });
				}
				//print((List<string>)(object)parameters);
				parameters.RemoveAll(i => (string)(object)i == "");
				Console.WriteLine("{0}", string.Join(",", parameters));
				return;
			}

		
		}


		//static public void Execute(List<string> funcLst, List<int> parameters)//https://stackoverflow.com/questions/6010555/how-to-call-delegate-from-string-in-c
		//{
		//	FieldInfo field;
		//	Delegate method;
		//	List<int> ls = new List<int>();
		//	foreach (string funcName in funcLst)
		//	{
		//		Program program = new Program();
		//		field = program.GetType().GetField(funcName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
		//		method = field.GetValue(program) as Delegate;
		//		parameters = (List<int>)method.Method.Invoke(method.Target, new object[1] { parameters });//print(modified.ToList())IEnumerable<int>
		//	}
		//	print(parameters);



		//}

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
