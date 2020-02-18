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

yourArray.ToList().ForEach(i => Console.WriteLine(i.ToString()));

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
			
//3
		/* if (args.Length!=0){
	Console.WriteLine(returnMinFrmCollec(args.Select(int.Parse).ToList()));
	} */
	
//4
	
	myFilter(0, 10, n => n%2 == 0).ToList().ForEach(i => Console.WriteLine(i.ToString()));
	myFilter(0, 10, n => n%2 == 1).ToList().ForEach(i => Console.WriteLine(i.ToString()));
		
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

    }
}
