using McroServiceAPI.Controllers.Customer;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace McroServiceAPI
{
    public class OTPMockService
    {
        public string GenerateOTP()
        {
            // Implementation code to generate a random OTP
            // Return the generated OTP
            Random random = new Random();
            int otpNumber = random.Next(1000, 9999); // Generate a random number between 1000 and 9999
            string otp = otpNumber.ToString(); // Convert the number to a string
            return otp;
        }

        public async void SendOTP(string PhoneNumber, string Otp)
        {
            // Implementation code goes here to simulate sending OTP via SMS or email
            const string accountSid = "AC45ec19c652cf88542e5d83c0129860ce";
            const string authToken = "e0148274467e8280b6558d294d51e9e9";
            const string twilioPhoneNumber = "+12765823356";

            TwilioClient.Init(accountSid, authToken);

            var message = await MessageResource.CreateAsync(
                body: $"Your OTP is {Otp}",
                from: new Twilio.Types.PhoneNumber(twilioPhoneNumber),
                to: new Twilio.Types.PhoneNumber(PhoneNumber)
            );
        }

        public bool VerifyOTP(string phoneNumber, string otp)
        {
            // Implementation code goes here to simulate verifying OTP
            // Return true if OTP is verified successfully, false otherwise
            if (otp == "1234") // Assuming 1234 is the correct OTP
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
