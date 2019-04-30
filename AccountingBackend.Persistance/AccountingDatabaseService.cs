/*
 * @CreateTime: Apr 26, 2019 9:27 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 26, 2019 9:27 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Threading.Tasks;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Domain;
using AccountingBackend.Persistance.AccountCatagories;
using AccountingBackend.Persistance.Accounts;
using AccountingBackend.Persistance.AccountTypes;
using Microsoft.EntityFrameworkCore;

namespace AccountingBackend.Persistance {
    public class AccountingDatabaseService : DbContext, IAccountingDatabaseService {

        public DbSet<Account> Account { get; set; }
        public DbSet<AccountCatagory> AccountCatagory { get; set; }
        public DbSet<AccountType> AccountType { get; set; }

        public void Save () {
            this.SaveChanges ();
        }

        public Task SaveAsync () {
            return this.SaveChangesAsync ();
        }

        protected override void OnConfiguring (DbContextOptionsBuilder optionBuilder) {
            optionBuilder.UseMySql ("server=localhost;user=admin;password=admin;port=3306;database=smart_accounting;");

        }

        protected override void OnModelCreating (ModelBuilder builder) {
            base.OnModelCreating (builder);

            builder.ApplyConfiguration (new AccountConfiguration ());

            builder.ApplyConfiguration (new AccountTypeConfiguration ());
            builder.ApplyConfiguration (new AccountCategoryConfiguration ());

        }

    }
}