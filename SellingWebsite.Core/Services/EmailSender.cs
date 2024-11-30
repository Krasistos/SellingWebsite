using SellingWebsite.Core.Contracts;
using System.Net;
using System.Net.Mail;

namespace SellingWebsite.Core.Services
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            // Set up the SMTP client using MailerSend SMTP credentials
            var client = new SmtpClient("smtp.mailersend.net", 587)
            {
                EnableSsl = true, // Enable SSL for secure connection
                UseDefaultCredentials = false, // Don't use default credentials
                Credentials = new NetworkCredential(
                    "MS_yDqE4X@trial-v69oxl5rjo2g785k.mlsender.net", // Your MailerSend SMTP username
                    "StfHhlWOActJ1YN6" // Your MailerSend SMTP password (API key)
                )
            };

            // Set up the email message
            var mailMessage = new MailMessage(
                from: "MS_yDqE4X@trial-v69oxl5rjo2g785k.mlsender.net", // Your MailerSend email
                to: email,
                subject: subject,
                body: message
            );

            // Send the email asynchronously
            await client.SendMailAsync(mailMessage);
        
    }
    }
}
