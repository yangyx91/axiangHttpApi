using Furion.DynamicApiController;
using Microsoft.Extensions.Options;
using Furion;
using Microsoft.AspNetCore.Mvc;

namespace axiangHttpApi.Application
{
    public class ApiService:IDynamicApiController
    {
        private readonly AppInfoOptions _options;

        public ApiService(IOptions<AppInfoOptions> options)
        {
            _options = options.Value;
        }
        /// <summary>
        /// 接口：A
        /// </summary>
        /// <returns></returns>
        public string GetA([FromQuery]string id)
        {
            var appoptions = App.GetOptions<AppInfoOptions>();
            return $"{_options.Name},{_options.Version},{_options.Author},{appoptions.Name}";
        }

        public AppInfoOptions PostB([FromBody]string id)
        {
            var appoptions = App.GetOptions<AppInfoOptions>();
            return _options;
        }
    }
}