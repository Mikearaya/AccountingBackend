/*
 * @CreateTime: Apr 24, 2019 4:50 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 7, 2019 12:17 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Domain;
using MediatR;

namespace AccountingBackend.Application.Accounts.Commands.CreateAccount {
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, int> {
        private readonly IAccountingDatabaseService _database;

        public CreateAccountCommandHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<int> Handle (CreateAccountCommand request, CancellationToken cancellationToken) {
            var currentYear = _database.Account.Max (a => a.Year);

            var account = new Account () {
                AccountName = request.Name,
                Active = request.Active,
                CatagoryId = request.CatagoryId,
                AccountId = request.AccountId,
                Year = currentYear,
                OpeningBalance = request.OpeningBalance,
                DateAdded = DateTime.Now,
                DateUpdated = DateTime.Now
            };

            if (request.ParentAccount != 0) {
                account.ParentAccount = request.ParentAccount;
            }

            if (request.CostCenterId != 0) {
                account.CostCenterId = request.CostCenterId;
            }
            _database.Account.Add (account);

            await _database.SaveAsync ();

            return account.Id;
        }
    }
}