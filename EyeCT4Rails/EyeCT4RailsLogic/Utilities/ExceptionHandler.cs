using System;
using EyeCT4RailsLib;
using EyeCT4RailsLogic.Exceptions;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace EyeCT4RailsLogic.Utilities
{
    /// <summary>
    /// General static class for some exception handling methods that are shared between repositories.
    /// </summary>
    public static class ExceptionHandler
    {
        /// <summary>
        /// Catches all oracle database exceptions from an exception and turns it into a general database error if it is a oracle exception.
        /// </summary>
        /// <param name="e">The exception to check.</param>
        public static void FilterOracleDatabaseException(Exception e)
        {
            Console.WriteLine(e.Message);

            if (e is OracleException || e.GetBaseException() is OracleException || e is OracleTypeException || e.GetBaseException() is OracleTypeException)
                throw new DatabaseException("A database error has occured.", e);
        }

        /// <summary>
        /// Filters out all the custom exceptions and rethrows them.
        /// </summary>
        /// <param name="e">The exception to check for.</param>
        public static void FilterCustomException(Exception e)
        {
            if (e.GetBaseException() is CustomException)
                throw new CustomException(e.Message);
        }

        /// <summary>
        /// Checks the validity of a given period. Throws an exception if the period does not exist logically.
        /// </summary>
        /// <param name="startDate">The starting date.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="interval">The interval between two jobs.</param>
        public static void CheckForInvalidDateException(DateTime startDate, DateTime endDate, int interval)
        {
            if (endDate < startDate)
                throw new InvalidDateException("End date is before start date.");

            if (interval < 1)
                throw new InvalidDateException("Interval has to be greater than 1.");
        }
    }
}
