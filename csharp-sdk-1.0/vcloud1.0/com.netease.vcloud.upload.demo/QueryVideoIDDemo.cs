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
    /// 上传完成后查询视频主ID的Demo
    /// </summary>
    public class QueryVideoIDDemo
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
                /* 查询上传视频的vid*/
                List<string> objectNamesList = new List<string>();
                objectNamesList.Add("301631cf-98f0-4920-affd-79309408fd5f.flv");

              
                  /*上传完成后查询视频主ID返回结果的封装类*/
                    QueryVideoIDorWatermarkIDParam queryVideoIDParam = vclient.queryVideoID(objectNamesList);

                    if (queryVideoIDParam.code == 200)
                    {
                        Console.WriteLine("[InitUploadVideoDemo] query videoID successfully. " + queryVideoIDParam.ret.list[0].vid);
                    }
                    else
                    {
                        Console.WriteLine("[InitUploadVideoDemo] fail to query videoID. " + "return code " + queryVideoIDParam.code + " return message " + queryVideoIDParam.msg);
                    }
                }            
             

            
            catch (Exception e)
            {
                Console.WriteLine("查询失败：" + e.Message);
            }
        }
    }
}
