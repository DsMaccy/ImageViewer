using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CyclePictures.Tester
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAdd()
        {
            //Test generic case: adding single element
            ImageLocationList ILL = new ImageLocationList();
            for (int i = 0; i < ImageLocationList.START_SIZE; i++)
            {
                ILL.add("this" + i);
                Assert.AreEqual(ILL[i], "this" + i);
            }

            //Test corner case: adding an element over and beyond the initial size
            for (int i = 0; i < 2000000; i++)
            {
                ILL.add("this" + i);
                Assert.AreEqual(ILL[i], "this" + i);
            }
            Assert.AreEqual(ILL[2000000], "this2000000");

            //Add Redundant elements
            string hi = "hello";
            ILL.add(hi); ILL.add(hi);
            Assert.IsTrue(ILL.Length == (2 + 2000000 + ImageLocationList.START_SIZE));
        }

        [TestMethod]
        public void TestDelete()
        {
            ImageLocationList ILL = new ImageLocationList();
            for (int i = 0; i < ImageLocationList.START_SIZE; i++)
            {
                ILL.add("this" + i);    
            }
            //Add test cases for the delete function
        }
    }
}
