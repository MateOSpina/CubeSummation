using CommonLayer;
using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer
{
    /// <summary>
    /// Class that contain matriz logic.
    /// </summary>
    public class MatrizBL
    {
        /// <summary>
        /// Method that create a new matriz.
        /// </summary>
        /// <param name="newMatriz"></param>
        /// <param name="numberOfRows"></param>
        /// <returns>Matriz created.</returns>
        public Matriz CreateMatriz(Matriz newMatriz, int numberOfRows)
        {
            var db = new Context();
            try
            {
                var testCase = db.TestCases.AsEnumerable().LastOrDefault();
                if (testCase != null)
                {
                    if (testCase.HasCases())
                    {
                        var lastMatriz = db.Matriz.AsEnumerable().LastOrDefault();
                        if (lastMatriz != null && lastMatriz.HasExecutions())
                        {
                            newMatriz.Id = int.MaxValue;
                        }
                        else
                        {
                            var rowBl = new RowBL();
                            newMatriz.Rows = rowBl.CreateRows(numberOfRows);
                            testCase.Matriz = testCase.Matriz ?? new List<Matriz>();
                            testCase.Matriz.Add(newMatriz);
                            testCase.Executed++;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        newMatriz.Id = int.MinValue;
                    }
                }
            }
            catch(Exception ex)
            {
                var newCustomException = new CustomException(string.Format(Constants.CustomExceptionDescriptionFormat, this.GetType().Name,
                    System.Reflection.MethodBase.GetCurrentMethod().Name, (ex.InnerException ?? ex).Message));
                db.CustomExceptions.Add(newCustomException);
                db.SaveChanges();
            }
            finally
            {
                db.Dispose();
            }

            return newMatriz;
        }        

        /// <summary>
        /// Method that execute queries for matriz.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="rowNumber"></param>
        /// <param name="endRowNumber"></param>
        /// <param name="value"></param>
        /// <returns>Result of exection.</returns>
        public int? ExecuteQuery(Enumerations.Query query, int rowNumber, int endRowNumber, int value)
        {
            int? result = null;
            var db = new Context();
            try
            {
                var matriz = db.Matriz.Include("Rows").AsEnumerable().LastOrDefault();
                if (matriz != null && matriz.HasExecutions())
                {
                    switch (query)
                    {
                        case Enumerations.Query.Update:
                            UpdateMatrizRows(matriz, rowNumber, value);
                            result = 1;
                            break;
                        case Enumerations.Query.Query:
                            result = MatrizSummation(matriz, endRowNumber, rowNumber);
                            break;
                        default:
                            break;
                    }

                    matriz.Executed++;
                    db.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                var newCustomException = new CustomException(string.Format(Constants.CustomExceptionDescriptionFormat, this.GetType().Name,
                    System.Reflection.MethodBase.GetCurrentMethod().Name, (ex.InnerException ?? ex).Message));
                db.CustomExceptions.Add(newCustomException);
                db.SaveChanges();
            }
            finally
            {
                db.Dispose();
            }

            return result;
        }

        /// <summary>
        /// Method that updte value of row.
        /// </summary>
        /// <param name="matriz"></param>
        /// <param name="rowNumber"></param>
        /// <param name="value"></param>
        private void UpdateMatrizRows(Matriz matriz, int rowNumber, int value)
        {
            var rowToUpdate = matriz.Rows.Where(r => r.RowNumber == rowNumber);
            if (rowToUpdate != null)
            {
                rowToUpdate.ToList().ForEach(r =>
                {
                    r.Value = value;
                });
            }
        }

        /// <summary>
        /// Method that sum values of range of rows.
        /// </summary>
        /// <param name="matriz"></param>
        /// <param name="endRowNumber"></param>
        /// <param name="initialRowNumber"></param>
        /// <returns>Result of summation.</returns>
        public int MatrizSummation(Matriz matriz, int endRowNumber, int? initialRowNumber)
        {
            return matriz.Rows.Where(r => r.Column == Enum.GetName(typeof(Enumerations.Rows), Enumerations.Rows.x) && r.RowNumber>= (initialRowNumber?? r.RowNumber) && r.RowNumber <= endRowNumber).Select(r => r.Value).Sum();
        }        
    }
}
