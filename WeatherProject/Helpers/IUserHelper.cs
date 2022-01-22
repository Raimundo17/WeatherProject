using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WeatherProject.Data.Entities;
using WeatherProject.Models;

namespace WeatherProject.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email); // dou o email e dá uma string (Bypass)

        Task<IdentityResult> AddUserAsync(User user, string password);

          Task<SignInResult> LoginAsync(LoginViewModel model); // verifica se o utilizador entrou ou não

        Task LogoutAsync();

        Task<SignInResult> ValidatePasswordAsync(User user, string password);

        Task<string> GenerateEmailConfirmationTokenAsync(User user);

        Task<IdentityResult> ConfirmEmailAsync(User user, string token);

        Task<User> GetUserByIdAsync(string userId); // dou o email e dá uma string (Bypass)

        Task<string> GeneratePasswordResetTokenAsync(User user);

        Task<IdentityResult> ResetPasswordAsync(User user, string token, string password);

        Task<IdentityResult> UpdateUserAsync(User user); // muda o primeiro e o último nome

        Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword);

        Task<User> GetUserAsync(string id);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

        public IQueryable AllUsers();

        public Task<bool> CheckUserAndPassword(string email, string password);

    }
}
