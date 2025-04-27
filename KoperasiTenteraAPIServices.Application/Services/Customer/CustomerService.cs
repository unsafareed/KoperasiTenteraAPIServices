using AutoMapper;
using KoperasiTenteraAPIServices.Application.DTOs.Customers;
using KoperasiTenteraAPIServices.Application.Inerfaces.Customers;
using KoperasiTenteraAPIServices.Domain.Models.Database_Models;
using KoperasiTenteraAPIServices.Domain.Repositories.Customers;
using KoperasiTenteraAPIServices.Shared.Exceptions;
using KoperasiTenteraAPIServices.Shared.HelperModels;
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

        public async Task<RegisterCustomerResponseDTO> RegisterCustomerAsync(RegisterCustomerDTO customer, CancellationToken ct)
        {
            ExceptionModel exceptionModel = new ExceptionModel();

            try
            {
                bool isCustomerExists = await _CustomerRepository.IsCustomerExistsAsync(customer.ICNumber, ct);

                if (isCustomerExists)
                {
                    exceptionModel.Title = "Account already exist";    
                    exceptionModel.Message = "There is account registered with the ICNumber.Please Login to Continue.";
                    exceptionModel.StatusCode = 400;

                    throw new BusinessFailureException(exceptionModel);
                }

                Customer Customer = _mapper.Map<Customer>(customer);

                string customerId = await _CustomerRepository.RegisterCustomerAsync(Customer, ct);

                RegisterCustomerResponseDTO response = new RegisterCustomerResponseDTO()
                {
                    CustomerId = customerId
                };

                return response;
            }
            catch(BusinessFailureException ex)
            {
                _logger.LogError(ex, ex.Message);
                
                throw new BusinessFailureException(400, exceptionModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                throw new Exception(ex.Message);
            }
        }

        public async Task<GetCustomerDto> CustomerLoginByICNumberAsync(string IcNumber, CancellationToken ct)
        {
            ExceptionModel exceptionModel = new ExceptionModel();

            try
            {
                Customer? customer = await _CustomerRepository.GetCustomerByIcNumberAsync(IcNumber, ct);

                if(customer is null)
                {
                    exceptionModel.Title = "Account not found";
                    exceptionModel.Message = "There is no account registered with the ICNumber.Please Register to Continue.";
                    exceptionModel.StatusCode = 400;

                    throw new BusinessFailureException(exceptionModel);
                }

                GetCustomerDto mappedObject = _mapper.Map<GetCustomerDto>(customer);

                return mappedObject;
            }
            catch (BusinessFailureException ex)
            {
                _logger.LogError(ex, ex.Message);

                throw new BusinessFailureException(400, exceptionModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> SetCustomerPinAsync(SetCustomerPinDto request, CancellationToken ct)
        {
            ExceptionModel exceptionModel = new ExceptionModel();

            try
            {
                (string customerId, string pin) customerIdAndPin = (request.CustomerId, request.Pin);

                var updatedRecords = await _CustomerRepository.SetCustomerPinAsync(customerIdAndPin, ct);

                if (updatedRecords is not 1)
                {
                    exceptionModel.Title = "Customer Pin Not Set";
                    exceptionModel.Message = "Unable to set pin for this customer.";
                    exceptionModel.StatusCode = 400;

                    throw new BusinessFailureException(exceptionModel);
                }

                return true;
            }
            catch (BusinessFailureException ex)
            {
                _logger.LogError(ex, ex.Message);

                throw new BusinessFailureException(400, exceptionModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                throw new Exception(ex.Message);
            }
        }
        
        public async Task<bool> VerifyCustomerPinAsync(VerifyCustomerPinDto request, CancellationToken ct)
        {
            ExceptionModel exceptionModel = new ExceptionModel();

            try
            {
                (string customerId, string pin) customerIdAndPin = (request.CustomerId, request.Pin);

                bool isValidated = await _CustomerRepository.VerifyCustomerPinAsync(customerIdAndPin, ct);

                if (!isValidated)
                {
                    exceptionModel.Title = "Unmatched PIN";
                    exceptionModel.Message = "Please enter your PIN again";
                    exceptionModel.StatusCode = 400;

                    throw new BusinessFailureException(exceptionModel);
                }

                return true;
            }
            catch (BusinessFailureException ex)
            {
                _logger.LogError(ex, ex.Message);

                throw new BusinessFailureException(400, exceptionModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> SetCustomerBiometricAsync(SetCustomerBiometric request, CancellationToken ct)
        {
            ExceptionModel exceptionModel = new ExceptionModel();

            try
            {
                (string customerId, byte[] biometric) customerIdAndBiometric = (request.CustomerId, request.Biometric);

                var updatedRecords = await _CustomerRepository.SetCustomerBiometricAsync(customerIdAndBiometric, ct);

                if (updatedRecords is not 1)
                {
                    exceptionModel.Title = "Customer Biometric Not Set";
                    exceptionModel.Message = "Unable to set biometric for this customer.";
                    exceptionModel.StatusCode = 400;

                    throw new BusinessFailureException(exceptionModel);
                }

                return true;
            }
            catch (BusinessFailureException ex)
            {
                _logger.LogError(ex, ex.Message);

                throw new BusinessFailureException(400, exceptionModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                throw new Exception(ex.Message);
            }
        }
    }
}