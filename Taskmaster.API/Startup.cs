using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Taskmaster.API.MappingProfiles;
using Taskmaster.Business.DataContract.Task;
using Taskmaster.Business.Managers;
using Taskmaster.Data.DataContext;
using Taskmaster.Data.DataContract.Task;
using Taskmaster.Data.Entities;
using Taskmaster.Data.Repositories;

namespace Taskmaster.API
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
            services.AddDbContext<TaskmasterContext>
                (options => options.UseNpgsql(
                    Configuration.GetConnectionString("DefaultConnection")
                    )
                );

            //Auth Settings
            IdentityBuilder builder = services.AddIdentityCore<UserEntity>(opt =>
            {
                opt.Password.RequireDigit = true;
                opt.Password.RequiredLength = 6;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = true;
            });

            builder = new IdentityBuilder(builder.UserType, typeof(RoleEntity), builder.Services);
            builder.AddEntityFrameworkStores<TaskmasterContext>();
            builder.AddRoleValidator<RoleValidator<RoleEntity>>();
            builder.AddRoleManager<RoleManager<RoleEntity>>();
            builder.AddSignInManager<SignInManager<UserEntity>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                            .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            // Add Cors
            services.AddCors(options => options.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddControllers();


            //Mapping Config
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TaskMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<ITaskManager, TaskManager>();
            services.AddScoped<ITaskRepository, TaskRepository>();

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

            //CORS issue
            app.UseCors("MyPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
