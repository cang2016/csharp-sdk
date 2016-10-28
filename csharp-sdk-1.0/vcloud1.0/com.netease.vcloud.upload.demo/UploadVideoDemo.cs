using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using vcloud1._0.com.netease.vcloud.util;
using vcloud1._0.com.netease.vcloud.upload.param;
using vcloud1._0.com.netease.vcloud.auth;
using vcloud1._0.com.netease.vcloud.client;

namespace vcloud1._0.com.netease.vcloud.upload.demo
{
    /// <summary>
    /// 简单的视频上传的Demo
    /// </summary>
    public class UploadVideoDemo
    {
        static void Main(string[] args)
        {
            /* 输入个人信息 */
            /* 开发者平台分配的appkey 和 appSecret */
            String appKey = "";
            String appSecret = "";  

            Credentials credentials = new Credentials(appKey, appSecret);
            VcloudClient vclient = new VcloudClient(credentials);

            try
            {
                /*请输入上传文件路径*/
                String filePath = "e:\\1.mp4";
                //String filePath = "e:\\image_20160711145925.png";

                IDictionary<String, Object> initParamMap = new Dictionary<String, Object>();

                /*输入上传文件的相关信息 */
                /* 上传文件的原始名称（包含后缀名） 此参数必填*/
                initParamMap.Add("originFileName", FileUtil.getFileName(filePath));

                /* 用户命名的上传文件名称  此参数非必填*/
                initParamMap.Add("userFileName", "你好.mp4");

                /* 视频所属的类别ID（不填写为默认分类）此参数非必填*/
                //initParamMap.Add("typeId", 1056);

                /* 频所需转码模板ID（不填写为默认模板） 此参数非必填*/
                //initParamMap.Add("presetId", 30599);

                /* 转码成功后回调客户端的URL地址（需标准http格式）  此参数非必填*/
                initParamMap.Add("callbackUrl", null);

                /* 上传视频的描述信息  此参数非必填*/
                initParamMap.Add("description", "love.mp4");

                /* 上传视频的视频水印Id 此参数非必填*/
                //initParamMap.Add("watermarkId",1);	  

                /** 上传成功后回调客户端的URL地址（需标准http格式） */

                //initParamMap.Add("uploadCallbackUrl", "");

                /** 用户自定义信息，会在上传成功或转码成功后通过回调返回给用户 */
                //initParamMap.Add("userDefInfo", null);  

                QueryVideoIDorWatermarkIDParam queryVideoIDParam = vclient.uploadVideo(filePath, initParamMap);
                Console.WriteLine("[UploadVideoDemo] video id :" + queryVideoIDParam.ret.list[0].vid);	

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

    }
}
