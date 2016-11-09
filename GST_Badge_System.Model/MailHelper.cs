using System;
using System.Net.Mail;

namespace GST_Badge_System.Model
{
    public class MailHelper
    {
        public static void SendBadgeNotification(string sender, string receiver)    // add badge as a param
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(sender);
                mail.To.Add(receiver);
                mail.Subject = "Test Mail - 1";
                mail.Body = "Mail with attachment";

                System.Net.Mail.Attachment attachment;
                string uriPath = "http://www.oc.edu/academics/graduate/theology/images/digital-badge-images/staff-student-badges/animated-gif-images/401%20Early%20Enroller.gif";
                string localPath = new Uri(uriPath).LocalPath;
                attachment = new System.Net.Mail.Attachment(localPath);
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(sender, "anonym0u$1");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
