using System;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
//using QuestionFive;
namespace Functions
{
	public static class ExtClass
	{
		public static string ModifyString(this string source, int multiplier)//https://stackoverflow.com/questions/532892/can-i-multiply-a-string-in-c/532912#532912
		{

			if (multiplier > 0)
			{
				StringBuilder sb = new StringBuilder(multiplier * source.Length);

				for (int i = 0; i < multiplier; i++)
				{
					sb.Append(source + ",");
				}
				sb.Remove(sb.Length - 1, 1);
				return sb.ToString();
			}
			else
			{
				return source.Replace(source, "");
				
			}

		}

	}
	public class Program
	{
		public delegate bool Del1(string str);
		static Action<List<int>> print = n => n.ForEach(i => Console.Write(" " + i.ToString()));

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
				Delegate del = Delegate.CreateDelegate(typeof(Del1), s1, nameOfCond);
				condition = (Del1)del;
				return condition(s2);
			}


		}

		public static void Main(string[] args )
		{
			

		}
		public void sayBla() {
			Console.WriteLine("blabla");
		}
		static public T Applyoperator<T>(T v, string symbol)  //https://stackoverflow.com/questions/756954/arithmetic-operator-overloading-for-a-generic-class-in-c-sharp
		{
			switch (typeof(T).Name)
			{

				case "Int32":
					{
						switch (symbol)
						{
							case "+": return (T)(object)((int)(object)v + 1);
							case "-": return (T)(object)((int)(object)v - 1);
							case "*": return (T)(object)((int)(object)v * 2);
							default:
								throw new InvalidOperationException("Unknown symbol");
						}

					}


				case "String":
					{

						switch (symbol)
						{
							case "Remove": return (T)(object)ExtClass.ModifyString((string)(object)v, -1);
							case "Double": return (T)(object)ExtClass.ModifyString((string)(object)v, 2);
							default:
								throw new InvalidOperationException("Unknown symbol");
						}

					}


				default:
					throw new InvalidOperationException("Unknown type");
			}

		}
		static public List<T> ProcessDataInput<T>(string prompt, string stopper, bool partyMode)
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
					{
						if (userInput != stopper)
							parameters.Add((T)(object)s);
					}
				}
			}

			return parameters;


		}

		static public List<T> ProcessCommandInput<T>(string prompt, string stopper, Type type)
		{
			List<T> commands = new List<T>(56);
			string userInput = "";

			var obj = Activator.CreateInstance(type);
			Type compileTimeType = obj.GetType();
			

			FieldInfo field;


			while (userInput != stopper)
			{
				Console.Write(prompt);

				userInput = Console.ReadLine();

				field = compileTimeType.GetField(userInput, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

				if (field != null)
				{

					commands.Add((T)(object)userInput);

				}
				else
				{
					if (userInput != stopper)
						Console.WriteLine("The command you entered is not recognised");
				}


			}
			return commands;
		}
		static public void Execute<T>(List<string> funcLst, List<T> parameters,  bool partyMode, Type type)//https://stackoverflow.com/questions/6010555/how-to-call-delegate-from-string-in-c 
		{
			FieldInfo field;
			Delegate method;
			var obj = Activator.CreateInstance(type);
			Type compileTimeType = obj.GetType();

			if (!partyMode)
			{
				foreach (string funcName in funcLst)
				{
					field = compileTimeType.GetField(funcName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
					method = field.GetValue(compileTimeType) as Delegate;
					parameters = (List<T>)(object)method.Method.Invoke(method.Target, new object[1] { parameters });
				}
				print((List<int>)(object)parameters);
				return;
			}

			else
			{
				field = compileTimeType.GetField("DoubleOrRemove", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
				for (int i = 3; i <= funcLst.Count(); i += 3)
				{

					method = field.GetValue(compileTimeType) as Delegate;
					parameters = (List<T>)(object)method.Method.Invoke(method.Target, new object[4] { parameters, funcLst[i - 3], funcLst[i - 2], funcLst[i - 1] });
				}

				parameters.RemoveAll(i => (string)(object)i == "");
				Console.WriteLine("{0}", string.Join(",", parameters));
				return;
			}
		}
	}
}