using AutoMapper;
using KoperasiTenteraAPIServices.Application.DTOs.Customers;
using KoperasiTenteraAPIServices.Application.Inerfaces.Customers;
using KoperasiTenteraAPIServices.Domain.Models.Database_Models;
using KoperasiTenteraAPIServices.Domain.Repositories.Customers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace KoperasiTenteraAPIServices.Application.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ILogger<CustomerService> _logger;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _CustomerRepository;

        public CustomerService(ILogger<CustomerService> logger,
                            IConfiguration config,
                            IMapper mapper,
                            ICustomerRepository CustomerRepository)
        {
            _logger = logger;
            _config = config;
            _mapper = mapper;
            _CustomerRepository = CustomerRepository;
        }

        public async Task<RegisterCustomerResponseDTO> RegisterUser(RegisterCustomerDTO customer, CancellationToken ct)
        {
            try
            {
                bool isCustomerExists = await _CustomerRepository.IsCustomerExistsAsync(customer.ICNumber, ct);

                if (isCustomerExists)
                {
                    throw new Exception("There is account registered with the ICNumber.Please Login to Continue");

                }

                Customer Customer = _mapper.Map<Customer>(customer);

                string userId = await _CustomerRepository.RegisterCustomerAsync(Customer, ct);

                return new RegisterCustomerResponseDTO();


               
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }

}
