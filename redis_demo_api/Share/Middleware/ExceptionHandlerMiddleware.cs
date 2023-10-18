using System.Net;
using redis_demo_api.Services;
using redis_demo_api.Share.Exceptions;

namespace redis_demo_api.Share.Middleware;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILoggerService _logger;
    public ExceptionHandlerMiddleware(RequestDelegate next, ILoggerService logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private  Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.OK;

        HttpResult result;

        if (exception is BusinessException businessException)
        {
            result = ResultTool.Fail(businessException.ErrorCode,
                businessException.Message);
            _logger.Info(businessException);
        }
        else
        {
            // 其他未处理异常
            result = ResultTool.Fail(ResultCode.Fail, "系统异常！");
            // 记录日志
            _logger.Error(exception);
        }

        return context.Response.WriteAsJsonAsync(result);
    }
}