using axiang.Log.Service.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace axiang.Log.Http.Controllers
{
    public class LogApiController : Controller
    {
        private readonly ILogger<LogApiController> _logger;

        private readonly IConfiguration _configuration;

        public LogApiController(ILogger<LogApiController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        /// <summary>
        /// LogApi/WriteLog
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> WriteLog()
        {
            var postBody = "";
            using (StreamReader sr = new StreamReader(Request.Body))
            {
                postBody = await sr.ReadToEndAsync();
            }

            if (!string.IsNullOrEmpty(postBody))
            {
                try
                {
                    var req = JsonSerializer.Deserialize<WriteLog_Request>(postBody);

                    if (!string.IsNullOrEmpty(req.Application) && req.Application.Length > 0)
                    {
                        fileTargetFileName(req.Application);

                        switch (req.Level)
                        {
                            case (int)WriteLogLevel.Critical:
                                _logger.LogCritical(JsonSerializer.Serialize(req));
                                break;
                            case (int)WriteLogLevel.Debug:
                                _logger.LogDebug(JsonSerializer.Serialize(req));
                                break;
                            case (int)WriteLogLevel.Error:
                                _logger.LogError(JsonSerializer.Serialize(req));
                                break;
                            case (int)WriteLogLevel.Information:
                                _logger.LogInformation(JsonSerializer.Serialize(req));
                                break;
                            case (int)WriteLogLevel.None:
                                break;
                            case (int)WriteLogLevel.Trace:
                                _logger.LogTrace(JsonSerializer.Serialize(req));
                                break;
                            case (int)WriteLogLevel.Warning:
                                _logger.LogWarning(JsonSerializer.Serialize(req));
                                break;
                            default:
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.ToString());
                }
            }
            return Ok();
        }


        public void fileTargetFileName(string host)
        {
            var configuration = NLog.LogManager.Configuration;
            var fileTarget = configuration.FindTargetByName<FileTarget>(_configuration["LogTargetName"]);
            fileTarget.FileName = _configuration["LogFolder"] + host + _configuration["LogFile"] + _configuration["LogExtension"];
            fileTarget.Encoding = System.Text.Encoding.UTF8;
            NLog.LogManager.Configuration = configuration;
        }
    }
}
