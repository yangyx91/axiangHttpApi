using System;
using System.Collections.Generic;
using System.Text;

namespace axiang.Log.Service.Request
{
    public class WriteLog_Request
    {
        public int Level { get; set; }

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

        public string CreateTime { get; set; }
    }

    public enum WriteLogLevel
    {
        Trace = 0,
        Debug = 1,
        Information = 2,
        Warning = 3,
        Error = 4,
        Critical = 5,
        None = -1
    }
}
