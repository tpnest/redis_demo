using System.ComponentModel;

namespace redis_demo_api.Share.Helper;

public static class EnumHelper
{
    /// <summary>
    /// 获取枚举类型的所有值和描述
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static Dictionary<T, string> GetDescription<T>() where T : Enum
    {
        var descriptions = new Dictionary<T, string>();

        foreach (var value in Enum.GetValues(typeof(T)).Cast<T>())
        {
            var fieldInfo = typeof(T).GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            descriptions[value] = attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

        return descriptions;
    }
}