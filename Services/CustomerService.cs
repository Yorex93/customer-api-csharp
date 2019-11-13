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
                firstName = customerCreateRequest.firstName,
                lastName = customerCreateRequest.lastName,
                email = customerCreateRequest.email,
                otherNames = customerCreateRequest.otherNames,
                phone = customerCreateRequest.phone,
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