using EndProject.Models.ViewModels.MailSender;

namespace EndProject.Abstractions.MailService
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequestVM mailRequest);
    }
}
