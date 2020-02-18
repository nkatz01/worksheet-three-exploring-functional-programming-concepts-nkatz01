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
			//https://stackoverflow.com/questions/6201306/how-to-convert-liststring-to-listint

 	   
	  myFilter(0, 10, n => n%2 == 0).ToList().ForEach(i => Console.WriteLine(i.ToString()));
	  myFilter(0, 10, n => n%2 == 1).ToList().ForEach(i => Console.WriteLine(i.ToString()));
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
