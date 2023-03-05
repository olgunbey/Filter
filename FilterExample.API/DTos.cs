using Microsoft.AspNetCore.Mvc;

namespace FilterExample.API
{
    public class DTos<T>
    {
        public T Data { get; set; }
        public List<string> Errors { get; set; }
        public int StatusCode { get; set; }
        public static DTos<T> Success(int _StatusCode, T _data) {
            return new DTos<T>() { StatusCode = _StatusCode, Data = _data };
        }
        public static DTos<T> Success(int _statusCode)
        {
            return new DTos<T>() { StatusCode = _statusCode };
        }
        public static DTos<T> Fail(int _statusCode, List<string> Errors)
        {
            return new DTos<T> { StatusCode = _statusCode, Errors = Errors };
        }
        public static DTos<T> Fail(int _statusCode, string Error)
        {
            return new DTos<T>() { StatusCode = _statusCode, Errors = new List<string> { Error } };
        }

        public readonly struct Response
        {
            public IActionResult ResponseData(DTos<T> data)
            {
                if (data.StatusCode == 204)
                {
                    return new ObjectResult(null);
                }
                else
                {
                    return new ObjectResult(data) { StatusCode = data.StatusCode };
                }
                
            }

        }
    }
}
