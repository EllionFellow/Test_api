using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Data;
using Test_api.Repositories;
using Test_api.Repositories.Impl;
using Test_api.Services.Implementations;
using Test_api.Services.Interfaces;

namespace Test_api
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

            //register mapper
            services.AddAutoMapper(typeof(Startup));

            //Init swagger generator
            services.AddSwaggerGen();

            services.AddScoped<IDbConnection, DbConnection>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped<IPositionRepository, PositionRepository>();

            services.AddScoped<IEmployeeService, EmployeeService>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test_api");
                c.RoutePrefix = String.Empty;
            });


        }
    }
}
