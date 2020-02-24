using System;
using System.Collections.Generic;
using System.Linq;
namespace QuestionTen
{
    class Program
    {
       static Func<List<string>, string, string, string, IEnumerable<string>> DoubleOrRemove = (n, fn, condition, s) => n.Select(i => Functions.Program.conditionTester(condition, i, s) == true ? i = Functions.Program.Applyoperator(i, fn) : i = i).ToList();
 
         static void Main(string[] args)
        {
             List<string> parameters = Functions.Program.ProcessDataInput<string>("Enter name of someone who comes to the party and press 'end' to finish entering: ", "end", true);
            List<string> commands = Functions.Program.ProcessDataInput<string>("Enter function: eg 'Double', 'Remove', followed by the condition: eg, 'StartsWith', 'EndsWith', 'Length', followed by the value: eg 'wor', 'ord' or '5', all seperated by spaces; press 'party!' to stop: ", "party!", true);
            Functions.Program.Execute(commands, parameters, true, typeof(QuestionTen.Program));
        }
    }
}
