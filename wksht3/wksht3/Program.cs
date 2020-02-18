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
        public static void Main(String[] args)
        {
			List<int> ls = new List<int>();
			string userInput="";
			int intVal;
			double doubleVal;
			
			while (userInput!="end"){
			Console.Write("Enter integer value, press 'end' to stop: ");
			userInput = Console.ReadLine();
			intVal = Convert.ToInt32(userInput);
			ls.Add(intVal);
			//Console.WriteLine("You entered {0}",intVal);
			}
			
			
			
			
			
			
			 }
		

      public static void IterateOverArrOfStrings(string[] arr) { 
           foreach(string str in arr) {

                   Console.WriteLine(str);
           }
        }
		
		// public static Func<List<int>, int> returnMinFrmCollec = n => n.Min();
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
	
    






    }
}
