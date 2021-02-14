﻿using AutoMapper;
using eHairdresserSalonFare.Api.IRepository;
using eHairdresserSalonFare.Api.Repository;
using eHairdresserSalonFare.Api.Security;
using eHairdresserSalonFare.Model.Requests.Hairdresser;
using eHairdresserSalonFare.Model.Requests.Hairstyle;
using eHairdresserSalonFare.Model.Requests.Payment;
using eHairdresserSalonFareBugojno.DBContext;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;


namespace eHairdresserSalonFare.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.AddAuthentication("BasicAuthentication")
               .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBaseCRUDRepository<Model.Hairdresser, HairdresserSearchRequest, HairdresserUpsertRequest, HairdresserUpsertRequest>, HairdresserRepository>();
            services.AddScoped<IBaseCRUDRepository<Model.Hairstyle, HairstyleSearchRequest, HairstyleUpsertRequest, HairstyleUpsertRequest>, HairstyleRepository>();
            services.AddScoped<IBaseCRUDRepository<Model.Payment, PaymentSearchRequest, PaymentUpsertRequest, PaymentUpsertRequest>, PaymentRepository>();


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
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}