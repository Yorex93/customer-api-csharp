using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApi.Models;
using CustomerApi.Data;
using CustomerApi.Contracts;
using Microsoft.AspNetCore.JsonPatch;
using CustomerApi.Exceptions;

namespace CustomerApi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;
        public CustomerService (IRepository<Customer> customerRepository) {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> CreateCustomer(CustomerCreateRequest customerCreateRequest)
        {
            // TODO Possibly check for existing emails
            var customer = new Customer
            {
                FirstName = customerCreateRequest.firstName,
                LastName = customerCreateRequest.lastName,
                Email = customerCreateRequest.email,
                OtherNames = customerCreateRequest.otherNames,
                Phone = customerCreateRequest.phone,
            };
            return await _customerRepository.SaveAsync(customer);
        }

        public async Task DeleteCustomerById(long customerId)
        {
            Customer customer = await _customerRepository.FindByIdAsync(customerId);
            if (customer == null)
            {
                // Throw custom NotFoundException ?
                throw new NotFoundException("Customer not found");
            }
            await _customerRepository.DeleteAsync(customer);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _customerRepository.FndAllAsync();
        }

        public async Task<Customer> GetCustomerById(long customerId)
        {
            return await _customerRepository.FindByIdAsync(customerId);
        }

        public async Task<Customer> UpdateCustomerbyId(long customerId, JsonPatchDocument<Customer> customerUpdateRequest)
        {

            // TODO
            // Typically one should use a DTO to avoid updating fields like Timestamps
            // Typical example would be to Map to DTO then merge and Map back to entity

            Customer customerToUpdate = await _customerRepository.FindByIdAsync(customerId);
            if(customerToUpdate == null) {
                throw new NotFoundException("Customer not found");
            }
            customerUpdateRequest.ApplyTo(customerToUpdate);
            await _customerRepository.UpdateAsync(customerToUpdate);
            return customerToUpdate;
        }
    }
}