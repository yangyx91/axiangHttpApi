using Serilog;

var builder = WebApplication.CreateBuilder(args).Inject();
builder.Host.UseSerilogDefault(config =>
{
    string date = DateTime.Now.ToString("yyyy-MM-dd");
    config.WriteTo.File($"_logs/{date}/axiang.log",
                        rollingInterval: RollingInterval.Day,
                        rollOnFileSizeLimit: true,
                        encoding:System.Text.Encoding.UTF8,
                        fileSizeLimitBytes:1024*100);
});
var app = builder.Build();
app.Run();
