using System.Text.Json.Serialization;

namespace MCA.Result;
public sealed class Result<T>
{
    private Result(T data)
    {
        Data = data;
        IsSuccessful = true;
        StatusCode = 200;
    }

    private Result(string message, int statusCode)
    {
        ErrorMessages = new() { message };
        IsSuccessful = false;
        StatusCode = statusCode;
    }

    private Result(List<string> message, int statusCode)
    {
        ErrorMessages = message;
        IsSuccessful = false;
        StatusCode = statusCode;
    }

    public T? Data { get; set; }
    public List<string>? ErrorMessages { get; set; }
    public bool IsSuccessful { get; set; }

    [JsonIgnore]
    public int StatusCode { get; set; }

    public static Result<T> Succeed(T data)
    {
        return new Result<T>(data);
    }

    public static Result<T> Failure(string message, int statusCode)
    {
        return new Result<T>(message, statusCode);
    }

    public static Result<List<T>> Failure(List<string> message, int statusCode)
    {
        return new Result<List<T>>(message, statusCode);
    }
}
