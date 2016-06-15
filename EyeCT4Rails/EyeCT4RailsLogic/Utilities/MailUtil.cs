using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;

namespace EyeCT4RailsLogic.Utilities
{
    /// <summary>
    /// Utility class for all mail related code.
    /// </summary>
    public static class MailUtil
    {
        private static readonly SmtpClient Client = new SmtpClient
        {
            Port = 25,
            Host = "smtp.tranviaremise.com",
            EnableSsl = false,
            Timeout = 10000,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential("systeem@tranviaremise.com", "pts36s28s2")
        };

        /// <summary>
        /// Checks whether a given email address is an actual, valid email address.
        /// </summary>
        /// <param name="email">The email to verify.</param>
        /// <returns>True if, and only if, the specified email is a valid email address.</returns>
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// This method sends an email from "systeem@tranviaremise.com" to a specified email address with a subject and a body.
        /// </summary>
        /// <param name="to">The email address to send the message to.</param>
        /// <param name="subject">The subject to give the email address.</param>
        /// <param name="content">The message to send.</param>
        public static void SendMail(string to, string subject, string content)
        {
            MailMessage message = new MailMessage("systeem@tranviaremise.com", to, subject, content)
            {
                BodyEncoding = Encoding.UTF8,
                DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            };

            Thread thread = new Thread(Send);
            thread.Start(message);
        }

        /// <summary>
        /// A method to send an actual mail message
        /// </summary>
        /// <param name="o">An object, should be a MailMessage, to send.</param>
        private static void Send(object o)
        {
            MailMessage message = o as MailMessage;
            if (message != null)
            {
                try
                {
                    Client.Send(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
