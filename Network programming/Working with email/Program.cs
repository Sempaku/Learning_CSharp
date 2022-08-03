using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Работа_с_электронной_почтой
{
    class Program
    {
        static void Main(string[] args)
        {
            MailAddress from = new MailAddress("cemen72421@gmail.com", "Semyon");
            MailAddress to = new MailAddress("cemen72421@gmail.com", "Sss");
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Theme";
            m.Body = "<b>Text</b>";
            m.IsBodyHtml = true;

            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com",465);
            smtp.Credentials = new NetworkCredential("cemen72421@gmail.com", "password");
            smtp.EnableSsl = true;
            smtp.Send(m);
            Console.Read();

        }
    }
}
