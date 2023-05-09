using System;

using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using Microsoft.AspNetCore.Builder;

namespace TestClient
{
    class Program
    {
        public static void Main(string[] args)
        {
            var email = new MimeMessage();

            email.From.Add(new MailboxAddress("Sender Name", "oluwatobyrichard@gmail.com"));
            email.To.Add(new MailboxAddress("Receiver Name", "richardhorluwadammielola@gmail.com"));

            email.Subject = "Testing out email sending";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = "<b>Welcome to the bright side</b>"
            };

            using (var smtp = new SmtpClient())
            {
                smtp.Connect("smtp.gmail.com", 465, true);

                smtp.Send(email);
                smtp.Disconnect(true);
            }
        }
    }
}
