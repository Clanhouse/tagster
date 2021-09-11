using System.Net;
using System.Text.Json.Serialization;

namespace Tagster.Exception.Models
{
    public class ExceptionResponse
    {
        public object Response { get; }
        [JsonIgnore]
        public HttpStatusCode StatusCode { get; }

        public ExceptionResponse(object response, HttpStatusCode statusCode)
        {
            Response = response;
            StatusCode = statusCode;
        }
    }
}