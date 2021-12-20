using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestZigzag.Core.Common;
using TestZigzagApi.Business.Configuration;
using TestZigzagApi.Configuration.Authentication;
using TestZigzagApi.Configuration.GraphQl;
using TestZigzagApi.Configuration.Swagger;
using TestZigzagApi.Data.Configuration;
using TestZigzagApi.Options;

namespace TestZigzagApi
{
    public class Startup
    {
        private const string MondoDbSectionName = "MongoDatabase";
        private const string AuthOptionsSectionName = "AuthOptions";
        private const string DefaultCorsPolicyName = "DefaultCors";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var mongoOptions = Configuration.GetSection(MondoDbSectionName).Get<MongoDatabaseOptions>();
            var authOptions = Configuration.GetSection(AuthOptionsSectionName).Get<AuthOptions>();
            
            services.AddCors(options =>
            {
                options.AddPolicy(name: DefaultCorsPolicyName,
                    builder =>
                    {
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                        builder.AllowAnyOrigin();
                    });
            });

            services.Configure<AuthOptions>(Configuration.GetSection(AuthOptionsSectionName));
            services.AddControllers();
            services.AddSwagger();
            services.AddCustomAuthentication(authOptions.Key);
            services.AddBusinessLayer();
            services.AddDataLayer(mongoOptions.ConnectionString, mongoOptions.DatabaseName);
            services.AddGraphQl();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestZigzagApi v1"));
            }
            
            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;
                var response = new { error = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));

            app.UseHttpsRedirection();
            app.UseCors(DefaultCorsPolicyName);
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGraphQL();
            });
        }
    }
}