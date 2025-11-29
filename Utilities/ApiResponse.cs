using System.Net;

namespace MetroClaim.Api.Utilities;

public class ApiResponse<TResponse>
{
    public int Status { get; set; } 
    public string Message { get; set; } 
    public TResponse? Data { get; set; } 

    public ApiResponse(TResponse? data)
    {
        Status = StatusCodes.Status200OK;
        Message = nameof(HttpStatusCode.OK);
        Data = data;
    }

    public ApiResponse(string message)
    {
        Status = StatusCodes.Status200OK;
        Message = message;
        Data = default;
    }

    public ApiResponse(int statusCode, string message)
    {
        Status = statusCode;
        Message = message;
        Data = default;
    }
}
