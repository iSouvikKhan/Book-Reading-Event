using MVC_Assignment.Web.Models;
using System.Threading.Tasks;

namespace MVC_Assignment.Web.Service
{
    public interface IEmailService
    {
        Task SendTestEmail(UserEmailOptions userEmailOptions);

        Task SendEmailForEmailConfirmation(UserEmailOptions userEmailOptions);
    }
}