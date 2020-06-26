using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GoingTo_API_DP.Domain.Persistence.Context;
using GoingTo_API_DP.Domain.Repositories;
using GoingTo_API_DP.Domain.Repositories.Accounts;
using GoingTo_API_DP.Domain.Repositories.Business;
using GoingTo_API_DP.Domain.Repositories.Geographic;
using GoingTo_API_DP.Domain.Services;
using GoingTo_API_DP.Domain.Services.Accounts;
using GoingTo_API_DP.Domain.Services.Business;
using GoingTo_API_DP.Persistence;
using GoingTo_API_DP.Persistence.Repositories;
using GoingTo_API_DP.Service;
using GoingTo_API_DP.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GoingTo_API_DP
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
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddMvc();

            services.AddControllers();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserProfileRepository, ProfileRepository>();
            services.AddScoped<IPlanRepository, PlanRepository>();
            services.AddScoped<IUserPlanRepository, UserPlanRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ILocatableRepository, LocatableRepository>();
            services.AddScoped<IPlaceRepository, PlaceRepository>();
            services.AddScoped<ITripRepository, TripRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserProfileService, ProfileService>();
            services.AddScoped<IPlanService, PlanService>();
            services.AddScoped<IUserPlanService, UserPlanService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ILocatableService, LocatableService>();
            services.AddScoped<IPlaceService, PlaceService>();
            services.AddScoped<ITripService, TripService>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();
     

            services.AddAutoMapper(typeof(Startup));

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
