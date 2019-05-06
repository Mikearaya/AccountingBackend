/*
 * @CreateTime: Apr 26, 2019 9:29 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 6, 2019 10:33 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AccountingBackend.Application.Accounts.Models;
using AccountingBackend.Domain;
using Microsoft.EntityFrameworkCore;

namespace AccountingBackend.Application.Interfaces {
    public interface IAccountingDatabaseService {

        DbSet<Account> Account { get; set; }
        DbSet<AccountCatagory> AccountCatagory { get; set; }
        DbSet<AccountType> AccountType { get; set; }
        DbSet<SystemLookup> SystemLookup { get; set; }

        void Save ();
        Task SaveAsync ();

    }
}