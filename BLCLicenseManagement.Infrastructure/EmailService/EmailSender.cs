using BLCLicenseManagement.Application.Contracts.Email;
using BLCLicenseManagement.Application.Models.Email;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLCLicenseManagement.Infrastructure.EmailService
{
    public class EmailSender : IEmailSender
    {
        public EmailSettings _emailSettings { get; }
        public EmailSender(IOptions<EmailSettings> options)
        {
            _emailSettings = options.Value;
        }
        public async Task<bool> SendEmail(EmailMessage email)
        {
            //implement this method with sendgrid or MailKit
            var client = new SendGridClient(_emailSettings.ApiKey);
            var to = new EmailAddress(email.To);
            var from = new EmailAddress(_emailSettings.FromAddress, _emailSettings.FromName);
            var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
            var response = await client.SendEmailAsync(message);
            //return response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.OK;
            return response.IsSuccessStatusCode;
        }

        public Task<bool> SendEmailAsync(EmailMessage email)
        {
            throw new NotImplementedException();
        }

        public Task SendEmailAsync(string toEmail, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}
