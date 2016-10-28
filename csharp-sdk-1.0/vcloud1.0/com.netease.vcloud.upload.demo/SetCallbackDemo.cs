using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using vcloud1._0.com.netease.vcloud.auth;
using vcloud1._0.com.netease.vcloud.client;
using vcloud1._0.com.netease.vcloud.upload.param;

namespace vcloud1._0.com.netease.vcloud.upload.demo
{
    /// <summary>
    /// 设置上传回调地址的Demo
    /// </summary>
    public class SetCallbackDemo
    {
        static void Main(string[] args)
        {
            try
            {

                /* 输入个人信息 */
                /* 开发者平台分配的appkey 和 appSecret */
                String appKey = "";
                String appSecret = "";  

                Credentials credentials = new Credentials(appKey, appSecret);
                VcloudClient vclient = new VcloudClient(credentials);

                /** 上传成功后回调客户端的URL地址（需标准http格式） */
                string callbackUrl = "http://127.0.0.1/client/callback";

                /*设置上传回调地址接口输出参数的封装类*/
                SetCallbackParam setCallbackParam = vclient.setCallback(callbackUrl);
                Console.WriteLine(setCallbackParam.code);
                Console.WriteLine(setCallbackParam.msg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

    }
}
