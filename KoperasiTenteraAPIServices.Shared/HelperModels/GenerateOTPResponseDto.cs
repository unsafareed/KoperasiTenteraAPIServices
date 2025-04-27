namespace KoperasiTenteraAPIServices.Shared.HelperModels
{
    public class GenerateOTPResponseDto
    {
        public string OTP { get; set; } = default!;
        public bool IsSentSuccess { get; set; } = default!;
    }
}
