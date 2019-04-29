/*
 * @CreateTime: Apr 24, 2019 1:56 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 26, 2019 9:28 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AccountingBackend.Api.Commons;
using AccountingBackend.Api.Configurations;
using AccountingBackend.Api.Filters;
using AccountingBackend.Application.Accounts.Commands.CreateAccount;
using AccountingBackend.Application.Accounts.Queries.GetAccount;
using AccountingBackend.Application.Infrastructure;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Application.Users.Commands.CreateUser;
using AccountingBackend.Persistance;
using BackendSecurity.Domain.Identity;
using BackendSecurity.Persistance;
using FluentValidation.AspNetCore;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

[assembly : ApiController]
[assembly : ApiConventionType (typeof (CustomApiConventions))]
namespace AccountingBackend.Api {
    /// <summary>
    /// System start up class
    /// </summary>
    public class Startup {

        /// <summary>
        /// statup class constructor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup (IConfiguration configuration) {
            Configuration = configuration;

            using (var context = new SecurityDatabaseService ()) {
                context.Database.EnsureCreated ();
            }

            using (var context = new AccountingDatabaseService ()) {
                context.Database.EnsureCreated ();
            }

        }
        /// <summary>
        /// configuration object
        /// </summary>
        /// <value></value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices (IServiceCollection services) {

            JwtSettings settings;
            settings = GetJwtSettings ();

            services.AddSingleton<JwtSettings> (settings);
            services.AddScoped<ISecurityDatabaseService, SecurityDatabaseService> ();
            services.AddDbContext<SecurityDatabaseService> ();

            services.AddScoped<IAccountingDatabaseService, AccountingDatabaseService> ();
            services.AddDbContext<AccountingDatabaseService> ();

            services.AddAuthentication (options => {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            }).AddJwtBearer ("JwtBearer", jwtBearerOptions => {
                jwtBearerOptions.TokenValidationParameters =
                new TokenValidationParameters {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey (
                Encoding.UTF8.GetBytes (settings.Key)),
                ValidateIssuer = true,
                ValidIssuer = settings.Issuer,
                ValidateAudience = true,
                ValidAudience = settings.Audience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromMinutes (settings.MinutesToExpiration)
                    };
            });

            services.AddIdentityCore<ApplicationUser> (options => { });
            new IdentityBuilder (typeof (ApplicationUser), typeof (IdentityRole), services)
                .AddRoleManager<RoleManager<IdentityRole>> ()
                .AddSignInManager<SignInManager<ApplicationUser>> ()
                .AddEntityFrameworkStores<SecurityDatabaseService> ();

            services.AddSwaggerDocument (config => {
                config.PostProcess = document => {
                    document.Info.Version = "v1";
                    document.Info.Title = "Accounting API";
                    document.Info.Description = "API responsible for accounting system";
                    document.Info.TermsOfService = "None";
                    document.Info.Contact = new NSwag.SwaggerContact {
                        Name = "Mikael Araya",
                        Email = "Mikaelaraya12@gmail.com",
                        Url = string.Empty
                    };
                    document.Info.License = new NSwag.SwaggerLicense {
                        Name = "Use under LICX",
                        Url = "https://appdiv.com/license"
                    };
                };
            });
            services.AddMediatR (typeof (CreateUserCommandHandler).GetTypeInfo ().Assembly);

            services.AddTransient (typeof (IPipelineBehavior<,>), typeof (RequestPreProcessorBehavior<,>));
            services.AddTransient (typeof (IPipelineBehavior<,>), typeof (RequestPerformanceBehaviour<,>));
            // services.AddTransient (typeof (IPipelineBehavior<,>), typeof (RequestValidationBehavior<,>));

            services.AddCors (options => {
                options.AddPolicy ("AllowAllOrigins",
                    builder => builder.AllowAnyOrigin ().AllowAnyMethod ().AllowAnyHeader ());
            });
            services.AddMvc (options => options.Filters.Add (typeof (CustomExceptionFilterAttribute)))
                .SetCompatibilityVersion (CompatibilityVersion.Version_2_2)
                .AddFluentValidation (fv => fv.RegisterValidatorsFromAssemblyContaining<CreateAccountCommandValidator> ());

            services.Configure<IdentityOptions> (options => {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 1;
                options.Password.RequiredUniqueChars = 0;
                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes (5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //        app.UseHsts ();
            }

            app.UseAuthentication ();
            app.UseCors ("AllowAllOrigins");
            //  app.UseHttpsRedirection ();

            app.UseMvc ();

            app.UseSwagger ();
            app.UseSwaggerUi3 ();
        }

        /// <summary>
        /// function that reads configuration file from app.js
        /// </summary>
        /// <returns>jetsettings</returns>
        public JwtSettings GetJwtSettings () {
            JwtSettings settings = new JwtSettings ();

            settings.Key = Configuration["JwtSettings:key"];
            settings.Audience = Configuration["JwtSettings:audience"];
            settings.Issuer = Configuration["JwtSettings:issuer"];
            settings.MinutesToExpiration = Convert.ToInt32 (Configuration["JwtSettings:minutesToExpiration"]);

            return settings;
        }
    }
}