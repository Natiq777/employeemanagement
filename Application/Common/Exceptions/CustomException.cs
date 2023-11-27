using System.Net; 

namespace Application.Common.Exceptions
{ 
    public sealed class CustomException : Exception       
    {
        public HttpStatusCode HttpStatus { get; set; }

        public CustomException(string message, HttpStatusCode httpStatus)
            : base(message)
        {
            HttpStatus = httpStatus;
        }
    }
}
