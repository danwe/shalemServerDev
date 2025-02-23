using shalemServer.Interfaces;
using System.Net.Mail;
using System.Net;

namespace shalemServer.Services
{
        public class EmailService : IEmailService
        {
            private readonly string _smtpServer = "smtp.yourmailserver.com"; // Use your SMTP server
            private readonly int _smtpPort = 587;
            private readonly string _smtpUser = "your-email@example.com";
            private readonly string _smtpPassword = "your-email-password";

            public async Task SendEmailAsync(string email, string subject, string body)
            {
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("no-reply@yourdomain.com"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(email);

                using (var smtpClient = new SmtpClient(_smtpServer, _smtpPort))
                {
                    smtpClient.Credentials = new NetworkCredential(_smtpUser, _smtpPassword);
                    smtpClient.EnableSsl = true;

                    await smtpClient.SendMailAsync(mailMessage);
                }
            }
        }
    
}
