using Microsoft.AspNetCore.Identity;
using MVC_Assignment_1.Models;
using System.Threading.Tasks;

namespace MVC_Assignment_1.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);

        Task<SignInResult> PasswordSignInAsync(SignInModel signInModel);

        Task SignOutAsync();

        Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model);

        Task<IdentityResult> ConfirmEmailAsync(string uid, string token);

        Task GenerateEmailConfirmationTokenAsync(ApplicationUser user);

        Task<ApplicationUser> GetUserByEmailAsync(string email);
    }
}