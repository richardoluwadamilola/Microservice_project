using McroServiceAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;

namespace McroServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {
       private readonly ITwilioRestClient _client;
        public SmsController(ITwilioRestClient client)
        {
            _client = client;
        }

        [HttpPost]
        public IActionResult SendSms(SmsMessage model)
        {
            //var OTP = new Random().Next(100000, 999999);

            var message = MessageResource.Create(
                to: new Twilio.Types.PhoneNumber(model.To),
                //from: new Twilio.Types.PhoneNumber(model.From),
                body: model.Otp,
                client: _client);
            return Ok("Success" + message.Sid);
        }
    }
}
