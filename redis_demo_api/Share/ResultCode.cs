using System.ComponentModel;

namespace redis_demo_api.Share;

public enum ResultCode
{
    [Description("操作失败！")]
    Fail = -1,
    [Description("操作成功！")]
    Success = 0
}