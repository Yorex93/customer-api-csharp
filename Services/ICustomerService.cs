using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerApi.Contracts;
using CustomerApi.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace CustomerApi.Services
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomer(CustomerCreateRequest customerCreateRequest);
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(long customerId);
        Task<Customer> UpdateCustomerbyId(long customerId, JsonPatchDocument<Customer> customerUpdateRequest);
        Task DeleteCustomerById(long customerId);
    }
}