using System;
using System.Diagnostics;
using _06_RepositoryPattern_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _06_RepositoryPattern_Tests
{
    [TestClass]
    public class StreamingContentRepositoryTest
    {
        //some local private data members, or fields I guess
        private StreamingContentRepository _repo;
        private StreamingContent _content;



        [TestInitialize]
        public void Arrange()
        {
            //this is a method that will be run before any of the other tests.
            //we will use the private data members/fields
            //the fields are initialized but are currently null (i think)
            
            _repo = new StreamingContentRepository();
            _content = new StreamingContent("Rubber", "A car goes on a murderous rampage", "R", 5.8, false, GenreType.Drama);
            //note the way the enum was used here

            //now add the content to the repository
            _repo.AddContentToList(_content);

        }






        //Add Method
        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {

            //Arrange: set up the playing field
            StreamingContent content = new StreamingContent();
            content.Title = "Alien";
            StreamingContentRepository repository = new StreamingContentRepository();


            //Act: run the code you want to test
            repository.AddContentToList(content);
            //so we've taken our repository and added the content
            //we want to pull it back into a new content and compare the one we start with to
            //the one we receive from the repository
            StreamingContent contentFromDirectory = repository.GetContentByTitle("Alien");


            //Assert: use assert to verify the expected outcome
            Assert.IsNotNull(contentFromDirectory);
            
            
        }
 
        
        //Update
        [TestMethod]
        public void UpdateExistingContent_ShouldReturnTrue()
        {

            //Arrange
            //TestInitialize create new data to update existing entry
            StreamingContent newContent = new StreamingContent("Rubber", "A car goes on a murderous rampage", "R", 5.8, false, GenreType.RomCom);


            //Act by calling the update function to see if it succeeds in updating the data
            bool updateResult = _repo.UpdateExistingContent("Rubber", newContent);

            //Assert, self explanatory
            Assert.IsTrue(updateResult);

        }//end of method UpdateExistingContent



        //this is how we give our methods different kinds of input
        [DataTestMethod]
        [DataRow("Rubber", true)]
        [DataRow("Toy Story",false)]
        public void UpdateExistingContent_ShouldMatchGivenBool(string originalTitle, bool shouldUpdate)
        {
            //Arrange
            //TestInitialize create new data to update existing entry
            StreamingContent newContent = new StreamingContent("Rubber", "A car goes on a murderous rampage", "R", 5.8, false, GenreType.RomCom);


            //Act by calling the update function to see if it succeeds in updating the data
            bool updateResult = _repo.UpdateExistingContent(originalTitle, newContent);

            //Assert, self explanatory
            Assert.AreEqual(shouldUpdate, updateResult);

        
        }//end of data method UpdateExistingContent


        //Delete
        [TestMethod]
        public void DeleteContent_ShouldReturnTrue()
        {
            //Arrange seems to have happened

            //Act, run the test and assign the returned bool
            bool removeResult = _repo.RemoveContentFromList(_content.Title);

            //Assert
            Assert.IsTrue(removeResult);

        }//end of DeleteContent



    }
}
