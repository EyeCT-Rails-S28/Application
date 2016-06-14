using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EyeCT4RailsLogic.Utilities
{
    public class MailUtil
    {
        private static SmtpClient client = new SmtpClient
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
        /// 
        /// </summary>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static void SendMail(string to, string subject, string content)
        {
            MailMessage message = new MailMessage("systeem@tranviaremise.com", to, subject, content)
            {
                BodyEncoding = Encoding.UTF8,
                DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            };

            Thread thread = new Thread(new ParameterizedThreadStart(Send));
            thread.Start(message);
        }

        private static void Send(object o)
        {
            MailMessage message = o as MailMessage;
            if (message != null)
            {
                client.Send(message);
            }
        }

        private MailUtil()
        {
        }
    }
}
