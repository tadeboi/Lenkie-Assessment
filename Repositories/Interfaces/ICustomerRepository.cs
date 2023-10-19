using Lenkie_Assessment.Domain;

namespace Lenkie_Assessment.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomer(Guid id);
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task AddCustomer(Customer model);
    }
}
