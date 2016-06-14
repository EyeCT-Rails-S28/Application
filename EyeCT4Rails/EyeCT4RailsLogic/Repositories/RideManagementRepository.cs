using System;
using EyeCT4RailsDatabase.Models;
using EyeCT4RailsDatabase.SQLContexts;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic.Exceptions;
using EyeCT4RailsLogic.Utilities;

// ReSharper disable MemberCanBeMadeStatic.Local

namespace EyeCT4RailsLogic.Repositories
{
    public class RideManagementRepository
    {
        private static RideManagementRepository _instance;
        private readonly IRideManagementContext _context;

        private RideManagementRepository()
        {
            _context = new RideManagementSqlContext();
        }

        /// <summary>
        /// The instance of the singleton RideManagementRepository.
        /// </summary>
        public static RideManagementRepository Instance => _instance ?? (_instance = new RideManagementRepository());

        /// <summary>
        /// Changes the status of a tram. Dangerous code!
        /// </summary>
        /// <param name="tramId">The tram to change the status of/</param>
        /// <param name="status">The new status of a tram.</param>
        public void ChangeTramStatus(int tramId, Status status)
        {
            try
            {
                _context.ReportStatusChange(tramId, status);
            }
            catch (Exception e)
            {
                ExceptionHandler.FilterOracleDatabaseException(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }      
    }
}