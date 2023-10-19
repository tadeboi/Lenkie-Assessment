using Lenkie_Assessment.Domain;
using Lenkie_Assessment.Helpers;
using Lenkie_Assessment.Infrastructure;
using Lenkie_Assessment.Models;
using Lenkie_Assessment.Repositories.Interfaces;
using Lenkie_Assessment.Services.Interfaces;

namespace Lenkie_Assessment.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly LibraryDbContext _context;

        public CustomerService(ICustomerRepository customerRepository, LibraryDbContext context)
        {
            _customerRepository = customerRepository;
            _context = context;
        }

        public async Task<string> CreateUserAccount(SignUpModel model)
        {
            try
            {
                string hashedPassword = MiscUse.HashSHA512Managed(model.Password);

                var data = new Customer
                {
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,
                    Password = hashedPassword,
                    LastClientIpAddress = MiscUse.GetIpAddress(),
                    DateSignedUp = DateTime.UtcNow,
                    LastSeen = DateTime.UtcNow
                };

                await _customerRepository.AddCustomer(data);
                return "User Account Created Successfully";
            }
            catch (Exception ex)
            {

                return $"User Account Creation Failed. Error: {ex.Message}";
            }


        }

        public async Task<string> UserLogin(LoginModel model)
        {
            var status = "Login Failed";
            var theRealPass = MiscUse.HashSHA512Managed(model.Password);

            var userProfile = _context.Customers.FirstOrDefault(pm => pm.PhoneNumber == model.PhoneNumber);
            if (userProfile == null)
                return "Invalid username and password combination";

            if (userProfile.Password == theRealPass)
            {
                status = "Login Successful";
                userProfile.LastClientIpAddress = MiscUse.GetIpAddress();
                userProfile.LastSeen = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();

            return status;
        }
    }
}
