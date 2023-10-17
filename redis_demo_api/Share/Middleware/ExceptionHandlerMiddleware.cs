using System.Net;
using redis_demo_api.Exceptions;

namespace redis_demo_api.Share.Middleware;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
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

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.OK;

        HttpResult result;

        if (exception is BusinessException businessException)
        {
            result = ResultTool.Fail(businessException.ErrorCode,
                businessException.Message);
        }
        else
        {
            // 其他未处理异常
            result = ResultTool.Fail(ResultCode.Fail, "系统异常！");
            // 记录日志
            
        }
        return context.Response.WriteAsJsonAsync(result);
    }
}