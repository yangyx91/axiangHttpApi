using Furion.DynamicApiController;

namespace axiangHttpApi.Application
{
    public class ApiService:IDynamicApiController
    {
        /// <summary>
        /// 接口：A
        /// </summary>
        /// <returns></returns>
        public string A()
        {
            return "1";
        }
    }
}