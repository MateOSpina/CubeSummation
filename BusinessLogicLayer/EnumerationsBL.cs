using CommonLayer;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    /// <summary>
    /// Class that contains Logic for enumerations.
    /// </summary>
    public class EnumerationsBL
    {
        /// <summary>
        /// Method that get types of queries based in enumeration.
        /// </summary>
        /// <returns>List of queries</returns>
        public List<object> GetQueriesTypes()
        {
            var enumVals = new List<object>();

            foreach (var item in Enum.GetValues(typeof(Enumerations.Query)))
            {
                enumVals.Add(new
                {
                    id = (int)item,
                    name = item.ToString()
                });
            }

            return enumVals;
        }
    }
}
