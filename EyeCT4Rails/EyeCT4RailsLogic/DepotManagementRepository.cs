using System;
using EyeCT4RailsDatabase;
using EyeCT4RailsDatabase.Models;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic.Exceptions;
using Oracle.ManagedDataAccess.Types;

namespace EyeCT4RailsLogic
{
    public class DepotManagementRepository
    {
        private static DepotManagementRepository _instance;
        private readonly IDepotManagementContext _context;

        private DepotManagementRepository()
        {
            _context = new DepotManagementSqlContext();
        }

        public static DepotManagementRepository Instance => _instance ?? (_instance = new DepotManagementRepository());

        public void SetTrackBlocked(Track track, bool blocked)
        {
            try
            {
               _context.SetTrackBlocked(track, blocked);
            }
            catch (Exception e)
            {
                ExceptionCatch(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        public void SetSectionBlocked(Section section, bool blocked)
        {
            try
            {
                _context.SetSectionBlocked(section, blocked);
            }
            catch (Exception e)
            {
                ExceptionCatch(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        public void ChangeTramStatus(Tram tram, Status status)
        {
            try
            {
                _context.ChangeTramStatus(tram, status);
            }
            catch (Exception e)
            {
                ExceptionCatch(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        public void ReserveSection(Tram tram, Section section)
        {
            try
            {
                _context.ReserveSection(tram, section);
            }
            catch (Exception e)
            {
                ExceptionCatch(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        public Depot GetDepot(string name)
        {
            try
            {
                return _context.GetDepot(name);
            }
            catch (Exception e)
            {
                ExceptionCatch(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        private void ExceptionCatch(Exception e)
        {
            Console.WriteLine(e.StackTrace);

            if (e.GetType() == typeof(OracleTypeException) || e.GetBaseException() is OracleTypeException)
                throw new DatabaseException("A database error has occured.");
        }
    }
}
