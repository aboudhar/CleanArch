using BLCLicenseManagement.Application.Models.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLCLicenseManagement.Application.Contracts.Email
{
    public interface IEmailSender
    {
        Task <bool> SendEmailAsync (EmailMessage email);
        Task <bool> SendEmail (EmailMessage email);
        Task SendEmailAsync(string toEmail, string subject, string body);
    }
}
