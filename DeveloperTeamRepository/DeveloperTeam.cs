using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTeamRepository
{
    //we have a poco and a repo for it
    //the issue is that there are developer and they go in the other simple object, as well as
    //simply being stored in a repo for them
    //that other simple poco devteam will ALSO have a repo, so we can mess with them
    //then there needs to be a console app to allow the user to make the changes they want to the repos and poco




    public class Developer
    {
        //simple class that has simple fields
        //need two strings for the name, one int for the id, and one bool for access to the learning network
        //I'm seeing that I should use Pascal case for my public and private fields; I've gotten so used to using camelcase for everything that this will take a while to switch
        public string firstName { set; get; }
        public string lastName { set; get; }
        public int developerID { set; get; }
        public bool learningAccess { set; get; }


    }//end of class Developer

    public class DevTeam
    {
        //another simple class with simple fields

        public string teamName { set; get; }
        public int teamID { set; get; }
        //i think in a perfect world we would not have a list of actual developers but rather just the number
        //not sure if I should just do it anyway
        //the way to incorporate these four classes is forming. we can have the developers, and the repo to contain them
        //the DevTeam instances will contain a list of developers (or do it the right way and only use the id number)
        //the repo for the DevTeam will contain a list of DevTeam objects, and will have the methods to create and delete
        //and control them. Those methods could use methods in the other repo to add and delete and change the developers
        //stored in the DeveloperRepo and referenced in the DevTeams inside the DevTeamRepo

        //resources online tell me that I should use _camelCase while public ones use PascalCase, so probably be bad and 
        //use camelCase
        //lets instantiate our list
        public List<Developer> teamDevelopers = new List<Developer>();

        //thats it here, we will create all our manipulating methods in our repo 



    }//end of class DevTeam

    public class DeveloperRepo
    {
        //the first repository to store many simple objects and allow the ability to read and write to them
        //private list of developers
        private List<Developer> _developerList = new List<Developer>();

        //here's where we could go all out and create a great many constructors to take all kinds of input
        //but we'll forgo that and just create a single one with no arguments
        //actually scrap that the repos for the contentStreaming end up with no explicitly coded constuctor

        //crud
        //create read delete update, maybe one or two helper methods we may make public down the road ;)

        //create or add, so a method to add a developer to the repo, return true if successful
        public void AddDeveloper(Developer aDeveloper)
        {
            _developerList.Add(aDeveloper);
            //don't over think it, we will have our logic in our console app
        }//end of method AddDeveloper

        //our read methods should be similar to our other repo project, returning the entire list
        //and also performing several more precise methods

        //start with the big one
        public List<Developer> ReturnDeveloperList()
        {
            return _developerList;

        }//end of method ReturnDeveloperList

        //no some smaller ones
        public Developer ReturnDeveloperByID(int theID)
        {
            //always guaranteed results! we either find the developer or send back null
            foreach (Developer aDeveloper in _developerList)
            {
                if (theID == aDeveloper.developerID)
                {
                    return aDeveloper;

                }//end of if id equals developer.id

            }//end foreach loop
            //we've gone through the list and not found the developer ID
            //send back null cuz that's all there is to do
            return null;

        }//end of method ReturnByDeveloperID


        //oh the fun. the point of the id is to uniquely identify each developer in order to avoid issues with same named
        //peoples. I'll leave this in assuming only one developer to have the same first last name combination
        public Developer ReturnByDeveloperName(string firstName, string lastName)
        {
            foreach (Developer aDeveloper in _developerList)
            {
                //check if the first last name matches
                if (aDeveloper.firstName == firstName && aDeveloper.lastName == lastName)
                {

                    //send back the developer we find that matches
                    return aDeveloper;
                }//end  of if names are equal



            }//end of foreach loop

            //if we get here that means a developer with that first
            return null;


        }//end of method ReturnByDeveloperName

        //lets get some delete methods
        //use the other methods to return Developers by name and ID and erase the developer

        public bool DeleteDeveloperByName(string firstName, string lastName)
        {
            Developer aDeveloper = new Developer();
            aDeveloper = ReturnByDeveloperName(firstName, lastName);
                if (aDeveloper == null)
            {
                //didnt find the name combination
                return false;
            }//end of if aDeveloper equals null
             //could wrap the next bit in an else or else if
             //but they didn't in their project and if we get here it means the method did not return null
             //so skip it

            //make note of the size of the list
            int originalSize = _developerList.Count;
            //after the operation to remove the developer we check the size and compare, reporting
            //success or failure based on the comparison
            _developerList.Remove(aDeveloper);
            if (originalSize > _developerList.Count)
            {
                //the size of the list decreased, indicating the Developer was removed
                return true;

            }//end of if list got smaller
            else
            {
                //didn't go so well, didn't actually remove anything. return false
                return false;
            }//end of else didnt work

        }//end of method deleteDeveloperByName

        public bool DeleteDeveloperByID(int ID)
        {
            //same as deleteDeveloperByName but well you know
            Developer aDeveloper = new Developer();
            aDeveloper = ReturnDeveloperByID(ID);
            if (aDeveloper == null)
            {
                //didn't find it return false
                return false;

            }//end of if null
            //again, we either return false already or find ourselves here
            //same deal, lets count the developers in the list
            int originalSize = _developerList.Count;
            //delete the developer
            _developerList.Remove(aDeveloper);

            //actually sounds like the Remove method on List returns a bool
            //so we don't really need to do our listSize comparison test... may come back and change this once it works
            if (originalSize > _developerList.Count)
            {
                return true;
            }//if worked and size changed
            else
            {
                return false;
            }//bad mojo, didn't work

        }//end of method deleteDeveloperByID


        //now for the disordered U in our crud
        public bool UpdateDeveloper(int ID, Developer newDeveloper)
        {
            //get the developer that needs to be updated
            Developer oldDeveloper = ReturnDeveloperByID(ID);
            if (oldDeveloper == null)
            {
                //didn't work
                return false;
            }
            //to get here you have to have gotted the developer by id
            //want to change the properties of the oldDeveloper
            oldDeveloper.developerID = newDeveloper.developerID;
            oldDeveloper.firstName = newDeveloper.firstName;
            oldDeveloper.lastName = newDeveloper.lastName;
            oldDeveloper.learningAccess = newDeveloper.learningAccess;
            return true;




        }//end of method UpdateDeveloper





    }//end of class DeveloperRepo


    //now it's time to build out the final repository
    //interested to see how the different pieces of this work out with the other repositories and pocos
    //we have the repo of the developers that are instantiated
    //an instantiation of a devTeam will contain either the developers needed from the repo of developers
    //and the only way to access the Developers is through the DeveloperRep that contains all the Developers
    //soooo...

    public class DevTeamRepo
    {
        //another repo to hold and give access to simple objects
        //need the private list to hold out teams. they are expected to be formed, and we will access them 
        private List<DevTeam> _developerTeamList = new List<DevTeam>();

        //ok, we need our crud
        //maybe we need some other methods but lets get the basics out of the way
        //anything special may be done after these methods

        //add another team to the team list
        public void AddTeamToList(DevTeam aTeam)
        {
            //simple enough, add the team to the list
            _developerTeamList.Add(aTeam);

        }//end of method addTeamToList

        //read the entire list or find a specific team based on the team name or id
        public List<DevTeam> ReturnDevTeamList()
        {
            return _developerTeamList;

        }//end of method returnDevTeamList

        //now more fine tuned methods

        public DevTeam ReturnDevTeamByID(int ID)
        {
            //look to see if we can find the devteam with the id
            foreach(DevTeam aTeam in _developerTeamList)
            {
                if (ID == aTeam.teamID)
                {
                    return aTeam;
                }//end of if equal
              

            }//end of foreach
            //if we make it here we didn't find the team, return null
            return null;

        }//end of method getDevTeamByID

        //another, to get by name
        public DevTeam returnDevTeamByName(string name)
        {
            foreach(DevTeam aTeam in _developerTeamList)
            {
                if(name == aTeam.teamName)
                {
                    return aTeam;
                }//end of if name is equal

            }//end of for each

            //got here, didn;t find the team
            return null;
        }//end of method returnDevTeamByName



        //update; make changes to an existing devTeam.
        public bool UpdateDevTeam(int ID, DevTeam newTeam)
        {
            DevTeam oldTeam = ReturnDevTeamByID(ID);
            if (oldTeam == null)
            {
                //didn't work
                return false;
            }//end of if null
            //if we get here oldTeam is not null so
            oldTeam.teamID = newTeam.teamID;
            oldTeam.teamName = newTeam.teamName;
            oldTeam.teamDevelopers = newTeam.teamDevelopers;
            return true;


        }//end of updateDevTeam
        //the repos are supposed to have all the methods for manipulating the pocos




        //delete, find and delete a team... only going to do by ID, not name, we can do more in the console app
        public bool DeleteDevTeam(int ID)
        {
            DevTeam aTeam = ReturnDevTeamByID(ID);
            if(aTeam == null)
            {
                return false;
            }//end of if null
            //if we get here than aTeam is not null

            //the List method Remove should return a bool when called, so will tell us if it worked or not
            bool success = _developerTeamList.Remove(aTeam);
            //and since we need to return a bool...
            return success;
        }


    }//end of class DevTeamRepo
}
