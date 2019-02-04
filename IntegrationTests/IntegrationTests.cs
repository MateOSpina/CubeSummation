using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntitiesLayer;
using BusinessLogicLayer;

namespace IntegrationTests
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public void HasTestCaseCreated()
        {
            var newTestCase = new TestCase
            {
                Cases = 1
            };

            var testCaseBl = new TestCaseBL();
            testCaseBl.CreateTestCase(newTestCase);
            Assert.IsTrue(newTestCase.Id > 0);
        }

        [TestMethod]
        public void HasMatrizCreated()
        {            
            var newMatriz = new Matriz
            {
                Operations = 1
            };

            var numberOfRows = 1;

            var matrizBl = new MatrizBL();
            matrizBl.CreateMatriz(newMatriz, numberOfRows);
            Assert.IsTrue(newMatriz.Id > 0);
        }        
    }
}
