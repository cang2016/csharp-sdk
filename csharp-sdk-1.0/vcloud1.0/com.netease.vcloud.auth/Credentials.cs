using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vcloud1._0.com.netease.vcloud.auth
{
    /// <summary>
    /// 提供用于访问服务的凭据：appKey和appSecret。这些凭据用于安全地签名请求服务。
    /// </summary>
    public class Credentials
    {
        /// <summary>
        /// 开发者平台分配给用户的appkey
        /// </summary>
        private string appKey;

        public string AppKey
        {
            get { return appKey; }
            set { appKey = value; }
        }

        /// <summary>
        /// 开发者平台分配给用户的appSecret
        /// </summary>
        private string appSecret;

        public string AppSecret
        {
            get { return appSecret; }
            set { appSecret = value; }
        }
        /// <summary>
        /// 无参构造函数，如果用户不传入appKey和appSecret,则默认会从app.config中读取信息
        /// </summary>
        public Credentials()
        {

            if (System.Configuration.ConfigurationManager.AppSettings["appKey"] != null)
            {
                appKey = System.Configuration.ConfigurationManager.AppSettings["appKey"];
            }
            if (System.Configuration.ConfigurationManager.AppSettings["appSecret"] != null)
            {
                appSecret = System.Configuration.ConfigurationManager.AppSettings["appSecret"];
            }
        }
        /// <summary>
        /// 传入appkey和appSecret
        /// </summary>
        /// <param name="appKey">开发者平台分配给用户的appkey</param>
        /// <param name="appSecret">开发者平台分配给用户的appSecret</param>
        public Credentials(string appKey, string appSecret)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;
        }
    }
}
