using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;

namespace QuestionFive
{

	

	public class Program
    {
        static Func<List<int>, List<int>> addOne = n => n.Select(i => Functions.Program.Applyoperator(i, "+")).ToList();
        static Func<List<int>, List<int>> multiply = n => n.Select(i => Functions.Program.Applyoperator(i, "*")).ToList();
        static Func<List<int>, List<int>> subtractOne = n => n.Select(i => Functions.Program.Applyoperator(i, "-")).ToList();
		static Func<List<string>, string, string, string, IEnumerable<string>> DoubleOrRemove = (n, fn, condition, s) => n.Select(i => Functions.Program.conditionTester(condition, i, s) == true ? i = Functions.Program.Applyoperator(i, fn) : i = i).ToList();

		static void Main(string[] args)
        {
			  List<int> parameters = Functions.Program.ProcessDataInput<int>("Enter integer value, one at a time, press 'end' to stop: ", "end",false); 

			  List<string> commands = Functions.Program.ProcessCommandInput<string>("Enter function: eg 'addOne', 'multiply', 'subtractOne'; and press 'end' to stop: ", "end", typeof(QuestionFive.Program));


		 //	Assembly currentAssem = Assembly.GetExecutingAssembly();
			//	var prg =  Activator.CreateInstance(typeof(Functions.Program));// as typeof(Functions.Program);//(Functions.Program)
			//Type i = prg.GetType();
 		//var m=	  i.GetMethod("sayBla");
			//m.Invoke(prg, null);
			 
		 	Functions.Program.Execute(commands, parameters, false, typeof(QuestionFive.Program));


		}

		public void saybli()
		{
			Console.WriteLine("blibli");
		}










	}

	

}
