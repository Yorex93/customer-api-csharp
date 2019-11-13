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
            mockService.Setup(service => service.GetAllCustomers()).ReturnsAsync(new List<Customer>());
            var mockLogger = new Mock<ILogger<CustomersController>>();

            var controller = new CustomersController(mockLogger.Object, mockService.Object);

            var result = await controller.GetCustomers();

            Assert.IsType<OkResult>(result);
        }
    }
}