using System;
//using wksht3Solutions;

namespace QuestionOne
{
   public class Program
    {
        static void Main(string[] args)
        {
           // String[] newargs = { "heyafsdfsdf"};
           // wksht3Solutions.Program.Main(newargs);
            print(args);



            // or alternatively
            //args.ToList().ForEach(i => Console.WriteLine(i.ToString()));//https://stackoverflow.com/questions/16265247/printing-all-contents-of-array-in-c-sharp

            //or (2nd alternative)
            //Array.ForEach(args, Console.WriteLine);

            //or (3rd alternative)
            // Action<string[]> print = new Action<string[]>(IterateOverArrOfStrings);
            // print(args);






        }

        static  Action<string[]> print = delegate (string[] arr)
        {

            foreach (string str in arr)
            {

                Console.WriteLine(str);
            }
        };
    }
}
