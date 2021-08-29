using axiang.Log.Service.Http;
using axiang.Log.Service.Request;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace axiang.Log.Service
{
    public class LogHelper : HttpSettings
    {
        public LogHelper()
        {
            base.ResetDefaults("LogHttpFactory");
        }

        private readonly string ContentType = "application/json";

        //private readonly string LogApiUri = "http://192.168.2.51:8888/LogApi/WriteLog";

        private readonly string LogApiUri = "http://192.168.2.49:2021/LogApi/WriteLog";

        public async Task<bool> LogCritical(LogContent log)
        {
            var req = ConvertDTO(log);
            req.Level = (int)WriteLogLevel.Critical;
            return await SendLog(ConvertJson(req));
        }

        public async Task<bool> Debug(LogContent log)
        {
            var req = ConvertDTO(log);
            req.Level = (int)WriteLogLevel.Debug;
            return await SendLog(ConvertJson(req));
        }

        public async Task<bool> Error(LogContent log)
        {
            var req = ConvertDTO(log);
            req.Level = (int)WriteLogLevel.Error;
            return await SendLog(ConvertJson(req));
        }

        public async Task<bool> Information(LogContent log)
        {
            var req = ConvertDTO(log);
            req.Level = (int)WriteLogLevel.Information;
            return await SendLog(ConvertJson(req));
        }

        public async Task<bool> Trace(LogContent log)
        {
            var req = ConvertDTO(log);
            req.Level = (int)WriteLogLevel.Trace;
            return await SendLog(ConvertJson(req));
        }

        public async Task<bool> Warning(LogContent log)
        {
            var req = ConvertDTO(log);
            req.Level = (int)WriteLogLevel.Warning;
            return await SendLog(ConvertJson(req));
        }

        private WriteLog_Request ConvertDTO(LogContent req)
        {
            return new WriteLog_Request()
            {
                Action = req.Action,
                Application = req.Application,
                ClientIP = req.ClientIP,
                Environment = req.Environment,
                Exception = req.Exception,
                Host = req.Host,
                Url = req.Url,
                Method = req.Method,
                Level = 0,
                CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                RequestBody = req.RequestBody,
                RequestQueryString = req.RequestQueryString,
                Response = req.Response
            };
        }

        private string ConvertJson(WriteLog_Request req)
        {
            return "{" +
            "\"Action\":\"" + req.Action + "\"," +
            "\"Application\":\"" + req.Application + "\"," +
            "\"ClientIP\":\"" + req.ClientIP + "\"," +
            "\"Environment\":\"" + req.Environment + "\"," +
            "\"Exception\":\"" + req.Exception + "\"," +
            "\"Host\":\"" + req.Host + "\"," +
            "\"Url\":\"" + req.Url + "\"," +
            "\"Method\":\"" + req.Method + "\"," +
            "\"CreateTime\":\"" + req.CreateTime + "\"," +
            "\"RequestBody\":\"" + req.RequestBody + "\"," +
            "\"RequestQueryString\":\"" + req.RequestQueryString + "\"," +
            "\"Response\":\"" + req.Response + "\"," +
            "\"Level\":" + req.Level + "" +
            "  }";
}
private async Task<bool> SendLog(string req)
        {
            var isSuccess = false;
            try
            {
                var _client = HttpClientFactory.CreateHttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, string.Empty)
                {
                    Content = new StringContent(req, Encoding.UTF8, ContentType),
                    RequestUri = new Uri(LogApiUri)
                };
                var httpResponseMessage = await _client.SendAsync(request).ConfigureAwait(false);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    isSuccess = true;
                }

                return isSuccess;
            }
            catch (WebException)
            {
                return false;
            }
            catch (HttpRequestException)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
    }
}

