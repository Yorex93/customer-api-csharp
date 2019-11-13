using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApi.Contracts;
using CustomerApi.Exceptions;
using CustomerApi.Models;
using CustomerApi.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomerApi.Controllers
{
    [ApiController]
    [Route("/api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;

        private readonly ICustomerService _customerService;

        public CustomersController (ILogger<CustomersController> logger, ICustomerService customerService) {
            this._logger = logger;
            this._customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult> GetCustomers()
        {
            IEnumerable<Customer> customers = await _customerService.GetAllCustomers();
            return Ok(customers.ToList());
        }


        [HttpPost]
        public async Task<ActionResult> CreateCustomer([FromBody] CustomerCreateRequest customerCreateRequest)
        {
            Customer newCustomer = await _customerService.CreateCustomer(customerCreateRequest);
            return Created("", newCustomer);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCustomerById(long id)
        {
            Customer customer = await _customerService.GetCustomerById(id);

            if (customer == null)
            {
                return NotFound("Customer not found");
            }

            return Ok(customer);
        }

    
        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateCustomerbyId(long id, [FromBody] JsonPatchDocument<Customer> customerUpdateRequest)
        {
            try {
                Customer newCustomer = await _customerService.UpdateCustomerbyId(id, customerUpdateRequest);
                return NoContent();
            } catch (NotFoundException e) {
                _logger.LogError($"Customer with Id {id} found", e);
                return NotFound("Customer not found");
            }
        }
    }
}