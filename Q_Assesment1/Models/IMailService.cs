using System.Threading.Tasks;

namespace Q_Assesment1.Models
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
