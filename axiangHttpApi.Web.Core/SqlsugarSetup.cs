using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace axiangHttpApi.Web.Core
{
    public static class SqlsugarSetup
    {
        public static void AddSqlsugarSetup(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            SqlSugarScope sqlSugar = new SqlSugarScope(
                new List<ConnectionConfig>()
            {
                    new ConnectionConfig()
                    {
                        IsAutoCloseConnection=true,
                        DbType=DbType.MySql,
                        ConnectionString=
                        configuration.GetConnectionString("xxxx"),
                        ConfigId="0"
                    },
                    new ConnectionConfig()
                    {
                        IsAutoCloseConnection=true,
                        DbType=DbType.SqlServer,
                        ConnectionString=
                        configuration.GetConnectionString("xxxx"),
                        ConfigId="1"
                    },
                     new ConnectionConfig()
                    {
                        IsAutoCloseConnection=true,
                        DbType=DbType.Sqlite,
                        ConnectionString=
                        configuration.GetConnectionString("xxxx"),
                        ConfigId="2"
                    }
            }) ;
            services.AddSingleton<ISqlSugarClient>(sqlSugar);
        }
    }
}
