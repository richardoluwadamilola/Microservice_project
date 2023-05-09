using McroServiceAPI.Models.BanksModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace McroServiceAPI.Controllers.Banks
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        private readonly ActivityDbContext _activityDbContext;
        public BanksController(ActivityDbContext activityDbContext)
        {
            _activityDbContext = activityDbContext;
        }

        // GET: api/<BanksController>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetBankByIdAsync(int id)
        {
            var bank = await _activityDbContext.Banks.FindAsync(id);
            return Ok(bank);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task<IActionResult> PostAsync(Models.BanksModel.Banks bank)
        {
            _activityDbContext.Banks.Add(bank);
            await _activityDbContext.SaveChangesAsync();
            return Created($"/id={bank.Id}", bank);
        }

        // DELETE api/<CustomersController>
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var bankToDelete = await _activityDbContext.Banks.FindAsync(id);
            if (bankToDelete == null)
            {
                return NotFound();
            }
            _activityDbContext.Banks.Remove(bankToDelete);
            await _activityDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
