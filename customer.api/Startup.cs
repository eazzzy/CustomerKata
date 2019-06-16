using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using customer.api.Models;
using customerdata.lib;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace customer.api
{
    public class Startup
    {
        private readonly string sbConfigSection = "AppSettings:Swashbuckle:";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials();
            }));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(Configuration[$"{sbConfigSection}Version"], new Info
                {
                    Version = Configuration[$"{sbConfigSection}Version"],
                    Title = Configuration[$"{sbConfigSection}Title"],
                    Description = Configuration[$"{sbConfigSection}Description"]
                });
            });

            services
                .AddTransient(typeof(ICustomerReadDataStore),
                    x => new CustomerReadDataStore(Configuration["AppSettings:Datafile"]))
                .AddTransient<ICustomerService, CustomerService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(Configuration[$"{sbConfigSection}EndpointUrl"],
                    Configuration[$"{sbConfigSection}EndpointName"]);
            });
            app.UseCors("MyPolicy");

            app.UseMvc();
        }
    }
}
