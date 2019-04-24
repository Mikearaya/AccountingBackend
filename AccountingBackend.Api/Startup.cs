/*
 * @CreateTime: Apr 24, 2019 1:56 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 24, 2019 1:56 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingBackend.Domain.ApplicationUsers;
using AccountingBackend.Persistance;
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

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_2);
            services.AddIdentityCore<ApplicationUser> (options => { });
            new IdentityBuilder (typeof (ApplicationUser), typeof (IdentityRole), services)
                .AddRoleManager<RoleManager<IdentityRole>> ()
                .AddSignInManager<SignInManager<ApplicationUser>> ()
                .AddEntityFrameworkStores<AccountingDatabaseService> ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts ();
            }

            app.UseAuthentication ();

            app.UseHttpsRedirection ();
            app.UseMvc ();
        }
    }
}