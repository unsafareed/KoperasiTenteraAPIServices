using KoperasiTenteraAPIServices.Domain.Models.Database_Models;
using KoperasiTenteraAPIServices.Domain.Repositories.OTPs;
using KoperasiTenteraAPIServices.Infrastructure.Context;
using KoperasiTenteraAPIServices.Shared.HelperModels;
using Microsoft.EntityFrameworkCore;

namespace KoperasiTenteraAPIServices.Infrastructure.Repositories.OTPs
{
    public class OTPRepository : IOTPRepository
    {
        private readonly APIServicesDbContext _context;

        public OTPRepository(APIServicesDbContext context)
        {
            _context = context;
        }

        public async Task<bool> GenerateOTP(CustomerOtpVerification entity, CancellationToken ct)
        {
            await _context.CustomerOtpVerifications.AddAsync(entity, ct);

            return await _context.SaveChangesAsync(ct) > 0;
        }

        public async Task<(bool isValidated, string message)> VerifyOTP(VerifyOTPRequestDto request, CancellationToken ct)
        {
            CustomerOtpVerification? entity = await _context.CustomerOtpVerifications
                                                       .Where(x => x.CustomerReference == request.CustomerId
                                                                && x.IsUsed == false
                                                                && x.IsDeleted == false)
                                                       .FirstOrDefaultAsync(ct);      

            if(entity is null)
            {
                return (false, "No OTP for the customer exists");
            }

            if (entity.OtpCode != request.OTP)
            {
                return (false, "Incorrect OTP");
            }

            if (DateTime.Now >= entity.ExpiryTime)
            {
                return (false, "OTP has expired.");
            }

            entity.IsDeleted = true;
            entity.IsUsed = true;
            entity.LastModifiedBy = "System";
            entity.LastModifiedAt = DateTime.Now;
            entity.DeletedAt = DateTime.Now;
            entity.DeletedBy = "System";

            _context.CustomerOtpVerifications.Update(entity);

            await _context.SaveChangesAsync(ct);

            return (true, "OTP is successfully validated."); ;
        }
    }
}
