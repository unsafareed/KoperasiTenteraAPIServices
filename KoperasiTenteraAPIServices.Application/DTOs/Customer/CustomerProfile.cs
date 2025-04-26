using AutoMapper;
using KoperasiTenteraAPIServices.Domain.Models.Database_Models;
using NUlid;

namespace KoperasiTenteraAPIServices.Application.DTOs.Customers
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<RegisterCustomerDTO, Customer>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(_ => Ulid.NewUlid().ToString()))
                .ForMember(destination => destination.CreatedBy, opt => opt.MapFrom(_ => "System"))
                .ForMember(destination => destination.CreatedAt, opt => opt.MapFrom(_ => DateTime.Now));
        }
    }
}
