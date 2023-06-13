using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ShortenerUrl.Infra.Data.Sql.Command.Common;
using ShortenerUrl.Infra.Data.Sql.Query.Common;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using Zamin.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Zamin.Extensions.DependencyInjection;
using Zamin.Infra.Data.Sql.Commands.Interceptors;


namespace ShortenerUrl.Endpoints.ShortenerUrl.ServiceConfiguration
{
    public static class HostingExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            string cnn = builder.Configuration.GetConnectionString("ShortenerUrlSqlCommand");
            builder.Services.AddZaminParrotTranslator(c =>
            {
                c.ConnectionString = cnn;
                c.AutoCreateSqlTable = true;
                c.SchemaName = "dbo";
                c.TableName = "ParrotTranslations";
                c.ReloadDataIntervalInMinuts = 1;
            });

            builder.Services.AddZaminWebUserInfoService(true);

            builder.Services.AddZaminAutoMapperProfiles(option =>
            {
                option.AssmblyNamesForLoadProfiles = "BasicInfo";
            });

            builder.Services.AddZaminMicrosoftSerializer();

            builder.Services.AddZaminInMemoryCaching();

            builder.Services.AddDbContext<ShortenerUrlSqlCommandDbContext>(c => c.UseSqlServer(cnn).AddInterceptors(new SetPersianYeKeInterceptor(), new AddOutBoxEventItemInterceptor(), new AddAuditDataInterceptor()));

            builder.Services.AddDbContext<ShortenerUrlSqlQueryDbContext>(c => c.UseSqlServer(cnn));

            builder.Services.AddZaminApiCore("Zamin", "BasicInfo");

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ShortenerUrl", Version = "v1" });
                c.DocInclusionPredicate((doc, apiDescription) =>
                {
                    if (!apiDescription.TryGetMethodInfo(out MethodInfo methodInfo)) return false;

                    var version = methodInfo.DeclaringType
                        .GetCustomAttributes<ApiVersionAttribute>(true)
                        .SelectMany(attr => attr.Versions);

                    return version.Any(v => $"v{v.ToString()}" == doc);
                });
            });
            builder.Services.AddCors(o => o.AddPolicy("AllowAnyOrigin",
                builder =>
                {
                    builder.AllowAnyOrigin()
                                 .AllowAnyMethod()
                                 .AllowAnyHeader();
                }));
            return builder.Build();
        }
        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseZaminApiExceptionHandler();
            app.UseSerilogRequestLogging();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.UseCors("AllowAnyOrigin");

            return app;
        }
    }
}
