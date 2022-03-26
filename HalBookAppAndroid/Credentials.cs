using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmailReader
{
    public class Credentials
    {
        public static FileInfo FileIn = new FileInfo(@"Resources\layout\Halbook.txt");

        public static FileInfo FileOut = new FileInfo(@"Resources\layout\Reflections.docx");

        public static String FileInString = MakeFileName("Halbook.txt");

        public static String emailFrom = "berrylantis@gmail.com";

        public static String SMTPEmail = emailFrom;//"Abcs";

        public static String SMTPHost = "smtp.sendgrid.com";//"Abcs";

        public static String SMTPPassword = "";//"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";

        public static String MakeFileName(String name)
        {
            string f = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), name);
            return f;

        }

    }
}
