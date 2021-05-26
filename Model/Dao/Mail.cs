using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class Mail
    {
        public void SendMail(string toEmailAddress, string subject, string content)
        {
            var fromEmailAddress = "son.tienson@gmail.com";
            var fromEmailDisplayName = "Đơn hàng mới";
            var fromEmailPassword = "sonnano2";
            var smtpHost = "smtp.gmail.com";
            var smtpPort = "587";

            bool enabledSsl = true;

            string body = content;
            MailMessage message = new MailMessage(new MailAddress(fromEmailAddress, fromEmailDisplayName), new MailAddress(toEmailAddress));
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = body;

            var client = new SmtpClient();
            client.Credentials = new NetworkCredential(fromEmailAddress, fromEmailPassword);
            client.Host = smtpHost;
            client.EnableSsl = enabledSsl;
            client.Port = !string.IsNullOrEmpty(smtpPort) ? Convert.ToInt32(smtpPort) : 0;
            client.Send(message);
        }
    }
}
