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
        public static void Main(String[]  args)
        {


            // Action<string[]> action = new Action<string[]>(IterateOverArrOfStrings);
            // action(args);


           


            Action<string[]> val = delegate (string[] arr)
            {

                foreach (string str in arr)
                {

                                Console.WriteLine(str);
                     }
                };
            
            val(args);
            //Action<string> ac = new Action<string>((x) => Console.WriteLine(x));
            //ac(args);

            //foreach (string str in args)
            //{

            //    ac(str);
            //}







        }


        //public static void IterateOverArrOfStrings(string[] arr) { 
        //    foreach(string str in arr) {

        //             Console.WriteLine(str);
        //    }
        //}



    }
}
