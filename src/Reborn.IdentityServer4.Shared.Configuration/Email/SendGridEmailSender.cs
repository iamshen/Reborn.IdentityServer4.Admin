using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using Reborn.IdentityServer4.Shared.Configuration.Configuration.Email;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Reborn.IdentityServer4.Shared.Configuration.Email;

public class SendGridEmailSender : IEmailSender
{
    private readonly ISendGridClient _client;
    private readonly SendGridConfiguration _configuration;
    private readonly ILogger<SendGridEmailSender> _logger;

    public SendGridEmailSender(ILogger<SendGridEmailSender> logger, SendGridConfiguration configuration,
        ISendGridClient client)
    {
        _logger = logger;
        _configuration = configuration;
        _client = client;
    }

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var message = MailHelper.CreateSingleEmail(
            new EmailAddress(_configuration.SourceEmail, _configuration.SourceName),
            new EmailAddress(email),
            subject,
            null,
            htmlMessage
        );

        // More information about click tracking: https://sendgrid.com/docs/ui/account-and-settings/tracking/
        message.SetClickTracking(_configuration.EnableClickTracking, _configuration.EnableClickTracking);

        var response = await _client.SendEmailAsync(message);

        switch (response.StatusCode)
        {
            case HttpStatusCode.OK:
            case HttpStatusCode.Created:
            case HttpStatusCode.Accepted:
                _logger.LogInformation($"Email: {email}, subject: {subject}, message: {htmlMessage} successfully sent");
                break;
            default:
            {
                var errorMessage = await response.Body.ReadAsStringAsync();
                _logger.LogError(
                    $"Response with code {response.StatusCode} and body {errorMessage} after sending email: {email}, subject: {subject}");
                break;
            }
        }
    }
}