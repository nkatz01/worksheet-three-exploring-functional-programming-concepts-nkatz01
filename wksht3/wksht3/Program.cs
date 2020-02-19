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
	/* public class Example{
		List<int> numbers2 = new List<int>() { 2, 3, 5, 7 };
		  Func<int, int> addOne = n => n + 1;
		Func<int, int> multiply = n => n * 2;
		Func<int, int> subtractOne = n => n - 1;
		Action<List<int>> print = n => n.ForEach(i => Console.Write(" " + i.ToString()));
	
		
	} */
    public class Program
    {
		
	 List<int> numbers2 = new List<int>() { 2, 3, 5, 7 };
		  Func<int, int> addOne = n => n + 1;
		Func<int, int> multiply = n => n * 2;
		Func<int, int> subtractOne = n => n - 1;
		Action<List<int>> print = n => n.ForEach(i => Console.Write(" " + i.ToString()));
	
		
		public static void Main(String[] args)
		{
			/* List<int> ls = new List<int>();
			string userInput = "";
			int intVal;


			while (userInput != "end")
			{

				Console.Write("Enter integer value, press 'end' to stop: ");
				userInput = Console.ReadLine();
				if (int.TryParse(userInput, out intVal))
					ls.Add(intVal);

				// Console.WriteLine("You entered  ",ls.ToString());
			} */
			Program prg = new Program();
			prg.Fire();
		}
	public void Fire()
        {
				
 	     FieldInfo field = this.GetType().GetField("addOne", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
		Delegate method = field.GetValue(this) as Delegate;
	var val =	method.Method.Invoke(method.Target, new object[1]{10});
Console.WriteLine(val);
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




		 

			//Program prg = new Program();
			 
			//print(ls);
			 
			//Func<int, bool> isZero = n => n == 0;

/* typeof(Container)
    .GetMethod(cmd, BindingFlags.Static | BindingFlags.Public)
    .Invoke(null, new object[0]); */
		
		 
		 

		 

			  

		//}
		
		// public static Func<List<int>, int> returnMinFrmCollec = n => n.Min();
	

    }

 
}
