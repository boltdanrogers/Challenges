using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTeamConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //instantiate a programUI object
            ProgramUI theProgram = new ProgramUI();
            //call the programs public run method
            theProgram.Run();

            //and that's it. when the flow reaches this point the programUI will have closed and the main method will end

        }
    }
}
