using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Challenges
{
    class Greeter
    {
        //constructor
        public Greeter()
        {


        }//end of constructor

        public void sayHello(string aName)
        {

            Console.WriteLine($"Hello {aName}.");

        }//end of method sayHello

        public void sayGoodbye(string aName)
        {

            Console.WriteLine($"Goodbye {aName}.");

        }//end of method sayGoodbye

        public void timedGreeting(string aName)
        {
            
            //seems the easiest way to get the current hour is to get the current time
            //and get the timeofday, so the hour is in a 24 hour format
            DateTime currentTime = DateTime.Now;
            TimeSpan whatTimeOfDay = currentTime.TimeOfDay;

            //these methods were tests to be sure I understood the methods
            /*
            Console.WriteLine("The current time is: ");
            Console.WriteLine(currentTime);
            Console.WriteLine("And the time of day is:");
            Console.WriteLine(whatTimeOfDay);
            Console.WriteLine("And now just the hours");
            Console.WriteLine((int)whatTimeOfDay.TotalHours);
            */
            int theHour = (int)whatTimeOfDay.TotalHours;

            if (theHour < 12)
            {

                Console.WriteLine($"Good morning, {aName}.");

            }//end of if morning
            else if(theHour < 17)
            {
                Console.WriteLine($"Good afternoon, {aName}.");
            }//end of else if afternoon
            else if(theHour < 20)
            {

                Console.WriteLine($"Good evening, {aName}.");

            }//end of if evening
            else
            {

                Console.WriteLine($"Good night, {aName}.");

            }//end of else night



        }//end of timedGreeting


    }//end of class Greeter



    class Week2Challenges
    {
        static void Main(string[] args)
        {

            Greeter aGreeter = new Greeter();

            aGreeter.sayHello("Andy");
            aGreeter.sayGoodbye("Megan");
            aGreeter.timedGreeting("John");

            Console.ReadLine();

        }//end of main method
    }
}
