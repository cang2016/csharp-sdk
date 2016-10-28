using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using vcloud1._0.com.netease.vcloud.auth;
using vcloud1._0.com.netease.vcloud.client;
using vcloud1._0.com.netease.vcloud.upload.param;
using System.IO;
using vcloud1._0.com.netease.vcloud.util;

namespace vcloud1._0.com.netease.vcloud.upload.demo
{
    /// <summary>
    /// 分片上传视频的Demo
    /// </summary>
    public class UploadVideoFragmentDemo
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

                /*请输入上传文件路径*/
                string filePath = "e:\\1.mp4";

                if (!FileUtil.doesFileExist(filePath))
                {
                    throw new VcloudException(string.Format("{0} does not exist", filePath));
                }

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

	            /*视频上传初始化*/
	  
	            /*视频上传初始化返回结果的封装类*/
                InitUploadVideoParam initUploadVideoParam =  vclient.initUploadVideo(initParamMap);
	     
	             if(initUploadVideoParam.code != 200){
	    	         Console.WriteLine("上传初始化失败");
	    	         return ;
	             }
	             /*获取上传加速节点地址*/	   
	             /*获取上传加速节点地址返回结果的封装类*/
	             GetUploadHostParam getUploadHostParam = vclient.getUploadHost(initUploadVideoParam);
	     
	             if(null == getUploadHostParam){
	    	         Console.WriteLine("获取加速节点失败");
	    	         return ; 
	             }
               
	             /*分片上传视频*/	    
	     
	             /*当前分片在整个对象中的起始偏移量    此参数必填*/
	             long offset = 0;
	             /*上传上下文         此参数必填*/
		         string context = null;
		         /*上传文件的输出流        此参数必填*/
		         FileStream fileStream = null;
		 
		        	 
			         fileStream = FileUtil.getFileInputStream(filePath);
			         /*上传文件剩余大小*/
                     long fileLength = FileUtil.getFileLength(filePath);
                     long remainderSize = fileLength;		 
			         /*分片上传视频*/
			         while(remainderSize > 0){		
				
				         UploadVideoFragmentParam uploadVideoParam = vclient.uploadVideoFragment(initUploadVideoParam, getUploadHostParam, offset, context, fileStream, remainderSize);     
						 context = uploadVideoParam.context;
				         offset = uploadVideoParam.offset;
                         remainderSize = fileLength - offset;
			         }

                     /* 查询上传视频的vid*/
                     List<string> objectNamesList = new List<string>();
                     objectNamesList.Add(initUploadVideoParam.ret.objectName);                    

                     /*查询上传视屏返回结果的封装类*/
                     QueryVideoIDorWatermarkIDParam queryVideoIDParam = vclient.queryVideoID(objectNamesList);                    
                     Console.WriteLine("[UploadVideoDemo] video id :" + queryVideoIDParam.ret.list[0].vid);			     

		         } catch (Exception e) {
			          Console.WriteLine("上传失败：" + e.Message);
			         }
		         }
	        }


    
}
