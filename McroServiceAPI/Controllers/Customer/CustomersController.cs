using McroServiceAPI.Models.CustomersModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace McroServiceAPI.Controllers.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ServicesDbContext _serviceDbContext;
        public CustomersController(ServicesDbContext serviceDbContext)
        {
            _serviceDbContext = serviceDbContext;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var customers = await _serviceDbContext.Customers.ToListAsync();
            return Ok(customers);
        }

        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetCustomerByIdAsync(int id)
        {
            Customers? customer = await _serviceDbContext.Customers.FindAsync(id);
            return Ok(customer);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] Customers customer)
        {
            var otpService = new OTPMockService();
            var otp = otpService.GenerateOTP();
            otpService.SendOTP(customer.PhoneNumber, otp);

            // Map the LGA to the state selected
            var validationResult = await CustomersControllerHelper.CheckLGAAndStateAsync(customer, _serviceDbContext);
            if (validationResult != null)
            {
                return validationResult;
            }

            _serviceDbContext.Customers.Add(customer);
            await _serviceDbContext.SaveChangesAsync();

            return Ok(customer);

        }

        // DELETE api/<CustomersController>
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var customerToDelete = await _serviceDbContext.Customers.FindAsync(id);
            if (customerToDelete == null)
            {
                return NotFound();
            }
            _serviceDbContext.Customers.Remove(customerToDelete);
            await _serviceDbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
