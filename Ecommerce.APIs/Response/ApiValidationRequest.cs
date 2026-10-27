namespace Ecommerce.APIs.Response
{
    public class ApiValidationRequest: ApiErrorResponse
    {
        public ApiValidationRequest() : base(400)
        {
        }

        public IEnumerable<string> Errors { get; set; } = new List<string>();
    }
}
