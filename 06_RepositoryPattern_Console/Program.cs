using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_RepositoryPattern_Console
{
    class Program
    {
        static void Main(string[] args)
        {

            //single responsibility means this method should do only one thing: launch the program
            ProgramUI programInterface = new ProgramUI();
            
            //now that we've instantiated, call the public Run method
            programInterface.Run();
            //we've now passed control from main to the programUI class

        }//end of static main method
    }
}
