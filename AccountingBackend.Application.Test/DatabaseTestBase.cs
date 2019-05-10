/*
 * @CreateTime: May 10, 2019 10:00 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 10, 2019 4:13 PM
 * @Description: Modify Here, Please 
 */

using System;
using AccountingBackend.Persistance;
using Microsoft.EntityFrameworkCore;

namespace AccountingBackend.Application.Test {
    public class DatabaseTestBase : IDisposable {
        protected readonly AccountingDatabaseService _Database;
        public DatabaseTestBase () {
            var options = new DbContextOptionsBuilder<AccountingDatabaseService> ()
                .UseInMemoryDatabase (databaseName: Guid.NewGuid ().ToString ())
                .Options;

            _Database = new AccountingDatabaseService (options);
            _Database.Database.EnsureCreated ();

            DatabaseInitializer.Initialize (_Database);

        }

        public void Dispose () {
            _Database.Database.EnsureDeleted ();
            _Database.Dispose ();
        }
    }
}