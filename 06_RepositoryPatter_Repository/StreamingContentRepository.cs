
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_RepositoryPattern_Repository
{
    public class StreamingContentRepository
    {

        private List<StreamingContent> _listOfContent = new List<StreamingContent>();//need the parenthesis
        //a property defines the class, a feild is information that needs to be accessed throughout the class
        //the underscore at the beginning of a variable identifies 

        //remember single responsibility principle

        //Create
        public void AddContentToList(StreamingContent content)
        {

            _listOfContent.Add(content);

        }//end of method AddContentToList


        //Read

        public List<StreamingContent> GetContentList()
        {

            return _listOfContent;

        }//end of method GetContentList


        //Update
        public bool UpdateExistingContent(string originalTitle, StreamingContent newContent)
        {
            //find the content
            StreamingContent oldContent = GetContentByTitle(originalTitle);

            //update the content
            if(oldContent != null)
            {
                oldContent.Title = newContent.Title;
                oldContent.Description = newContent.Description;
                oldContent.MaturityRating = newContent.MaturityRating;
                oldContent.IsFamilyFriendly = newContent.IsFamilyFriendly;
                oldContent.StarRating = newContent.StarRating;
                oldContent.TypeOfGenre = newContent.TypeOfGenre;
                return true;
            }//end of if oldContent found
            else
            {
                return false;
            }


        }//end of UpdateExistingContent


        //Delete
        public bool RemoveContentFromList(string title)
        {
            StreamingContent content = GetContentByTitle(title);
            if (content == null)
            {
                //didn't find it
                return false;

            }//end of if not found
            
            //normally might use an else but if we hit this point there is content
            //lets get the size of the list before we remove the content
            int initialCount = _listOfContent.Count;
            //now lets remove and then test the count
            _listOfContent.Remove(content);

            if (initialCount > _listOfContent.Count)
            {
                return true;
            }//end of if we reduced the size of the list by removing content
            else
            {

                return false;

            }//end of else we didn't remove content


        }//end of method RemoveContentFromList

        //no longer a Helper method, now public
        public StreamingContent GetContentByTitle(string title)
        {

            foreach(StreamingContent content in _listOfContent)
            {
                if(content.Title.ToLower() == title.ToLower())
                {

                    return content;

                }//end of if title = title


            }//end of for each loop

            //if there is no title match
            return null;//seems that we are able to do that with a reference type

        }//end of private helper method to 



    }//end of class StreamingContentRepository
}
