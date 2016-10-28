using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vcloud1._0.com.netease.vcloud.upload.param
{
    /// <summary>
    ///  视频上传初始化输出参数的封装类
    /// </summary>
   public class InitUploadVideoParam
    {
        /** 输出参数中的ret部分*/
       public InitUploadVideoRet ret { get; set; } 

        /** 输出参数中的响应码*/
       public int code { get; set; } 

        /** 输出参数中的错误信息*/
       public string msg { get; set; } 
    }
}
