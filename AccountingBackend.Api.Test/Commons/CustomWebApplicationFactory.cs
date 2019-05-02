/*
 * @CreateTime: May 1, 2019 10:12 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 1, 2019 10:18 AM
 * @Description: Modify Here, Please 
 */
using System;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Persistance;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AccountingBackend.Api.Test.Commons {
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class {
        protected override void ConfigureWebHost (IWebHostBuilder builder) {
            builder.ConfigureServices (services => {
                // Create a new service provider.
                var serviceProvider = new ServiceCollection ()
                    .AddEntityFrameworkInMemoryDatabase ()
                    .BuildServiceProvider ();

                // Add a database context using an in-memory 
                // database for testing.
                services.AddDbContext<IAccountingDatabaseService, AccountingDatabaseService> (options => {
                    options.UseInMemoryDatabase (databaseName: "InMemoryDbForTesting").EnableSensitiveDataLogging ();
                    options.UseInternalServiceProvider (serviceProvider);
                });

                // Build the service provider.
                var sp = services.BuildServiceProvider ();

                // Create a scope to obtain a reference to the database
                // context (NorthwindDbContext)
                using (var scope = sp.CreateScope ()) {
                    var scopedServices = scope.ServiceProvider;
                    var context = scopedServices.GetRequiredService<IAccountingDatabaseService> ();
                    var logger = scopedServices
                        .GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>> ();

                    var concreteContext = (AccountingDatabaseService) context;

                    // Ensure the database is created.
                    concreteContext.Database.EnsureDeleted ();
                    concreteContext.Database.EnsureCreated ();

                    try {
                        // Seed the database with test data.
                        Utilities.InitializeDbForTests (concreteContext);

                    } catch (Exception ex) {
                        logger.LogError (ex, $"An error occurred seeding the " +
                            "database with test messages. Error: {ex.Message}");
                    }
                }
            });
        }
    }
}