using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Remoting.Contexts;
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
                fileName = Credentials.FileInString;//FileIn.FullName;
            return File.ReadAllText(fileName);
        }

        public static String ReadTextFile(Stream s)
        {
            String str = "";
            StringBuilder strbuilder = new StringBuilder();
            Java.IO.BufferedReader reader = new Java.IO.BufferedReader(new Java.IO.InputStreamReader(s));
            while (true)
            {
                try {
                    if ((str = reader.ReadLine()) == null) break;
                }
                catch (IOException e) {
                    break;
                }
                strbuilder.Append(str).Append("\n");
            }
            s.Close();
            String foo = strbuilder.ToString();
            return foo;
        }

        public static bool ValidateEmail(String email = "")
        {
            return email.Contains("@") && email.Contains(".") && email!="";
        }

        public static void EmailTestResultsEmail(String email, String fileText = "", String fileInfo = "")
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(Credentials.emailFrom);

                mail.To.Add(email);
                mail.Subject = "Your story creative...";
                mail.Body = "Here is your story booklet! Emailed to you at " + DateTime.Now.ToString() +"\n" + fileText;

                System.Net.Mail.Attachment attachment;
                if (fileText == "")
                    fileText = Credentials.FileOut.FullName;
                if (fileInfo != "")
                {
                    FileInfo file = new FileInfo(fileInfo);
                    attachment = new System.Net.Mail.Attachment(fileText);
                    mail.Attachments.Add(attachment);
                }

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

        public static void EmailDev(String email, String devemail = "")
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(Credentials.emailFrom);

                mail.To.Add(devemail);
                mail.Subject = "Your story creative...";
                mail.Body = "Here is your story booklet! Emailed to you at " + DateTime.Now.ToString() + "\nThe email is " + email;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(Credentials.SMTPEmail, Credentials.SMTPPassword);
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
