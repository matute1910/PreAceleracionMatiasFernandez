using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ChallengerDisney.Core.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ChallengerDisney.Core.Services
{
    public class EmailServices : IEmailServices
    {
        public async Task SendEmail(string email, string subject, string htmlContext)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("matute1910@gmail.com");
            var to = new EmailAddress(email);
            var plainTextContent = Regex.Replace(htmlContext, "<[ *> *]", ",");
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContext);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
