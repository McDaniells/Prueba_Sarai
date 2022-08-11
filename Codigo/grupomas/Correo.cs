using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace grupomas
{
    class Correo
    {
        public void EnviarCorreo(String ruta)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("");
                mail.To.Add("");
                mail.Subject = "Test Mail - 1";
                mail.Body = "mail with attachment";

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(ruta);
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("user", "password");
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
