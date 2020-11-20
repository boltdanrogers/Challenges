using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Week1Challenges
{
    [TestClass]
    public class Challenges
    {
        [TestMethod]
        public void TheChallenges()
        {
            //this is the method that will have all our various challenges

            //declare variables to hold first, last names and age
            string firstName = "Danny";
            string lastName = "Rogers";
            int myAge = 34;
            //let's write to the console
            Console.WriteLine($"Hi, my name is {firstName} {lastName}, and I am {myAge} years old.");

            //create an array to hold the names of four of your favorite books
            string[] favoriteBooks = new string[4] { "Hyperion", "Ilium", "Stardust", "The Time Traveler's Wife" };
            //ok, so apparently we don't use an "=" sign to assign the strings inside the curly backets to the array

            //create a list that holds several dates
            List<DateTime> dateList = new List<DateTime>();
            //and this has us use the "()" at the end of the new list, seemingly as a method

            //now let's add a couple dates

            dateList.Add(new DateTime(2000, 1, 1));//y2k anyone?
            dateList.Add(new DateTime(1900, 1, 1));//the LAST turn of the century
            //and now let's add todays DateTime
            dateList.Add(DateTime.Today);//retrieves the current date, maybe even time not sure



            //ok time to do some maths. Take my age and the number 7 and perform all the various operations on them
            int addedNumber = myAge + 7;
            int subtractedNumber = myAge - 7;
            int multipliedNumber = myAge * 7;
            double dividedNumber = myAge / 7.0;
            int moddedNumber = myAge % 7;
            //I wonder about the division, it was yelling about casting and at first I thought I was doing proper casting...
            Console.WriteLine($"{addedNumber}, {subtractedNumber}, {multipliedNumber}, {dividedNumber}, {moddedNumber}");
            
            //next bit is fun, a bunch of "ifs" about a time representing the sleep you get at night
            //should hardcode it so we don't have to worry about user input

            int sleepTime = 5;
            //let's make a string to hold or response
            string theResponse = "";

            if (sleepTime >= 10)
            {
                theResponse = "Wow that's a lot of sleep!";

            }//end of if >= 10
            else if (sleepTime >= 8 && sleepTime < 10)//made this check for greater then or equal to 8, so that didnt slip through
            {
                theResponse = "You should be pretty rested.";

            }//end of else if > 8 and < 10
            else if (sleepTime >= 4 && sleepTime < 8)
            {

                theResponse = "Bummer!";

            }//end of else if > 4and < 8
            else
            {

                theResponse = "Oh man get some sleep!";

            }//end of else, less than 4

            //now write the response to console
            Console.WriteLine(theResponse);

            //now there's a switch case for a string that describes the user's day

            Console.WriteLine("Describe your day in a single word or emoji.");
            Console.WriteLine("Please use one of the following:");
            Console.WriteLine("great, good, okay, bad and :(");
            //get the user input
            //string userInput = Console.ReadLine();
            //apparently no way I can find to get console readline while unit testing
            string userInput = "okay";
            
            
            
            //now for our swtich case

            switch (userInput)
            {
                case "great":
                    theResponse = "I'm glad you are doing great.";
                    break;
                case "good":
                    theResponse = "Good is a good thing yes?";
                    break;
                case "okay":
                    theResponse = "At least it's not all bad.";
                    break;
                case "bad":
                    theResponse = "I'm sorry to hear that things are bad right now.";
                    break;
                case ":(":
                    theResponse = "Oh no, not the frowning emoji!";
                    break;
                default:
                    theResponse = "That was not a valid response, better luck next time.";
                    break;

            }//end of switch case

            Console.WriteLine(theResponse);

            //now for the last, though it has several parts to it
            //here's the word
            string theWord = "supercalifragilisticexpialidocious";
            //now lets loop through and write each of the letters

            //we'll try one of the for loops I haven'y seen before
            foreach (char aLetter in theWord)
            {

                Console.WriteLine(aLetter);

            }//end of foreach loop to print entire word

            //ok there are some other things to do now
            //only print the letter if it is an I

            //and let's count the number of letters while we do this hmm?
            int letterCount = 0;
            foreach (char aLetter in theWord)
            {
                if (aLetter == 'i')
                {
                    Console.WriteLine(aLetter);
                }//end of if
                else
                {
                    Console.WriteLine("Not an i");
                }//end of else

                letterCount++;
            }//end of foreach loop to print "I"s

            //we should have counted the letters and printed the i's and the message

            Console.WriteLine($"There are {letterCount} letters in the word {theWord}.");
            /*A COMMENT*/



        }
    }
}
