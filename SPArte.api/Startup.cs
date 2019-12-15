using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
namespace SPArte.api
{  
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config) => _config = config;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(opts =>
            {
                opts.Filters.Add(typeof(Infra.GlobalException));

                // forçar a api dar um 406 no accept não aceito
                opts.ReturnHttpNotAcceptable = true;

            })
                    .AddJsonOptions(opts =>
                    {
                        opts.SerializerSettings.NullValueHandling =
                        Newtonsoft.Json.NullValueHandling.Ignore;
                    });

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info() { Title = "SP-Arte API", Version = "v1" });
            });

            services.AddMemoryCache();

            services.AddResponseCompression(opts =>
            {
                var gzip = new GzipCompressionProvider(new GzipCompressionProviderOptions
                {
                    Level = System.IO.Compression.CompressionLevel.Optimal
                });
                opts.Providers.Add(gzip);
                // opts.EnableForHttps = true;
            });            
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseResponseCompression();

            //app.UseAuthentication();

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("swagger/v1/swagger.json", "SP-Arte Api");
                s.RoutePrefix = string.Empty;
            });


        }
    }
}
