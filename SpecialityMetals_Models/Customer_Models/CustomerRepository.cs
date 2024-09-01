using Microsoft.EntityFrameworkCore;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.Customer_Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Customer_Conext _context;

        public CustomerRepository(Customer_Conext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customer.ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            return await _context.Customer.FindAsync(customerId);
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            _context.Customer.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> DeleteCustomerAsync(int customerId)
        {
            var customer = await _context.Customer.FindAsync(customerId);
            if (customer == null)
            {
                return false;
            }

            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
