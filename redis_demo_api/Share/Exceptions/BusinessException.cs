namespace redis_demo_api.Share.Exceptions;

public class BusinessException : Exception
{
    public ResultCode ErrorCode { get; set; }

    public BusinessException(string message) : base(message)
    {
        ErrorCode = ResultCode.Fail;
    }

    public BusinessException(ResultCode errorCode, string message) : base(message)
    {
        ErrorCode = errorCode;
    }
}