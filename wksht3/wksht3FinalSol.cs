using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace wksht3Solutions
{
    public class Program
    {
		static Func<IEnumerable<string>, string, IEnumerable<string>> itemConcatenater = (n, s) => n.Select(i => i = s + i);
		//releating to #5
		Action<List<int>> print = n => n.ForEach(i => Console.Write(" " + i.ToString())); 
		Func<List<int>, List<int>> addOne = n => n.Select( i => i + 1).ToList() ;
 		Func<List<int>, List<int>> multiply = n => n.Select( i => i * 2).ToList() ;
		Func<List<int>, List<int>> subtractOne = n =>n.Select( i => i - 1).ToList() ;
		
        public static void Main(String[] args)
        {

 
//question 1 (preffered)
            Action<string[]> print = delegate (string[] arr)
            {

                foreach (string str in arr)
                {

                    Console.WriteLine(str);
                }
            };

            print(args);



			// or alternatively
			//args.ToList().ForEach(i => Console.WriteLine(i.ToString()));//https://stackoverflow.com/questions/16265247/printing-all-contents-of-array-in-c-sharp

			//or (2nd alternative)
			//Array.ForEach(args, Console.WriteLine);

			//question 1 (3rd alternative)
			// Action<string[]> print = new Action<string[]>(IterateOverArrOfStrings);
			// print(args);


			//2
			// args.ToList().ForEach(i => Console.WriteLine("Sir " + i.ToString()));

			//alternatively

			//foreach (string s in Iter(Program.itemConcatenater(args, "Sir ")))
			//{
			//	Console.WriteLine(s);
			//}


//3
			/* if (args.Length!=0){
		Console.WriteLine(returnMinFrmCollec(args.Select(int.Parse).ToList()));
		} */

			//4

			myFilter(0, 10, n => n%2 == 0).ToList().ForEach(i => Console.WriteLine(i.ToString()));
	myFilter(0, 10, n => n%2 == 1).ToList().ForEach(i => Console.WriteLine(i.ToString()));
		
		
//5
			  List<int> parameters = new List<int>();
			string userInput = "";
			int intVal;


			while (userInput != "end")
			{

				Console.Write("Enter integer value, press 'end' to stop: ");
				userInput = Console.ReadLine();
				if (int.TryParse(userInput, out intVal))
					parameters.Add(intVal);

 			}  
			userInput="";
			List<string> funcLst = new List<string>();
			while (userInput != "end")
			{
				Console.Write("Enter function: eg 'addOne', 'multiply', 'subtractOne'; and press 'end' to stop: ");
				userInput = Console.ReadLine();
				if( userInput == "addOne" || userInput == "multiply" || userInput == "subtractOne" )
				{
						funcLst.Add(userInput);
				}else{
						Console.WriteLine("The command you entered is not recognised");
					 }
				 
			}
			
			
			
			
			Program prg = new Program();
				 
			prg.Execute(funcLst, parameters);

//6

			int[] ar = { 1, 2, 3, 4, 5, 6 };
			removeDivisablesAndReverse(ar, 2);
		}

		public static void IterateOverArrOfStrings(string[] arr) { 
           foreach(string str in arr) {

                   Console.WriteLine(str);
           }
        }
		
	 public static Func<List<int>, int> returnMinFrmCollec = n => n.Min();

	public static List<int> myFilter( int min,  int max, Predicate<int> pred)
		{	List<int> ls = new List<int>();
		int i=0;
			if (pred(min)){
			for(  i=min; i<=max; i+=2){
			ls.Add(i);
			}
			}
			else{
				for(i=min+1; i<=max; i+=2){
				ls.Add(i);
			}
			
			}
			return ls;
		}
		
		public void Execute(List<string> funcLst, List<int> parameters  )//https://stackoverflow.com/questions/6010555/how-to-call-delegate-from-string-in-c
        {  FieldInfo field   ;
			 Delegate method  ;
			List<int> ls = new List<int>();
			foreach(string funcName in funcLst){
			
 	       field = this.GetType().GetField(funcName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
		 method = field.GetValue(this) as Delegate;
		  parameters = (List<int>)method.Method.Invoke(method.Target, new object[1]{parameters});//print(modified.ToList())IEnumerable<int>
			}
			print(parameters);
		  
		
		 
		}


		static IEnumerable<string> Iter(IEnumerable<string> collec)
		{
			foreach (string n in collec)
			{
				yield return n;
			}
		}


		static IEnumerable<int> removeDivisablesAndReverse(IEnumerable<int> arr, int divisor)
		{
			Func<int, int, bool> deleg = Program.isDivisable.Compile();

			IEnumerable<int> Results =
				from i in arr
				where deleg(i, divisor) == false
				select i;

			return Results.Reverse();
		}

		static Expression<Func<int, int, bool>> isDivisable = (dvdnd, dvsr) => dvdnd % dvsr == 0;




	}
}
