using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;


namespace QuestionFive
{



	public class Program
	{
		static Func<List<int>, List<int>> addOne = n => n.Select(i => i + 1).ToList();
		static Func<List<int>, List<int>> multiply = n => n.Select(i => i * 2).ToList();
		static Func<List<int>, List<int>> subtractOne = n => n.Select(i => i - 1).ToList();
		static Action<List<int>> print = n => n.ForEach(i => Console.Write(" " + i.ToString()));
		static Dictionary<string, Func<List<int>, List<int>>> mapStringToMethod = new Dictionary<string, Func<List<int>, List<int>>>(StringComparer.OrdinalIgnoreCase){
			{ "addOne",addOne },
			{"multiply", multiply },
			{"subtractOne", subtractOne }
			};

		static void Main(string[] args)
        {	
				
			  List<int> parameters = ProcessDataInput("Enter integer value, one at a time, press 'end' to stop: ", "end"); 

			  List<string> commands = ProcessCommandInput("Enter function: eg 'addOne', 'multiply', 'subtractOne'; and press 'end' to stop: ", "end");


		 
			 
		 	 Execute(commands, parameters );


		}

		static public List<int> ProcessDataInput(string prompt, string stopper)
		{
			List<int> parameters = new List<int>();
			string userInput = "";
			int intVal;
			
			while (userInput != stopper)
			{

				Console.Write(prompt);
				userInput = Console.ReadLine();
			
					if (int.TryParse(userInput, out intVal))
						parameters.Add(intVal);
				
				
			}

			return parameters;


		}

		static public List<string> ProcessCommandInput(string prompt, string stopper)
		{
			List<string> commands = new List<string>();
			string userInput = "";

			 


			 


			while (userInput != stopper)
			{
				Console.Write(prompt);

				userInput = Console.ReadLine();

				if (mapStringToMethod.ContainsKey(userInput))
				{

					commands.Add(userInput);

				}
				else
				{
					if (userInput != stopper)
						Console.WriteLine("The command you entered is not recognised");
				}


			}
			return commands;
		}

		static public void Execute(List<string> funcLst, List<int> parameters){

			List<int> results = parameters;
				foreach (string funcName in funcLst)
				{
				Func<List<int>, List<int>> method;
				mapStringToMethod.TryGetValue(funcName, out method);
				  results = method(parameters);
				}
				print(results);
				 
			

			
		}











	}

	

}
