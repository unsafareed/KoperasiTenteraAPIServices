using KoperasiTenteraAPIServices.Shared.HelperModels;

namespace KoperasiTenteraAPIServices.Shared.Exceptions
{
    public class BusinessFailureException : Exception
    {
        public int StatusCode { get; }
        public ExceptionModel ExceptionDetails { get; }

        public BusinessFailureException(ExceptionModel exceptionDetails)
            : base(exceptionDetails?.Message)
        {
            ExceptionDetails = exceptionDetails ?? throw new ArgumentNullException(nameof(exceptionDetails));
            StatusCode = exceptionDetails.StatusCode; // Default pick from model
        }

        public BusinessFailureException(int statusCode, ExceptionModel exceptionDetails)
            : base(exceptionDetails?.Message)
        {
            ExceptionDetails = exceptionDetails ?? throw new ArgumentNullException(nameof(exceptionDetails));
            StatusCode = statusCode;
        }
    }

}
