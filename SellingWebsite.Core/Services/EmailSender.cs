using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using SellingWebsite.Core.Contracts;
using System.Net;
using System.Net.Mail;

namespace SellingWebsite.Core.Services
{
    public class EmailSender : IEmailSender
    {
        private IConfiguration configuration;
        public EmailSender(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SmtpClient(configuration["EmailService:Smtp:Host"], int.Parse(configuration["EmailService:Smtp:Port"]))
            {
                EnableSsl = true, // Enable SSL for secure connection
                UseDefaultCredentials = false, // Don't use default credentials
                Credentials = new NetworkCredential(
                    configuration["EmailService:Smtp:Username"], 
                    configuration["EmailService:Smtp:Password"]
                )
            };

            var mailMessage = new MailMessage(
                from: configuration["EmailService:Smtp:SenderEmail"], 
                to: email,
                subject: subject,
                body: message
            );

            await client.SendMailAsync(mailMessage);
        
    }
    }
}
