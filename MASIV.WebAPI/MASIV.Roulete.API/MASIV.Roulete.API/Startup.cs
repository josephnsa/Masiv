using MASIV.Core.Common.Application;
using MASIV.Core.Common.Interfaces;
using MASIV.Repository.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;
using System;

namespace MASIV.Roulete.API
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
            services.AddControllers();
            string serverName = Environment.GetEnvironmentVariable("ServerName");
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(serverName);
            services.AddScoped(s => redis.GetDatabase());
            services.AddScoped<IRouletteRepository, RouletteRepository>();
            services.AddScoped<IRouletteApplication, RouletteApplication>();
            services.AddScoped<ICommonRepository, CommonRepository>();
            services.AddScoped<IBetRepository, BetRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}