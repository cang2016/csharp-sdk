
using Newtonsoft.Json;

namespace vcloud1._0.com.netease.vcloud.util
{
    /// <summary>
    /// Json工具类
    /// </summary>
    public class JsonHelper
    {   
        /// <summary>
        /// 将对象转成Json形式的字符串
        /// </summary>
        /// <param name="obj">待转换的对象</param>
        /// <returns>Json字符串</returns>
        public static string ToJsonString(object obj)
        {
            JsonSerializerSettings setting = new JsonSerializerSettings();
            setting.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(obj, setting);
        }
        /// <summary>
        /// 将Json形式的字符串转换成对象
        /// </summary>
        /// <typeparam name="T">欲转换的对象</typeparam>
        /// <param name="value">Json字符串</param>
        /// <returns>欲转换的对象</returns>
        public static T ToObject<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}
