using System;
using System.Net;
using System.Net.Mail;

namespace iLibras.Models
{
    public class Email
    {
        public string To { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
        
        public static bool SendEmail(Email email){
            try {
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("ilibrascollaborative@gmail.com", "Si261483@Si261483");

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("ilibrascollaborative@gmail.com");
                mailMessage.To.Add(email.To);


                mailMessage.Body = email.Body;
                mailMessage.Subject = email.Subject;
                client.Send(mailMessage);   
            } catch(Exception ex) {
                Console.WriteLine(ex.ToString());
                return false;
            }

            return true;
        }
    }
}
