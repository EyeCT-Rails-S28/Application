using System.Web.ModelBinding;
using EyeCT4RailsLib.Classes;
using EyeCT4RailsLib.Enums;

namespace EyeCT4RailsASP.Models
{
    public class UserUtilities
    {
        /// <summary>
        /// Checks wheter the current user has a certain right.
        /// </summary>
        /// <param name="right">The right the user should posess.</param>
        /// <param name="user">The user is question.</param>
        /// <returns>A boolean that is true if and only if the user has the certain right.</returns>
        public static bool CheckRight(Right right, User user)
        {
            return user?.HasRight(right) ?? false;
        }

        /// <summary>
        /// Gets the standard controller name for a certain role.
        /// </summary>
        /// <param name="user">The current user.</param>
        /// <returns>A string which is the controller name.</returns>
        public static string GetControllerName(User user)
        {
            string ret;

            switch (user?.Function.Role)
            {
                case Role.Administrator:
                case Role.DepotManager:
                    ret = "Depot";
                    break;
                case Role.Mechanic:             
                    ret = "Maintenance";
                    break;
                case Role.Cleanup:
                    ret = "Cleanup";
                    break;
                case Role.Driver:
                    ret = "Ride";
                    break;
                default:
                    ret = "Login";
                    break;
            }

            return ret;
        }

        /// <summary>
        /// Gets the action name of the standard page of a role.
        /// </summary>
        /// <param name="user">The current user.</param>
        /// <returns>A string which is the action name.</returns>
        public static string GetActionName(User user)
        {
            string ret;

            switch (user?.Function.Role)
            {
                case Role.Mechanic:
                    ret = "Overview";
                    break;
                case Role.Cleanup:
                    ret = "Overview";
                    break;
                default:
                    ret = "Index";
                    break;
            }

            return ret;
        }
    }
}