using KoperasiTenteraAPIServices.Shared.HelperModels;

namespace KoperasiTenteraAPIServices.Application.Interfaces.OTP
{
    public interface IOTPService
    {
        Task<GenerateOTPResponseDto> GenerateOTPAndSendAsync(GenerateOTPRequestDto request, CancellationToken ct);
        Task<VerifyOTPResponseDto> VerifyOTPAsync(VerifyOTPRequestDto request, CancellationToken ct);
    }
}
