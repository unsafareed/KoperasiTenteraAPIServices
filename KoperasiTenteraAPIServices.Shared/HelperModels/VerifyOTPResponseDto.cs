namespace KoperasiTenteraAPIServices.Shared.HelperModels
{
    public class VerifyOTPResponseDto
    {
        public bool isValidated { get; set; }
        public string Message { get; set; } = default!;
    }
}
