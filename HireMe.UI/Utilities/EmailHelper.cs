using HireMe.UI.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace HireMe.UI.Utilities
{
    public class EmailHelper
    {
        public bool SendEmail(EmailDTO email)
        {
           
               

                //send email
             
       
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(email.AddressTo);
                mailMessage.Body = email.Body;
                mailMessage.IsBodyHtml = true;
                mailMessage.From = new MailAddress("catec.innov@gmail.com");
                mailMessage.Subject = email.Subject;
               

               

                SmtpClient SmtpClient = new SmtpClient("smtp.gmail.com", 587);
                SmtpClient.EnableSsl = true;
                SmtpClient.UseDefaultCredentials = true;
                SmtpClient.DeliveryFormat = SmtpDeliveryFormat.International;
                SmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpClient.Credentials = new NetworkCredential("hireme202@gmail.com", "2nasereen");
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                { return true; };
                SmtpClient.Send(mailMessage);

                return true;
            }
      
            
    }
}