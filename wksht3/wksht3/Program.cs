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


//question 1 (preffered)
            Action<string[]> val = delegate (string[] arr)
            {

                foreach (string str in arr)
                {

                    Console.WriteLine(str);
                }
            };

            val(args);

        }

        //question 1 (alternatively)
//in main:{
        // Action<string[]> action = new Action<string[]>(IterateOverArrOfStrings);
        // action(args);
        //}

 // outside of main:{           //public static void IterateOverArrOfStrings(string[] arr) { 
        //    foreach(string str in arr) {

        //             Console.WriteLine(str);
        //    }
        //}
//}


    }
}
