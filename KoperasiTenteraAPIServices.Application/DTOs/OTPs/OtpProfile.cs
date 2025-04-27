using AutoMapper;
using KoperasiTenteraAPIServices.Domain.Models.Database_Models;
using KoperasiTenteraAPIServices.Shared.HelperModels;
using NUlid;

namespace KoperasiTenteraAPIServices.Application.DTOs.OTPs
{
    public class OtpProfile : Profile
    {
        public OtpProfile()
        {
            CreateMap<GenerateOTPRequestDto, CustomerOtpVerification>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(_ => Ulid.NewUlid().ToString()))
                .ForMember(destination => destination.Purpose, opt => opt.MapFrom(_ => _.OtpPurpose))
                .ForMember(destination => destination.CustomerReference, opt => opt.MapFrom(_ => _.CustomerId))
                .ForMember(destination => destination.ExpiryTime, opt => opt.MapFrom(_ => DateTime.Now.AddMinutes(5)))
                .ForMember(destination => destination.CreatedBy, opt => opt.MapFrom(_ => "System"))
                .ForMember(destination => destination.CreatedAt, opt => opt.MapFrom(_ => DateTime.Now));
        }
    }
}
