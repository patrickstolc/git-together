namespace WhitelistService.Core.Common;

public class Response<T>
{
    public T Data { get; set; }
    public string Message { get; set; }
    public bool Success { get; set; }
    
    public static Response<T> Ok(T data)
    {
        return new Response<T>
        {
            Data = data,
            Message = null,
            Success = true
        };
    }
    
    public static Response<T> Fail(string message)
    {
        return new Response<T>
        {
            Data = default,
            Message = message,
            Success = false
        };
    }
}