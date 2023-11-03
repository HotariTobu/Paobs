using System;
using System.Linq;

namespace Paobs
{
    class MailIO
    {
        public static void SendMail(string subject, string text, params string[] madList)
        {
            LogIO.LogEvents($"Sending Mail To {string.Join(", ", madList)}");

            MimeKit.MimeMessage message = new MimeKit.MimeMessage();
            message.From.Add(new MimeKit.MailboxAddress("ほたりサポート", "hotari13port@gmail.com"));
            foreach (string mad in madList)
            {
                message.To.Add(new MimeKit.MailboxAddress(new string(mad.TakeWhile(c => c != '@').ToArray()), mad));
            }

            message.Subject = $"[{Program.AssemblyName}]{LogIO.TimeText}[{Program.UserName}]{subject}";
            message.Body = new MimeKit.TextPart(MimeKit.Text.TextFormat.Plain) { Text = text, };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                try
                {
                    client.Connect("smtp.gmail.com");
                    client.Authenticate("hotari13port@gmail.com", "zqcftdfninfhtvbj");
                    client.Send(message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    client.Disconnect(true);
                }
            }

            LogIO.LogEvents($"Sent Mail To {string.Join(", ", madList)}");
        }
    }
}
