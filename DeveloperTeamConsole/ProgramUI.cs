using DeveloperTeamRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTeamConsole
{
    class ProgramUI
    {
        //our program needs a developer repo 
        
        //private field
        private DeveloperRepo _developerRepository = new DeveloperRepo();
        //and a developer team repo
        private DevTeamRepo _developerTeamRepository= new DevTeamRepo();


        //entry point
        public void Run()
        {

            UserInterface();

        }//end of method Run


        //menu for user to interact with the program
        private void UserInterface()
        {
            //loop around until not
            bool continueFlag = true;

            while (continueFlag)
            {
                //start by clearing the screen
                Console.Clear();
                //and print the menu for the user
                Console.WriteLine("Select a Menu option:");

                Console.WriteLine("1 create a Developer\n" +
                    "2 view all Developers\n" +
                    "3 Exit Program\n");

                string userInput = Console.ReadLine();

                switch(userInput)
                {
                    case "1":
                        Console.WriteLine("create a developer");
                        CreateDeveloper();
                        break;
                    case "2":
                        Console.WriteLine("View all developers");
                        break;
                    case "3":
                        Console.WriteLine("Exiting the program");
                        continueFlag = false;
                        break;
                    default:
                        Console.WriteLine("Enter a valid number");
                        break;
                }//end of switch case




            }//end of while continueFlag is true
            //we've gotten here, so continueFlag is false and the user is exiting
            Console.WriteLine("Please press enter to exit:");
            Console.ReadLine();
            //once the user presses enter this userInterface menu method will close

        }//end of method UserInterface

        //and here we have the rest of our many methods
        //lets  do some crud for the developers in that repo
        private void CreateDeveloper()
        {
            Console.Clear();
            Console.WriteLine("Create a new Developer");
            Developer aDeveloper = new Developer();


            //get input from the user
            //fill out the different properties

            //now save to the repository for the developers
            _developerRepository.AddDeveloper(aDeveloper);
            

        }//end of method createDeveloper

        //need a delete developer method
        private void DeleteDeveloper()
        {
            Console.Clear();
            Console.WriteLine("Delete a Developer");
            //get the id for the Developer
            Console.WriteLine("Enter the ID on the developer you want to delete.");
            string stringForID = Console.ReadLine();
            int theID = int.Parse(stringForID);
            bool successfullyDeleted = _developerRepository.DeleteDeveloperByID(theID);
            string deleteMessage = "Developer not Deleted";
            if (successfullyDeleted)
            {
                deleteMessage = "Developer Deleted.";
            }//end of if success

            Console.WriteLine(deleteMessage);
           

        }//end of method DeleteDeveloper





    }//end of class ProgramUI
}
