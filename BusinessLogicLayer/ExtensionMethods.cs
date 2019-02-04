using EntitiesLayer;

namespace BusinessLogicLayer
{
    /// <summary>
    /// Class that contains extensions methods.
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Extension method that validate if test case have pending cases.
        /// </summary>
        /// <param name="testCase"></param>
        /// <returns>Bool that specific if there are pending cases.</returns>
        public static bool HasCases(this TestCase testCase)
        {
            return testCase.Executed < testCase.Cases;
        }

        /// <summary>
        /// Extension method that validate if matriz have pending executions.
        /// </summary>
        /// <param name="matriz"></param>
        /// <returns>Bool that specific if there are pending executions.</returns>
        public static bool HasExecutions(this Matriz matriz)
        {
            return matriz.Executed < matriz.Operations;
        }
    }
}
