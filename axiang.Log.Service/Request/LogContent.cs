using System;
using System.Collections.Generic;
using System.Text;

namespace axiang.Log.Service.Request
{
    public class LogContent
    {
        public LogContent(string clientIp, string env, string app, string host, string url, string action, string method, string body, string queryString, string res, string exception)
        {
            this.ClientIP = clientIp;
            this.Environment = env;
            this.Application = app;
            this.Host = host;
            this.Url = url;
            this.Action = action;
            this.Method = method;
            this.RequestBody = body;
            this.RequestQueryString = queryString;
            this.Response = res;
            this.Exception = exception;
        }

        public string ClientIP { get; set; }

        public string Environment { get; set; }

        public string Application { get; set; }

        public string Host { get; set; }

        public string Url { get; set; }

        public string Action { get; set; }

        public string Method { get; set; }

        public string RequestBody { get; set; }

        public string RequestQueryString { get; set; }

        public string Response { get; set; }

        public string Exception { get; set; }
    }
}

