using Assessment.BusinessLogicLayer;
using Assessment.BusinessLogicLayer.interfaces;
using Assessment.DataAccessLayer.Models;
using Assessment.DataAccessLayer.Repository;
using Assessment.DataAccessLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Services
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


            services.AddCors(c =>
            {
                c.AddPolicy("MyPolicy", options =>
                options.AllowAnyOrigin()
                    .AllowAnyMethod()
                   .AllowAnyHeader());
            });
            //Entity Framework
            services.AddDbContext<AssessmentDBContext>(options =>
          options.UseSqlServer(Configuration.GetConnectionString("AssessmentDBConnection")));

            //dependency injection
            services.AddScoped<IPersonProcessor, PersonProcessor>();
            services.AddScoped<IPersonRepository, PersonRepository>();

            services.AddScoped<ILookupProcessor, LookupProcessor>();
            services.AddScoped<ICityRepository, CityRepository>();

            //Swagger Config
            var contact = new OpenApiContact()
            {
                Name = "Hello assessment",
                Email = "assessment@gmail.com",
                Url = new Uri("http://www.assessment.com")
            };

            var license = new OpenApiLicense()
            {
                Name = "My License",
                Url = new Uri("http://www.assessment.com")
            };

            var info = new OpenApiInfo()
            {
                Version = "v1",
                Title = "Swagger RDC API",
                Description = "Swagger Demo API Description",
                TermsOfService = new Uri("http://www.assessment.com"),
                Contact = contact,
                License = license
            };

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", info);

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("MyPolicy");
            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                "Swagger Demo API v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
