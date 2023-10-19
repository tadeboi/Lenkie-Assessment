using Lenkie_Assessment.Domain;
using Lenkie_Assessment.Infrastructure;
using Lenkie_Assessment.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lenkie_Assessment.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly LibraryDbContext _context;

        public CustomerRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetCustomer(Guid id)
        {
            var result = await _context.Customers.FindAsync(id);
            if (result == null) throw new Exception($"Customer with id: {id} does not exist");
            return result;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task AddCustomer(Customer model)
        {
            _context.Customers.Add(model);
            await _context.SaveChangesAsync();
        }
    }
}
