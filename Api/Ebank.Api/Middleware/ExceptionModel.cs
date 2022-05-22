namespace Ebank.Api.Middleware
{
    public class ExceptionModel
    {
        public ExceptionModel(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }


        public int StatusCode { get; private set; }
        public string Message { get; private set; }
    }
}
