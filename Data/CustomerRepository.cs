using CustomerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Data
{
    public class CustomerRepository : BaseRepository<Customer>, IRepository<Customer>
    {
        public CustomerRepository(CustomerDbContext context): base(context)
        {
        }
    }
}