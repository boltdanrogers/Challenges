using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_Types
{
    [TestClass]
    public class TypeExamples
    {
        [TestMethod]
        public void ValueTypes()
        {
            
            byte aByte = 7;

            Console.WriteLine(aByte);

           switch(aByte)
            {
                case 5:
                    Console.WriteLine("5");
                    break;
                case 6:
                case 7:
                case 8:
                    Console.WriteLine("6, 7 or 8");
                    break;

               

            }



        }//end of ValueTypes method
    
        
    
    
    }
}
