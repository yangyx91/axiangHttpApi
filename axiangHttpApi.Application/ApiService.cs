using Furion.DynamicApiController;
using Microsoft.Extensions.Options;
using Furion;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;

namespace axiangHttpApi.Application
{
    public class ApiService:IDynamicApiController
    {
        private readonly AppInfoOptions _options;

        private readonly ISqlSugarClient _db;

        public ApiService(
            IOptions<AppInfoOptions> options,
            ISqlSugarClient db)
        {
            _options = options.Value;
            _db = db;
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