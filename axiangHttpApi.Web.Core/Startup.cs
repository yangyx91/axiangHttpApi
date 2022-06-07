using Furion;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using axiangHttpApi.Application;
using System.Text.Encodings.Web;

namespace axiangHttpApi.Web.Core
{
    public class Startup:AppStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCorsAccessor();
            services.AddControllers().AddJsonOptions(
                x =>{
                    x.JsonSerializerOptions.Encoder =
                    JavaScriptEncoder.Create(
                        System.Text.Unicode.UnicodeRanges.All);
                    x.JsonSerializerOptions.Converters.Add(
                        new DateTimeJsonConverter());
                }).AddInject();

            services.AddConfigurableOptions<AppInfoOptions>();

            services.AddSqlsugarSetup(App.Configuration);
        }

        public void Configure(IApplicationBuilder app,IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCorsAccessor();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseInject();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}