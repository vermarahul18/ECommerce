using ECommerce.Context.ECommDbContext;
using ECommerce.Logic;
using ECommerce.Logic.Implementation;
using ECommerce.repository.IRepository;
using ECommerce.repository.Repository;
using ECommerce.Service;
using ECommerce.Service.Helpers;
using ECommerce.Service.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Adding connection string to database
            services.AddDbContext<StoreContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"),
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                            maxRetryCount:3,
                            maxRetryDelay:TimeSpan.FromSeconds(30),
                            errorNumbersToAdd:null
                        );
                }),ServiceLifetime.Transient
            ) ;

            //add the files in the Di Container
            services.AddTransient<IProductService, ProductService>();

            services.AddTransient<IProductLogic, ProductLogic>();

            services.AddTransient<IProductRepository, ProductRepository>();
            //add automapper by adding package automapper.microsoft.dependencyinjection
            services.AddAutoMapper(typeof(MappingProfiles));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
