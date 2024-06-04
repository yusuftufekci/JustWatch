using JustWatch.Domain.SeedWork;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace JustWatch.Application.Common.Responses
{
    public record Response : IResponse
    {
        public bool IsSuccess { get; init; }

        public string Message { get; init; } = string.Empty;

        public static Response Success(string message = "")
        {
            return new Response() { IsSuccess = true, Message = message };
        }

        public static Response Error(string message = "")
        {
            return new Response() { IsSuccess = false, Message = message };
        }
        public override string ToString() => JsonConvert.SerializeObject(this, new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        });

    }
    public record Response<T> : IResponse
    {
        public T Data { get; init; }
        public bool IsSuccess { get; init; }

        public string Message { get; init; } = string.Empty;

        public static Response<T> Success(T data, string message = "")
        {
            return new Response<T> { Data = data, Message = message, IsSuccess = true };
        }

        public static Response<T> Error(string message = "")
        {
            return new Response<T> { Message = message, IsSuccess = false };
        }

        public override string ToString() => JsonConvert.SerializeObject(this, new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        });
    }
}
