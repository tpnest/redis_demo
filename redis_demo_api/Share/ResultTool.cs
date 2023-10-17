using redis_demo_api.Share.Helper;

namespace redis_demo_api.Share;

public static class ResultTool
{
    public static Dictionary<ResultCode, string> DescriptionsDic = EnumHelper.GetDescription<ResultCode>();

    /// <summary>
    /// 成功
    /// </summary>
    /// <returns></returns>
    public static HttpResult Success()
    {
        return new HttpResult(true);
    }

    /// <summary>
    /// 成功带返回数据
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static HttpResult Success(object data)
    {
        return new HttpResult(true, data);
    }

    /// <summary>
    /// 成功带数据总条数
    /// </summary>
    /// <param name="data"></param>
    /// <param name="total"></param>
    /// <returns></returns>
    public static HttpResult Success(object data, int total)
    {
        return new HttpResult(true, data, total);
    }

    /// <summary>
    /// 失败
    /// </summary>
    /// <returns></returns>
    public static HttpResult Fail()
    {
        return new HttpResult(false);
    }

    /// <summary>
    /// 失败带code
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public static HttpResult Fail(ResultCode code)
    {
        return new HttpResult(false, code);
    }

    public static HttpResult Fail(string message)
    {
        return new HttpResult(false, message);
    }

    public static HttpResult Fail(ResultCode code, string message)
    {
        return new HttpResult(false, code, message);
    }
}