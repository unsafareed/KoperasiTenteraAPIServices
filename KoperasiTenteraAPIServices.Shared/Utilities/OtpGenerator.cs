namespace KoperasiTenteraAPIServices.Shared.Utilities
{
    public static class OtpGenerator
    {
        public static string GenerateOTP()
        {
            Random random = new Random();
            
            int otp = random.Next(1000, 9999);
            
            return otp.ToString();
        }
    }
}
