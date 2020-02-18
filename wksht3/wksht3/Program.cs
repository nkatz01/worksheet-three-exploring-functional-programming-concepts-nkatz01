using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Reflection;
 

namespace wksht3Solutions
{
    public class Program
    {


		
		public static void Main(String[] args)
		{
			List<int> ls = new List<int>();
			string userInput = "";
			int intVal;


			while (userInput != "end")
			{

				Console.Write("Enter integer value, press 'end' to stop: ");
				userInput = Console.ReadLine();
				if (int.TryParse(userInput, out intVal))
					ls.Add(intVal);

				// Console.WriteLine("You entered  ",ls.ToString());
			}



			//List<int> funcs = new List<int>();
			//while (userInput != "end")
			//{
			//	Console.Write("Enter function: eg 'addOne', 'multiply', 'subtractOne', or 'print'; and press 'end' to stop: ");
			//	switch (userInput)
			//	{
			//		case "addOne":

			//			break;
			//		case "multiply":

			//			break;
			//		case "subtractOne":

			//			break;
			//		case "print":
			//			break;
			//		default:
			//			Console.WriteLine("Default case");
			//			break;
			//	}
			//	funct.Add(userInput)
			//}



			//ls.ForEach(i => Console.Write(" " + i.ToString()));




			//	enum Operations
			//{ 
			//	 addOne,
			//	 multiply,
			//	subtractOne,
			//	print
			//}

			Program prg = new Program();
			 
			//print(ls);
			//Func<int, int, int> addNums = (x, y) => x + y;
			//Func<int, bool> isZero = n => n == 0;


		
		 
		 

		 

			 Type ex = typeof(Example);
			 var method = ex.GetMethod("addOne");
			//MethodInfo method = ex.GetMethod("addOne");
			// tm.Invoke(this, new object[] { 1, 3, 4 });
			//object[] parametersArray = new object[] { 1};

			//	 DisplayGenericMethodInfo(method);
			//MethodInfo gm = method.MakeGenericMethod(typeof(int));
			object[] arg = { 42 };
		//	gm.Invoke(this, args);
			Console.WriteLine(method.Invoke(ex, arg));
		 
	//	object[] arr = new object[] { new object[] { input } };


		}
		
		// public static Func<List<int>, int> returnMinFrmCollec = n => n.Min();
	

    }


	public class Example {

		public List<int> numbers2 = new List<int>() { 2, 3, 5, 7 };
		public static Func<int, int> addOne = n => n + 1;
		Func<int, int> multiply = n => n * 2;
		Func<int, int> subtractOne = n => n - 1;
		Action<List<int>> print = n => n.ForEach(n => Console.Write(" " + n.ToString()));



	}
}
