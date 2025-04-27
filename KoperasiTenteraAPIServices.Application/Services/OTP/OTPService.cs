using AutoMapper;
using FastEnumUtility;
using KoperasiTenteraAPIServices.Application.Interfaces.OTP;
using KoperasiTenteraAPIServices.Domain.Communication;
using KoperasiTenteraAPIServices.Domain.Models.Database_Models;
using KoperasiTenteraAPIServices.Domain.Repositories.Customers;
using KoperasiTenteraAPIServices.Domain.Repositories.OTPs;
using KoperasiTenteraAPIServices.Shared.Exceptions;
using KoperasiTenteraAPIServices.Shared.HelperModels;
using KoperasiTenteraAPIServices.Shared.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace KoperasiTenteraAPIServices.Application.Services.OTP
{
    public class OTPService : IOTPService
    {
        private readonly ILogger<OTPService> _logger;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IOTPRepository _oTPRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ISmtpEmailSender _mailingService;
        private readonly ISmsService _smsService;

        public OTPService(ILogger<OTPService> logger,
                         IConfiguration config,
                         IMapper mapper,
                         IOTPRepository oTPRepository,
                         ISmtpEmailSender mailingService,
                         ICustomerRepository customerRepository,
                         ISmsService smsService)
        {
            _logger = logger;
            _config = config;
            _mapper = mapper;
            _oTPRepository = oTPRepository;
            _mailingService = mailingService;
            _customerRepository = customerRepository;
            _smsService = smsService;
        }

        public async Task<GenerateOTPResponseDto> GenerateOTPAndSendAsync(GenerateOTPRequestDto request, CancellationToken ct)
        {
            ExceptionModel exceptionModel = new ExceptionModel();
            GenerateOTPResponseDto response = new GenerateOTPResponseDto();

            try
            {
                string OTP = OtpGenerator.GenerateOTP();

                var mappedObject = _mapper.Map<CustomerOtpVerification>(request);

                mappedObject.OtpCode = OTP;

                bool isOTPStored = await _oTPRepository.GenerateOTP(mappedObject, ct);

                if (!isOTPStored)
                {
                    exceptionModel.Title = "OTP Generation Failed";
                    exceptionModel.Message = "Failed to generate OTP.";
                    exceptionModel.StatusCode = 400;

                    throw new BusinessFailureException(exceptionModel);
                }

                var customerDetails = await _customerRepository.GetCustomerDetailsByIdAsync(request.CustomerId, ct);

                if (request.OtpPurpose.FastToString() == "EmailVerification")
                {
                    string emailBody = $"Your OTP for verification is : {OTP}";
                    string subject = "Your One-Time Password (OTP) for Verification";

                    UserEmailOptions userEmail = new UserEmailOptions()
                    {
                        body = emailBody,
                        subject = subject,
                        toEmail = customerDetails!.Email
                    };

                    string sendEmailStatus = await _mailingService.SendEmail(userEmail);

                    if (sendEmailStatus != "Success")
                    {
                        response.IsSentSuccess = true;
                        response.OTP = OTP;

                        return response;
                    }
                }

                if (request.OtpPurpose.FastToString() == "PhoneVerification")
                {
                    SmsDto sms = new SmsDto()
                    {
                        Message = $"Your OTP for verification is : {OTP}",
                        MobileNo = customerDetails!.Phone,
                    };

                    bool isSmsSent = await _smsService.Send(sms);

                    if(isSmsSent)
                    {
                        response.IsSentSuccess = true;
                        response.OTP = OTP;

                        return response;
                    }
                }

                return response;
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

        public async Task<VerifyOTPResponseDto> VerifyOTPAsync(VerifyOTPRequestDto request, CancellationToken ct)
        {
            ExceptionModel exceptionModel = new ExceptionModel();

            try
            {
                (bool isValidated, string message) repoResponse = await _oTPRepository.VerifyOTP(request, ct);

                if (!repoResponse.isValidated)
                {
                    exceptionModel.Title = "OTP Verification Failed";
                    exceptionModel.Message = repoResponse.message;
                    exceptionModel.StatusCode = 400;

                    throw new BusinessFailureException(exceptionModel);
                }

                VerifyOTPResponseDto response = new VerifyOTPResponseDto() 
                {
                    isValidated = repoResponse.isValidated,
                    Message = repoResponse.message,
                };

                return response;
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