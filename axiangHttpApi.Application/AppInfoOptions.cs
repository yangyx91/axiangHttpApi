using Furion.ConfigurableOptions;

namespace axiangHttpApi.Application
{
    public class AppInfoOptions:IConfigurableOptions
    {
        public string Name { get; set; }

        public string Version { get; set; }

        public string Author { get; set; }
    }
}
