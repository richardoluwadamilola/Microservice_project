using System.ComponentModel.DataAnnotations;

namespace McroServiceAPI.Models
{
    public class SmsMessage
    {
        public string? To { get; set; }

        public string? From { get; set; }

        public string? Otp { get; set; }
    }
}
