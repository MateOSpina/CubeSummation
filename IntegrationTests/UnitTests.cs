using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntitiesLayer;
using BusinessLogicLayer;

namespace IntegrationTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void isRowListCreated()
        {
            var numberOfRows = 2;
            var numberOfItemsExpected = 6;
            var rowBl = new RowBL();
            var rowsCreated = rowBl.CreateRows(numberOfRows);
            Assert.AreEqual(numberOfItemsExpected, rowsCreated.Count);
        }

        [TestMethod]
        public void isMatrizSummation()
        {            
            var initialRow = 1;
            var endRow = 2;
            var expectedResult = 27;
            var matrizBl = new MatrizBL();
            Assert.AreEqual(expectedResult, matrizBl.MatrizSummation(GetMatriz(), endRow, initialRow));
        }

        private List<Row> GetRows()
        {
            var listRows = new List<Row>();
            var rowx1 = new Row
            {
                Column = "x",
                RowNumber = 1,
                Value = 4
            };

            listRows.Add(rowx1);

            var rowy1 = new Row
            {
                Column = "y",
                RowNumber = 1,
                Value = 4
            };

            listRows.Add(rowy1);

            var rowz1 = new Row
            {
                Column = "z",
                RowNumber = 1,
                Value = 4
            };

            listRows.Add(rowz1);

            var rowx2 = new Row
            {
                Column = "x",
                RowNumber = 2,
                Value = 23
            };

            listRows.Add(rowx2);

            var rowy2 = new Row
            {
                Column = "y",
                RowNumber = 2,
                Value = 23
            };

            listRows.Add(rowy2);

            var rowz2 = new Row
            {
                Column = "z",
                RowNumber = 2,
                Value = 23
            };

            listRows.Add(rowz2);

            return listRows;
        }

        private Matriz GetMatriz()
        {
            var matriz = new Matriz
            {
                Rows = GetRows()
            };

            return matriz;
        }
    }
}
