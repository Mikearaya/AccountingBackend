﻿/*
 * @CreateTime: Apr 26, 2019 9:27 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 9, 2019 7:57 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AccountingBackend.Application.Accounts.Models;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Domain;
using AccountingBackend.Persistance.AccountCatagories;
using AccountingBackend.Persistance.Accounts;
using AccountingBackend.Persistance.AccountTypes;
using AccountingBackend.Persistance.Ledgers;
using Microsoft.EntityFrameworkCore;

namespace AccountingBackend.Persistance {
    public class AccountingDatabaseService : DbContext, IAccountingDatabaseService {

        public AccountingDatabaseService (DbContextOptions<AccountingDatabaseService> options) : base (options) { }

        public AccountingDatabaseService () { }
        public DbSet<Account> Account { get; set; }
        public DbSet<AccountCatagory> AccountCatagory { get; set; }
        public DbSet<AccountType> AccountType { get; set; }
        public DbSet<SystemLookup> SystemLookup { get; set; }
        public DbSet<Ledger> Ledger { get; set; }
        public DbSet<LedgerEntry> LedgerEntry { get; set; }

        public void Save () {
            this.SaveChanges ();
        }

        public Task SaveAsync () {
            return this.SaveChangesAsync ();
        }

        protected override void OnConfiguring (DbContextOptionsBuilder optionBuilder) {
            if (!optionBuilder.IsConfigured) {
                optionBuilder.UseMySql ("server=localhost;user=admin;password=admin;port=3306;database=smart_accounting_ecafco;");
            }

        }

        protected override void OnModelCreating (ModelBuilder builder) {

            builder.ApplyConfigurationsFromAssembly (typeof (AccountingDatabaseService).Assembly);

        }

    }
}