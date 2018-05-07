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
                var fromAddress = new MailAddress("ilibrascollaborative@gmail.com", "iLibras Collaborative");
                var toAddress = new MailAddress(email.To, email.To);

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, "Si261483@Si261483")
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = email.Subject,
                    Body = email.Body
                })
                {
                    smtp.Send(message);
                }    
            } catch(Exception ex){
                Console.WriteLine(ex.ToString());
                return false;
            }

            return true;
        }
    }
}
