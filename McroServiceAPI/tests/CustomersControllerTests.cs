using McroServiceAPI.Controllers.Customer;
using McroServiceAPI.Models.CustomersModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace McroServiceAPI.tests
{
    public class CustomersControllerTests
    {
        private readonly DbContextOptions<ServicesDbContext> _dbContextOptions;

        public CustomersControllerTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ServicesDbContext>()
                .UseInMemoryDatabase(databaseName: "TestServicesDb")
                .Options;
        }

        [Fact]
        public async Task Get_ReturnsCustomersList()
        {
            // Arrange
            using (var context = new ServicesDbContext(_dbContextOptions))
            {
                context.Customers.AddRange(
                    new Customers { FirstName = "Oluwadamilola", LastName = "Richard" },
                    new Customers { FirstName = "Rhoda", LastName = "Richard" }
                );
                context.SaveChanges();
            }

            using (var context = new ServicesDbContext(_dbContextOptions))
            {
                var controller = new CustomersController(context);

                // Act
                var result = await controller.GetAsync();

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                var customers = Assert.IsType<List<Customers>>(okResult.Value);
                Assert.Equal(2, customers.Count);
            }
        }

        [Fact]
        public async Task GetCustomerById_ReturnsCustomerById()
        {
            // Arrange
            using (var context = new ServicesDbContext(_dbContextOptions))
            {
                context.Customers.Add(new Customers { Id = 1, FirstName = "Oluwadamilola", LastName = "Richard" });
                context.SaveChanges();
            }

            using (var context = new ServicesDbContext(_dbContextOptions))
            {
                var controller = new CustomersController(context);

                // Act
                var result = await controller.GetCustomerByIdAsync(1);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                var customer = Assert.IsType<Customers>(okResult.Value);
                Assert.Equal("Oluwadamilola", customer.FirstName);
                Assert.Equal("Richard", customer.LastName);
            }
        }
    }
}
