using customer.api.Repository;
using customer.api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace customer.api
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
            services.AddDbContext<DefaultDbContext>(opt => opt.UseInMemoryDatabase("inMemoryDataBase"));
            services.AddSwaggerGen();
            services.AddControllers();

            services.AddHttpClient<ICommonService, CommonService>(client =>
            {
                client.BaseAddress = new Uri(Configuration["CommonApi"]);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors(c =>
            {
                c.AllowAnyOrigin();
                c.AllowAnyMethod();
                c.AllowAnyHeader();
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Common API V1");
                c.RoutePrefix = string.Empty;
            });

            // Fill In-Memory DB
            var dbContext = app.ApplicationServices.CreateScope().ServiceProvider.GetService<DefaultDbContext>();
            DataBaseInitializer.Fill("Customers.json", dbContext.Customers);
            dbContext.SaveChanges();
        }
    }
}
