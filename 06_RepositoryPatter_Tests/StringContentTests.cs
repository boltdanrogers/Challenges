using System;
using _06_RepositoryPattern_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _06_RepositoryPattern_Tests
{
    [TestClass]
    public class StringContentTests
    {
        [TestMethod]
        public void SetTitle_ShouldSetCorrectString()
        {   
            //Arrange
            StreamingContent content = new StreamingContent();
            //now we have an instance of StreamingContent

            //Act
            content.Title = "Predator";
            string expected = "Predator";
            string actual = content.Title;

            //Assert
            Assert.AreEqual(expected, actual);


        }//end of method
    }
}
