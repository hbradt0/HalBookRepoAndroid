using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmailReader //rename
{
    public class EmailFileRead
    {
        public EmailFileRead()
        {

        }

        public static String ReadText(String fileName = "")
        {
            if (fileName == "")
                fileName = Credentials.FileIn.FullName;
            return File.ReadAllText(fileName);
        }

        public static bool ValidateEmail(String email = "")
        {
            return email.Contains("@") && email.Contains(".") && email!="";
        }

        public static void EmailTestResultsEmail(String email, String file = "")
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(Credentials.emailFrom);

                mail.To.Add(email);
                mail.Subject = "Your story creative...";
                mail.Body = "Here is your story booklet! Emailed to you at " + DateTime.Now.ToString();

                System.Net.Mail.Attachment attachment;
                if (file == "")
                    file = Credentials.FileOut.FullName;
                attachment = new System.Net.Mail.Attachment(file);
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(Credentials.SMTPEmail, Credentials.SMTPPassword);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                //MessageBox.Show("mail Send");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
