using Lenkie_Assessment.Models;

namespace Lenkie_Assessment.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<string> CreateUserAccount(SignUpModel model);
        Task<string> UserLogin(LoginModel model);
    }
}
