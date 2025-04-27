using KoperasiTenteraAPIServices.Domain.Models.Database_Models;
using KoperasiTenteraAPIServices.Shared.HelperModels;

namespace KoperasiTenteraAPIServices.Domain.Repositories.OTPs
{
    public interface IOTPRepository
    {
        Task<bool> GenerateOTP(CustomerOtpVerification entity, CancellationToken ct);
        Task<(bool isValidated, string message)> VerifyOTP(VerifyOTPRequestDto request, CancellationToken ct);
    }
}
