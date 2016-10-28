using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using vcloud1._0.com.netease.vcloud.auth;
using vcloud1._0.com.netease.vcloud.client;
using vcloud1._0.com.netease.vcloud.util;
using vcloud1._0.com.netease.vcloud.upload.param;
using System.IO;

namespace vcloud1._0.com.netease.vcloud.upload.demo
{
    /// <summary>
    /// 利用断点续传查询offset的Demo
    /// </summary>
    public class QueryOffsetDemo
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
                // 上传加速节点地址
                string uploadHost = "";
                //存储对象的桶名
                string bucket = "";
                //生成的唯一对象名
                string objectName = "";
                //上传上下文
                string context = "";
                //上传token
                string xNosToken = "";

                QueryOffsetParam queryOffsetParam = vclient.getPartOffset(uploadHost, bucket, objectName, context, xNosToken);

                // 使用断点续传查询offset，文件全部上传之后，再通过getPartOffset()是无法查询到offset的 会报 404 对应context上传不存在        

                long offset = queryOffsetParam.offset;                         
                
                Console.WriteLine("[QueryOffset] offset :" + offset);

            }
            catch (Exception e)
            {
                Console.WriteLine("查询失败：" + e.Message);
            }
        }
    }
}
