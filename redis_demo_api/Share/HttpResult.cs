namespace redis_demo_api.Share;

public class HttpResult
{
    public bool Success { get; set; }
    public int Code { get; set; }
    public string? Message { get; set; }
    public int Total { get; set; } = -1;
    public object? Data { get; set; }


    public HttpResult()
    {
    }

    public HttpResult(bool success)
    {
        Success = success;
        Code = success ? (int)ResultCode.Success : (int)ResultCode.Fail;
        Message = ResultTool.DescriptionsDic[(ResultCode)Code];
    }

    public HttpResult(bool success, string message)
    {
        Success = success;
        Code = success ? (int)ResultCode.Success : (int)ResultCode.Fail;
        Message = message;
    }

    public HttpResult(bool success, ResultCode resultCode)
    {
        Success = success;
        Code = (int)resultCode;
        Message = ResultTool.DescriptionsDic[(ResultCode)Code];
    }

    public HttpResult(bool success, object? data)
    {
        Success = success; 
        Code = success ? (int)ResultCode.Success : (int)ResultCode.Fail;
        Message = ResultTool.DescriptionsDic[(ResultCode)Code];
        Data = data;
    }

    public HttpResult(bool success, object? data, int total)
    {
        Success = success;
        Code = success ? (int)ResultCode.Success : (int)ResultCode.Fail;
        Message = ResultTool.DescriptionsDic[(ResultCode)Code];
        Data = data;
        Total = total; //总条数 用于分页查询 不需要分页时设置为-1 
    }

    public HttpResult(bool success, ResultCode resultCode, object? data)
    {
        Success = success;
        Code = (int)resultCode;
        Message = ResultTool.DescriptionsDic[(ResultCode)Code];
        Data = data;
    }

    public HttpResult(bool success, ResultCode resultCode, string message)
    {
        Success = success;
        Code = (int)resultCode;
        Message = message;
    }
}