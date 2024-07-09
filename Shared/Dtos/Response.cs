using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared.Dtos
{
    public class Response<T> where T : class
    {
        public T Data { get; private set; }

        public int StatusCode { get; private set; }

        public string Message { get; set; }

        [JsonIgnore]
        public bool IsSuccessful { get; private set; }

        public ErrorDto Error { get; private set; }

        public static Response<T> Success(T data, int statusCode)
        {
            return new Response<T> { Data = data, StatusCode = statusCode, IsSuccessful = true };
        }

        public static Response<T> Success(int statusCode)
        {
            return new Response<T> { Data = default, StatusCode = statusCode, IsSuccessful = true };
        }

        public static Response<T> Success(string message, int statusCode)
        {
            return new Response<T> { Data = default, Message = message, StatusCode = statusCode, IsSuccessful = true };
        }

        public static Response<T> Fail(ErrorDto errorDto, int statusCode)
        {
            return new Response<T>
            {
                Error = errorDto,
                StatusCode = statusCode,
                IsSuccessful = false
            };
        }

        public static Response<T> Fail(string errorMessage, int statusCode, bool isShow)
        {
            var errorDto = new ErrorDto(errorMessage, isShow);

            return new Response<T> { Error = errorDto, StatusCode = statusCode, IsSuccessful = false };
        }

        public static Response<T> Fail(int statusCode, string message)
        {
            return new Response<T> { Message = message, StatusCode = statusCode, IsSuccessful = false };
        }
    }

    public class ResponseCount<T> where T : struct
    {
        public T Data { get; set; }

        public int StatusCode { get; set; }

        [JsonIgnore]
        public bool IsSuccessful { get; set; }

        public string Message { get; set; }

        public ErrorDto Error { get; set; }

        public static ResponseCount<T> Success(T data, int statusCode)
        {
            return new ResponseCount<T> { Data = data, StatusCode = statusCode, IsSuccessful = true };
        }

        public static ResponseCount<T> Fail(T data, int statusCode, string message)
        {
            return new ResponseCount<T> { Data = data, Message = message, StatusCode = statusCode, IsSuccessful = false };
        }
    }
}
