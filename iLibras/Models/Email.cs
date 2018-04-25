using System;
using System.Net;
using System.Net.Mail;

namespace iLibras.Models
{
    public class Email
    {
        public Email()
        {
        }

        public static bool SendEmail(Email email){
            try {
                SmtpClient client = new SmtpClient("mysmtpserver");
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("user", "pass");

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("whoever@me.com");
                mailMessage.To.Add("receiver@me.com");
                mailMessage.Body = "body";
                mailMessage.Subject = "subject";
                client.Send(mailMessage);   
            } catch(Exception ex) {
                Console.WriteLine(ex.ToString());
                return false;
            }

            return true;
        }
    }
}
