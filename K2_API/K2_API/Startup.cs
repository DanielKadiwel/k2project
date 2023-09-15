using K2_Domain.Handlers;
using K2_Domain.Repositories.Interfaces;
using K2_Infraestructure.Data;
using K2_Infraestructure.Repositories;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using System.IO.Compression;
using System.Text.Json.Serialization;

namespace Cliente_Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //ConfigureJwt(services);

            services.AddMvc().AddJsonOptions(options =>
            {
                //options.SerializerSettings.DateFormatString = "yyyyMMddHHmmss";
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });

            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Optimal;
            });

            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<GzipCompressionProvider>();
            });

            services.AddDbContext<RepositoryContext>(options => options.UseNpgsql(Configuration.GetConnectionString("ENV_DEV")));

            //AddContext(services);
            AddServices(services);
            AddRepositories(services);
            //MapEntities();

            services.AddSwaggerGen();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI();
        }

        private void AddServices(IServiceCollection services)
        {
            services.AddScoped<ContaBancariaHandler, ContaBancariaHandler>();
        }

        private void AddRepositories(IServiceCollection services)
        {
            services.AddTransient<IContaBancariaRepository, ContaBancariaRepository>();
        }
    }
}