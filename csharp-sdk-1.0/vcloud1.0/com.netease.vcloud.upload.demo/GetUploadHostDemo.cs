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
    /// 获取上传加速节点地址的Demo
    /// </summary>
   public class GetUploadHostDemo
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
               /* 桶名*/
               string bucket = "";
               GetUploadHostParam getUploadHostParam  = vclient.getUploadHost(bucket);
               if (null != getUploadHostParam)
               {
                   Console.WriteLine("获取加速节点成功.lbs:{0}  upload[0]:{1} upload[1]:{2}", getUploadHostParam.lbs, getUploadHostParam.upload[0], getUploadHostParam.upload[1]);
               }
               else
               {
                   Console.WriteLine("获取加速节点失败. msg:{0}", getUploadHostParam.Message);
               }
              
           }
           catch (VcloudException e)
           {
               Console.WriteLine(e.Message);
           }

       }
    }
}
