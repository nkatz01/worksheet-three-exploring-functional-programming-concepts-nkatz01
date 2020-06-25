using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
 using System.Text;
namespace QuestionTen
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
	class Program
	{
		



		public delegate bool Del1(string str);
		static Action<List<int>> print = n => n.ForEach(i => Console.Write(" " + i.ToString()));

		static Func<List<string>, string, string, string, List<string>> DoubleOrRemove = (ls, fn, condition, s) => ls.Select(s1 => conditionTester(condition, s1, s) == true ? s1 = Applyoperator(s1, fn) : s1 = s1).ToList();

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

		static public string Applyoperator(string v, string symbol)  //https://stackoverflow.com/questions/756954/arithmetic-operator-overloading-for-a-generic-class-in-c-sharp
		{
			   

						switch (symbol)
						{
							case "Remove": return  ExtClass.ModifyString( v, -1);
							case "Double": return  ExtClass.ModifyString( v, 2);
							default:
								throw new InvalidOperationException("Unknown symbol");
						}

				 

		}
		static void Main(string[] args)
		{
			List<string> parameters = ProcessDataInput("Enter name of someone who comes to the party and press 'end' to finish entering: ", "end");
			List<string> commands = ProcessDataInput("Enter function: eg 'Double', 'Remove', followed by the condition: eg, 'StartsWith', 'EndsWith', 'Length', followed by the value: eg 'wor', 'ord' or '5', all seperated by spaces; press 'party!' to stop: ", "party!");//uses same function for both, data and commands
			 Execute(commands, parameters);
		}

		static public List<string> ProcessDataInput(string prompt, string stopper)
		{
			List<string> parameters = new List<string>();
			string userInput = "";

			string[] array = { };
			while (userInput != stopper)
			{

				Console.Write(prompt);
				userInput = Console.ReadLine();


				array = userInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);
				foreach (string s in array)
				{
					if (userInput != stopper)
						parameters.Add(s);
				}

			}

			return parameters;


		}





		static public void Execute(List<string> funcLst, List<string> parameters)//https://stackoverflow.com/questions/6010555/how-to-call-delegate-from-string-in-c 
		{
			 
			for (int i = 3; i <= funcLst.Count(); i += 3)
			{

			 
 
				parameters =  DoubleOrRemove(parameters, funcLst[i - 3], funcLst[i - 2], funcLst[i - 1]);
			}
			 
			parameters.RemoveAll(i => (string)(object)i == "");
			Console.WriteLine("{0}", string.Join(",", parameters));


		}
	}
}