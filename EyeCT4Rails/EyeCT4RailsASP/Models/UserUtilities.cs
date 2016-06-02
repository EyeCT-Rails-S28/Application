using EyeCT4RailsLib.Classes;
using EyeCT4RailsLib.Enums;

namespace EyeCT4RailsASP.Models
{
    public class UserUtilities
    {
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