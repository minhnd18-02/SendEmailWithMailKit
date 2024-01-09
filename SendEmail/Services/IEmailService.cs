using SendEmail.Models;

namespace SendEmail.Services;

public interface IEmailService
{
    Task SendEmail(EmailDTO request);
}