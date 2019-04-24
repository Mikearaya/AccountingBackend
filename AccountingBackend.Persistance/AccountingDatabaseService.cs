/*
 * @CreateTime: Apr 23, 2019 7:04 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 24, 2019 1:57 PM
 * @Description: Modify Here, Please 
 */
using System;
using AccountingBackend.Domain.ApplicationUsers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AccountingBackend.Persistance {
    public class AccountingDatabaseService : IdentityDbContext<ApplicationUser> {
        private readonly IConfiguration _configuration;

        public AccountingDatabaseService (IConfiguration configuration) {
            _configuration = configuration;
        }

        public AccountingDatabaseService () {

        }

        protected override void OnConfiguring (DbContextOptionsBuilder optionBuilder) {
            optionBuilder.UseMySql ("server=localhost;user=admin;password=admin;port=3306;database=smart_accounting;");
        }
    }
}