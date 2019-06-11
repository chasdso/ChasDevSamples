using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;

namespace Brokeries.DataValidation

{
    public class Email
    {
        public void Send(string message)
        { 
        SmtpClient client = new SmtpClient();
        client.Port = 587;
        client.Host = "smtp.zoho.com";
        client.EnableSsl = true;
        client.Timeout = 10000;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential("feedback@brokeries.com", "brokeries2");

        MailMessage mm = new MailMessage("feedback@brokeries.com", "feedback@brokeries.com", "Brokeries.DataValidation automated report" ,message);
                mm.BodyEncoding = UTF8Encoding.UTF8;
        mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

        client.Send(mm);
        }
    }
}