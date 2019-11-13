using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerApi.Controllers;
using CustomerApi.Models;
using CustomerApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace CustomerApi.Tests
{
    public class CustomerControllerTest
    {
    
        [Fact]
        public async Task GetCustomer_Returns_ArrayOfCustomers () {

            var mockService = new Mock<ICustomerService>();
            mockService.Setup(service => service.GetAllCustomers()).ReturnsAsync(getMockCustomers());
            var mockLogger = new Mock<ILogger<CustomersController>>();

            var controller = new CustomersController(mockLogger.Object, mockService.Object);

            var result = await controller.GetCustomers();

            var okResult = result as OkObjectResult;

            Assert.NotNull(okResult);
            Assert.NotNull(okResult.Value);

            var customers = (List<Customer>) okResult.Value;
            Assert.Equal(1, customers.Count);

        }

        private List<Customer> getMockCustomers () {
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer {
                FirstName = "Emmanuel",
                LastName = "Igbodudu",
                Phone = "09099999999",
                Email = "email@email.com"
            });
            return customers;
        }
    }
}