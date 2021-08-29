# axiangHttpLog
http log封装帮助类

#日志服务使用

#日志服务依赖项 Nlog

1、添加引用；axiang.Log.Service.dll

2、控制器使用示例

项目名：WebApplication1

3、日志路径：appsetting.json  

"LogFolder": "G:\\站点日志\\",
可更换为其他存储路径、数据库、缓存

4、日志文件名：见 LogApiController.fileTargetFileName();

5、传参构造：

LogContent(string clientIp, string env, string app, string host, string url, string action, string method, string body, string queryString, string res, string exception)

6、封装方法：

LogCritical(LogContent log)

Debug(LogContent log)

Error(LogContent log)

Information(LogContent log)

Trace(LogContent log)

Warning(LogContent log)

7、示例控制器：

public ActionResult Details(int id)
{
    var a = new LogContent(
        HttpContext.Connection.RemoteIpAddress?.ToString(),
        "debug",
        "WebApplication1",
        Request.Host.Host,
        new StringBuilder()
        .Append(HttpContext.Request.Scheme)
        .Append("://")
        .Append(HttpContext.Request.Host)
        .Append(HttpContext.Request.PathBase)
        .Append(HttpContext.Request.Path)
        .Append(HttpContext.Request.QueryString)
        .ToString(),
        "Details",
        Request.Method,
        id.ToString(),
        HttpContext.Request.QueryString.ToString(),
        "",
        ""
        );
    new LogHelper().Information(a);
    return new JsonResult(a);
}

8、后续将优化
