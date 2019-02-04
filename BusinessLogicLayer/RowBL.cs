using CommonLayer;
using EntitiesLayer;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    /// <summary>
    /// Class that contains row logic.
    /// </summary>
    public class RowBL
    {
        /// <summary>
        /// Method that create list of rows based in number of rows and enumeration with name rows.
        /// </summary>
        /// <param name="numberOfRows"></param>
        /// <returns>List of rows created.</returns>
        public List<Row> CreateRows(int numberOfRows)
        {
            var rows = new List<Row>();
            foreach (var rowName in Enum.GetNames(typeof(Enumerations.Rows)))
            {
                for (int i = 1; i <= numberOfRows; i++)
                {
                    rows.Add(new Row { Column = rowName, RowNumber = i, Value = 0 });
                }
            }

            return rows;
        }
    }
}
