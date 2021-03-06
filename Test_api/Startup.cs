using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Data;
using Test_api.Repositories;
using Test_api.Repositories.Impl;
using Test_api.Repositories.Implementations;
using Test_api.Repositories.Interfaces;
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
            //Init controllers
            services.AddControllers();

            //register mapper
            services.AddAutoMapper(typeof(Startup));

            //Init swagger generator
            services.AddSwaggerGen();

            //Init database connection
            services.AddScoped<IDbConnection, DbConnection>();

            //Init employee repo
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            //Init position repo
            services.AddScoped<IPositionRepository, PositionRepository>();

            //Init employee-position repo
            services.AddScoped<IEmployeePositionRepository, EmployeePositionRepository>();

            //Init  employee service
            services.AddScoped<IEmployeeService, EmployeeService>();

            //Init position service
            services.AddScoped<IPositionService, PositionService>();

            //Init employee-position service
            services.AddScoped<IEmployeePositionService, EmployeePositionService>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Init swagger
            app.UseSwagger();

            //Init swagger user interface
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test_api");
                c.RoutePrefix = String.Empty;
            });


        }
    }
}
