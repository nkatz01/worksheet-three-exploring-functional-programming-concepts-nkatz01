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
 
namespace wksht3Solutions
{
	 
    public class Program
    { 
		 
	 
		Action<List<int>> print = n => n.ForEach(i => Console.Write(" " + i.ToString())); 
		Func<List<int>, List<int>> addOne = n => n.Select( i => i + 1).ToList() ;
 		Func<List<int>, List<int>> multiply = n => n.Select( i => i * 2).ToList() ;
		Func<List<int>, List<int>> subtractOne = n =>n.Select( i => i - 1).ToList() ;
	 
		
		public static void Main(String[] args)
		{
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

		
			 


 

    }

 
}
