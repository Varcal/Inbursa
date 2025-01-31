
namespace Inbursa.Application.Models
{
    public class ResponseModel<T>
    {
        public int StatusCode { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; } = new List<string>();

        public ResponseModel(int statusCode, T data)
        {
            StatusCode = statusCode;
            Data = data;
        }

        public ResponseModel(int statusCode, List<string> errors)
        {
            StatusCode = statusCode;
            Errors = errors;
        }

        public static ResponseModel<T> Success(T data) => new ResponseModel<T>(200, data);
        public static ResponseModel<T> Error(int statusCode, List<string> errors) => new ResponseModel<T>(statusCode, errors);
    }
}
