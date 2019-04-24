/*
 * @CreateTime: Apr 24, 2019 1:56 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 24, 2019 7:00 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AccountingBackend.Api.Filters;
using AccountingBackend.Application.Accounts.Commands.CreateAccount;
using AccountingBackend.Application.Accounts.Queries.GetAccount;
using AccountingBackend.Application.Infrastructure;
using AccountingBackend.Domain.ApplicationUsers;
using AccountingBackend.Persistance;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
namespace AccountingBackend.Api {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;

            using (var context = new AccountingDatabaseService ()) {
                context.Database.EnsureCreated ();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {

            services.AddIdentityCore<ApplicationUser> (options => { });
            new IdentityBuilder (typeof (ApplicationUser), typeof (IdentityRole), services)
                .AddRoleManager<RoleManager<IdentityRole>> ()
                .AddSignInManager<SignInManager<ApplicationUser>> ()
                .AddEntityFrameworkStores<AccountingDatabaseService> ();

            // register swagger service
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
            services.AddMediatR (typeof (GetAccountQueryHandler).GetTypeInfo ().Assembly);
            services.AddTransient (typeof (IPipelineBehavior<,>), typeof (RequestPerformanceBehaviour<,>));
            services.AddTransient (typeof (IPipelineBehavior<,>), typeof (RequestValidationBehavior<,>));

            services.AddMvc (options => options.Filters.Add (typeof (CustomExceptionFilterAttribute)))
                .SetCompatibilityVersion (CompatibilityVersion.Version_2_2)
                .AddFluentValidation (fv => fv.RegisterValidatorsFromAssemblyContaining<CreateAccountCommandValidator> ());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts ();
            }

            app.UseSwagger ();
            app.UseSwaggerUi3 ();
            app.UseAuthentication ();

            app.UseHttpsRedirection ();
            app.UseMvc ();
        }
    }
}