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
    public class MailUtil
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
        /// Sends a mail to a mail adress with the given content.
        /// </summary>
        /// <param name="to">The receivers email adress.</param>
        /// <param name="subject">The subject of the mail.</param>
        /// <param name="content">The contents of the email.</param>
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
        /// Method for sending the actual mail.
        /// </summary>
        /// <param name="o">The mail.</param>
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

        private MailUtil()
        {
        }
    }
}
