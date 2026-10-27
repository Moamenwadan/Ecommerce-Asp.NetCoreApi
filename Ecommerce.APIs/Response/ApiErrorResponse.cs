using System.Net.NetworkInformation;

namespace Ecommerce.APIs.Response
{
    public class ApiErrorResponse
    {
        public int Status { get; set; }
        public string? Message { get; set; }
        public ApiErrorResponse(int status, string? message = null)
        {
            Status = status;
            Message = message ?? GetErrorMessage(Status);
        }

        public string GetErrorMessage(int Status)
        {
            switch (Status) {
                case 400:
                    return "BadRequest, you made a badRequest";
                case 401:
                    return "UnAuthorized,you aren't authorized ";
                case 403:
                    return "Forbidden,";
                case 404:
                    return "Not Found, The Data that you Search on it is doesn't exist";
                case 500:
                    return "Internal Server Error,";

                default:
                    return "Error Occur";
            }
        }




    }
}
