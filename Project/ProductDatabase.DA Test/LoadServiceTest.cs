using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductDatabase.BL;
using ProductDatabase.DA;

namespace ProductDatabase.DA_Test
{
    [TestClass]
    public class LoadServiceTest
    {
        [TestMethod]
        public void ReadFromFileTest()
        {
            //Arrange

            var loadService = new LoadService();
            var expected = "2; Notebook";
            //Act
            var actual = loadService.ReadFromFile(2);
            //Assert
            Assert.AreEqual(expected,actual);
        }
    }
}
