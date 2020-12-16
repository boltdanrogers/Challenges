using _06_RepositoryPattern_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_RepositoryPattern_Console
{
    class ProgramUI
    {
        //create a private field
        private StreamingContentRepository _contentRepository = new StreamingContentRepository();
        //now we have a repository, and through it access to the list



        //method that starts the UI application
        public void Run()
        {
            //populate it for testing purposes
            SeedContentList();
            //now call the menu
            Menu();

        }//end of public method Run

        //Private Menu method
        private void Menu()
        {

            bool keepRunning = true;
            while (keepRunning)
            {
                //print out our options for the user
                Console.WriteLine("Select the Menu Option:\n" +
                    "1. Create New Content\n" +
                    "2. View All Content\n" +
                    "3. View Content by Title\n" +
                    "4. Update Existing Content\n" +
                    "5. Delete Existing Content\n" +
                    "6. Exit Program");

                //get input
                string userInput = Console.ReadLine();

                //evaluate user input
                switch (userInput)
                {
                    case "1":
                        //1. Create New Content
                        CreateNewContent();
                        break;
                    case "2":
                        //2. View All Content
                        ViewAllContent();
                        break;
                    case "3":
                        //3. View Content by Title
                        ViewContentTitle();
                        break;
                    case "4":
                        //4. Update Existing Content
                        UpdateExistingContent();
                        break;
                    case "5":
                        //5. Delete Existing Content
                        DeleteExistingContent();
                        break;
                    case "6":
                        //6. Exit Program
                        keepRunning = false;
                        ExitProgram();
                        break;
                    default:
                        //for someone entering the wrong thing
                        Console.WriteLine("Input not valid.");
                        break;
                }//end of switch case

                //now we've evaluated what the user entered

                Console.WriteLine("Press the enter key to continue...");
                Console.ReadLine();
                Console.Clear();


            }//end of while


        }//end of private menu method



        //now the other methods to access the repository



        //1. Create New Content
        private void CreateNewContent()
        {
            //lets create a new streaming content
            StreamingContent newContent = new StreamingContent();

            //we want to go ahead and get the user input
            //assign it straight to the property in the newContent

            //title
            Console.WriteLine("Please enter the Title for the Content:");
            newContent.Title = Console.ReadLine();

            //description
            Console.WriteLine("Enter a Description for the Content:");
            newContent.Description = Console.ReadLine();

            //maturity rating
            Console.WriteLine("Enter the rating for the Content (G, PG, PG-13, etc):");
            newContent.MaturityRating = Console.ReadLine();

            //star rating
            Console.WriteLine("Enter a star rating for the Content on a scale of 0-10:");
            //read line always gives a string sooooo
            newContent.StarRating = double.Parse(Console.ReadLine());
            //found a long explanation of conversion casting and parsing

            //is family friendly
            Console.WriteLine("Is the Content family friendly? y/n:");
            string familyString = Console.ReadLine().ToLower();
            if (familyString == "y")
            {

                newContent.IsFamilyFriendly = true;

            }//end of if yes
            else
            {

                newContent.IsFamilyFriendly = false;

            }//end of else

            //genretype
            Console.WriteLine("Select a genre for the Content\nChoose from the folowing:" +
                "Horror = 1\nRomCom = 2\nSciFi = 3\nDocumentary = 4\nBromance = 5\nDrama" +
                " = 6\nAction = 7");
            //given the list of choices
            int genreAsInt = int.Parse(Console.ReadLine());
            newContent.TypeOfGenre = (GenreType)genreAsInt;


            //all the things have been done, so the content should be fully populated
            //lets save this to our repository

            _contentRepository.AddContentToList(newContent);
            //reference to the private field, call the method and pass it the new content




        }//end of CreateNewContent method


        //2. View All Content
        private void ViewAllContent()
        {
            //this method will cycle through the repository
            //and display all the content
            //everything is in or repo private field
            //clear the menu
            Console.Clear();

            //create another list we can easily work with

            List<StreamingContent> contentList = _contentRepository.GetContentList();
            //so our list with method scope has everything our repo has, lets cycle through it
            foreach (StreamingContent content in contentList)
            {

                Console.WriteLine($"Title: {content.Title}\n" +
                    $"Description: {content.Description}\n");

            }//end of foreach




        }//end of viewallcontent


        //3. View Content by Title
        private void ViewContentTitle()
        {//simple enough, get title from user and see if we have the content
            //clear the console
            Console.Clear();
            //tell the user what we want
            Console.WriteLine("Enter the Title you would like to view:");
            //get the input
            string userTitle = Console.ReadLine();
            //find content by title
            StreamingContent content = _contentRepository.GetContentByTitle(userTitle);
            //either this is null or has been returned properly
            if (content != null)
            {
                Console.WriteLine($"Title: {content.Title}\n" +
                    $"Description: {content.Description}\n" +
                    $"Maturity Rating: {content.MaturityRating}\n" +
                    $"Stars: {content.StarRating}\n" +
                    $"Is Family Friendly: {content.IsFamilyFriendly}\n" +
                    $"Genre: {content.TypeOfGenre}");

            }//end of if content not null
            else
            {
                Console.WriteLine("I could not find content with that title.");
            }

        }//end of method viewcontenttitle

        //4. Update Existing Content
        private void UpdateExistingContent()
        {
            //start with a clear
            Console.Clear();
            //display the list of available titles
            ViewAllContent();
            //ask for the title
            Console.WriteLine("Please enter the title of the content you would like to update:");
            //get the title from the user
            string oldTitle = Console.ReadLine();

            //now we are going to get all the info from the user
            //lets create a new streaming content
            StreamingContent newContent = new StreamingContent();

            //we want to go ahead and get the user input
            //assign it straight to the property in the newContent

            //title
            Console.WriteLine("Please enter the Title for the Content:");
            newContent.Title = Console.ReadLine();

            //description
            Console.WriteLine("Enter a Description for the Content:");
            newContent.Description = Console.ReadLine();

            //maturity rating
            Console.WriteLine("Enter the rating for the Content (G, PG, PG-13, etc):");
            newContent.MaturityRating = Console.ReadLine();

            //star rating
            Console.WriteLine("Enter a star rating for the Content on a scale of 0-10:");
            //read line always gives a string sooooo
            newContent.StarRating = double.Parse(Console.ReadLine());
            //found a long explanation of conversion casting and parsing

            //is family friendly
            Console.WriteLine("Is the Content family friendly? y/n:");
            string familyString = Console.ReadLine().ToLower();
            if (familyString == "y")
            {

                newContent.IsFamilyFriendly = true;

            }//end of if yes
            else
            {

                newContent.IsFamilyFriendly = false;

            }//end of else

            //genretype
            Console.WriteLine("Select a genre for the Content\nChoose from the folowing:" +
                "Horror = 1\nRomCom = 2\nSciFi = 3\nDocumentary = 4\nBromance = 5\nDrama" +
                " = 6\nAction = 7");
            //given the list of choices
            int genreAsInt = int.Parse(Console.ReadLine());
            newContent.TypeOfGenre = (GenreType)genreAsInt;


            //all the things have been done, so the content should be fully populated
            //lets update this in our repository
            bool wasUpdated= _contentRepository.UpdateExistingContent(oldTitle, newContent);
            if(wasUpdated)
            {
                Console.WriteLine("Updated Successfully.");
            }//end of if wasUpdated
            else
            {
                Console.WriteLine("Not Success");
            }//end of else not updated


        }//end of method updateexistingcontent

        //5. Delete Existing Content
        private void DeleteExistingContent()
        {
            Console.Clear();
            //get the title
            //start by listing the titles
            ViewAllContent();
            Console.WriteLine("Please enter the title you would like to remove:");
            string userInput = Console.ReadLine();

            //delete the content
            bool success = _contentRepository.RemoveContentFromList(userInput);
            //success is either true or false

            //communicate success or failure
            if (success)
            {
                Console.WriteLine("Content deleted.");
            }//end of if success
            else
            {
                Console.WriteLine("Delete failed.");
            }//end of else not a success




        }//end of method deleteexistingcontent

        //6. Exit Program
        private void ExitProgram()
        {
            Console.WriteLine("Thank you, enjoy the rest of your day.");
        }//end of method exitprogram

        //simple seed content method
        private void SeedContentList()
        {

            //create three different streaming content to add to a repo
            StreamingContent sharknado = new StreamingContent("Sharknado", "Tornado, but with sharks", "TV-14", 3.3, true, GenreType.Action);
            StreamingContent rubber = new StreamingContent("Rubber", "A tire comes to life and can kill", "R", 5.3, false, GenreType.Horror);
            StreamingContent theRoom = new StreamingContent("The Room", "A banker's life turns upside down", "R", 3.7, false, GenreType.Documentary);
            //We ve got them made and populated
            _contentRepository.AddContentToList(sharknado);
            _contentRepository.AddContentToList(rubber);
            _contentRepository.AddContentToList(theRoom);
            //and now we have added three movies to our contentRepository

        }//end of method seed content list


    }//end of ProgramUI
}