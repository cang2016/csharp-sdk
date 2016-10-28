# CSharp-SDK 说明

## 1 简介

CSharp-SDK 是用于服务器端点播上传的软件开发工具包，提供简单、便捷的方法，方便用户开发上传视频或图片文件的功能。

## 2 功能特性

- 文件上传
- 获取进度
- 断点续传
- 查询视频
- 设置回调

## 3 开发准备

### 3.1 下载地址

[csharp sdk 的源码地址](https://github.com/vcloud163/csharp-sdk.git "csharp sdk 的源码地址")

### 3.2 环境准备

- 适用于 vs2010 版本。
- 通过管理控制台->账户信息获取AppKey和AppSecret；
- 下载 c# sdk，如果安装了git命令行，执行 git clone https://github.com/vcloud163/csharp-sdk.git。
- 参照 API 说明和 sdk 中提供的 demo，开发代码。


### 3.2 https支持

默认使用https协议，如需修改为http协议，请将com.netease.vcloud.util包中的UploadUtil类的具体方法中的url修改。

## 4 使用说明

### 4.1 初始化

接入视频云点播，需要拥有一对有效的 AppKey 和 AppSecret 进行签名认证，可通过如下步骤获得：

- 开通视频云点播服务；
- 登陆视频云开发者平台，通过管理控制台->账户信息获取 AppKey 和 AppSecret。

在获取到 AppKey 和 AppSecret 之后，可按照如下方式进行初始化：

    String appKey = "";
    String appSecret = "";

    Credentials credentials = new Credentials(appKey, appSecret);
    VcloudClient vclient = new VcloudClient(credentials);

### 4.2 文件上传

视频云点播在全国各地覆盖大量上传节点，会选择适合用户的最优节点进行文件上传，并根据用户传入的参数做不同处理，具体详见点播服务端 API 文档。

以下是使用示例：

    String appKey = "";
    String appSecret = "";  

    Credentials credentials = new Credentials(appKey, appSecret);
    VcloudClient vclient = new VcloudClient(credentials);
	
    #请输入上传文件的本地路径
    String filePath = "e:\\1.mp4"
    IDictionary<String, Object> initParamMap = new Dictionary<String, Object>();
	#输入上传文件的相关信息 
    #上传文件的原始名称（包含后缀名） 此参数必填
    initParamMap.Add("originFileName", FileUtil.getFileName(filePath));	
	
	#根据对象名查询视频ID输出参数的封装类
	QueryVideoIDorWatermarkIDParam queryVideoIDParam = vclient.uploadVideo(filePath, initParamMap);

**注：具体使用示例详见 sdk com.netease.vcloud.upload.demo 包中 UploadVideoDemo。**

### 4.2 查询进度

视频云点播文件上传采用分片处理，可通过以下方法查询已经上传视频云的文件字节数。SDK 提供回调函数查询已经上传视频云的文件字节数。

以下是使用示例：
	
	
    String appKey = "";
    String appSecret = "";

    Credentials credentials = new Credentials(appKey, appSecret);
    VcloudClient vclient = new VcloudClient(credentials);
    #上传加速节点地址 此参数必填
    string uploadHost = "";
    #存储对象的桶名   此参数必填
    string bucket = "";
    #生成的唯一对象名 此参数必填
    string objectName = "";
    #上传上下文      此参数必填
    string context = "";
    #上传token      此参数必填
    string xNosToken = "";

	#断点续传查询断点输出参数的封装类
    QueryOffsetParam queryOffsetParam = vclient.getPartOffset(uploadHost, bucket, objectName, context, xNosToken);     

    long offset = queryOffsetParam.offset;          


**注：具体使用示例详见 sdk com.netease.vcloud.upload.demo 包中 QueryOffsetDemo。**

### 4.3 断点续传

在上传文件中，视频云点播通过唯一标识 context 标识正在上传的文件，可通过此标识获取到已经上传视频云的文件字节数。通过此方法可实现文件的断点续传。

为防止服务中止造成文件上传信息丢失，可通过在本地存储文件信息来记录断点信息，当服务重启启动，可根据文件继续上传文件。临时文件会在上传完成后删除记录。

以下是使用示例：

    String appKey = "";
    String appSecret = "";  

    Credentials credentials = new Credentials(appKey, appSecret);
    VcloudClient vclient = new VcloudClient(credentials);
	
    #请输入上传文件的本地路径
    String filePath = "e:\\1.mp4"
    IDictionary<String, Object> initParamMap = new Dictionary<String, Object>();
	#输入上传文件的相关信息 
    #上传文件的原始名称（包含后缀名） 此参数必填
    initParamMap.Add("originFileName", FileUtil.getFileName(filePath));

    #本地用于存放上传进度相关信息的文件
    String recorderFilePath = "e:\\1\\2.txt";
	UploadRecorder recorder = new UploadRecorder(recorderFilePath);

	QueryVideoIDorWatermarkIDParam queryVideoIDParam = null;
    queryVideoIDParam = vclient.uploadVideoWithRecorder(filePath, initParamMap, recorder);

**注：具体使用示例详见 sdk com.netease.vcloud.upload.demo 包中 Upload_RecoderDemo。**
    

### 4.4 查询视频

视频上传成功后，可通过主动查询的方式获取到视频唯一标识，支持批量查询。

以下是使用示例：

	 String appKey = "";
     String appSecret = "";

     Credentials credentials = new Credentials(appKey, appSecret);
     VcloudClient vclient = new VcloudClient(credentials);
     #查询上传视频的vid
     List<string> objectNamesList = new List<string>();
     objectNamesList.Add("301631cf-98f0-4920-affd-79309408fd5f.flv");

     #上传完成后查询视频主ID返回结果的封装类
     QueryVideoIDorWatermarkIDParam queryVideoIDParam = vclient.queryVideoID(objectNamesList);
     if (queryVideoIDParam.code == 200)
     {
       Console.WriteLine("[InitUploadVideoDemo] query videoID successfully. " + queryVideoIDParam.ret.list[0].vid);
      }
      else
      {
       Console.WriteLine("[InitUploadVideoDemo] fail to query videoID. " + "return code " + queryVideoIDParam.code + " return message " + queryVideoIDParam.msg);
      }

**注：具体使用示例详见 sdk com.netease.vcloud.upload.demo 包中 QueryVideoIDDemo。**

### 4.5 设置回调

如果设置回调，视频上传成功后会发送相关视频信息给回调接口。

以下是使用示例：

	 String appKey = "";
     String appSecret = "";  

     Credentials credentials = new Credentials(appKey, appSecret);
     VcloudClient vclient = new VcloudClient(credentials);

     #上传成功后回调客户端的URL地址（需标准http格式）
     string callbackUrl = "http://127.0.0.1/client/callback";

     #设置上传回调地址接口输出参数的封装类
     SetCallbackParam setCallbackParam = vclient.setCallback(callbackUrl);

**注：具体使用示例详见 sdk com.netease.vcloud.upload.demo 包中 SetCallbackDemo。**

## 5 版本更新记录

**v1.0.0**

1. CSharp SDK 的初始版本，提供点播上传的基本功能。包括：文件上传、获取进度、断点续传、查询视频、设置回调。