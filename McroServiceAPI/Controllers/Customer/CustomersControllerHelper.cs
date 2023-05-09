using McroServiceAPI.Models.CustomersModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace McroServiceAPI.Controllers.Customer
{
    public class CustomersControllerHelper
    {
        public static async Task<IActionResult?> CheckLGAAndStateAsync(Customers customer, ServicesDbContext context)
        {
            // Map the LGA to the state selected
            var state = await context.Customers.FirstOrDefaultAsync(s => s.StateofResidence == customer.StateofResidence);
            if (state == null)
            {
                return new BadRequestObjectResult($"Invalid state: {customer.StateofResidence}");
            }

            var lga = await context.Customers.FirstOrDefaultAsync(l => l.LGA == customer.LGA);
            if (lga == null)
            {
                return new BadRequestObjectResult($"Invalid LGA: {customer.LGA}");
            }

            return null;
        }
    }
}
