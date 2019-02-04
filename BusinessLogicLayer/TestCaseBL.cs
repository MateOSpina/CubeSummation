using CommonLayer;
using EntitiesLayer;
using System;
using System.Linq;

namespace BusinessLogicLayer
{
    /// <summary>
    /// Class that contains test case logic.
    /// </summary>
    public class TestCaseBL
    {
        /// <summary>
        /// Method that create new test case.
        /// </summary>
        /// <param name="newTestCase"></param>
        /// <returns>Test case created.</returns>
        public TestCase CreateTestCase(TestCase newTestCase)
        {
            var db = new Context();
            try
            {
                var lastTestCase = db.TestCases.AsEnumerable().LastOrDefault();
                if (lastTestCase != null && lastTestCase.HasCases())
                {
                    newTestCase.Id = int.MaxValue;
                }
                else
                {
                    db.TestCases.Add(newTestCase);
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

            return newTestCase;
        }
    }
}
