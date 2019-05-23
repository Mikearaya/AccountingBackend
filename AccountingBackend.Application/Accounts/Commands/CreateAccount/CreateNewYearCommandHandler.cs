/*
 * @CreateTime: May 23, 2019 9:32 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 23, 2019 1:44 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AccountingBackend.Application.Accounts.Commands.CreateAccount {
    public class CreateNewYearCommandHandler : IRequestHandler<CreateNewYearCommand, Unit> {
        private readonly IAccountingDatabaseService _database;

        public CreateNewYearCommandHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (CreateNewYearCommand request, CancellationToken cancellationToken) {

            var deletes = _database.Account.Where (y => y.Year == "2012" || y.Year == "2013" || y.Year == "2014");
            _database.Account.RemoveRange (deletes);
            await _database.SaveAsync ();

            var lastYear = _database.Account.Max (b => b.Year);
            var accounts = await _database.Account.Where (y => y.Year == lastYear)
                .Include (l => l.LedgerEntry)
                .Include (a => a.Catagory)
                .ThenInclude (a => a.AccountType)
                .Select (f => new {
                    Category = f.CatagoryId,
                        Name = f.AccountName,
                        AccountId = f.AccountId,
                        Parent = f.ParentAccount,
                        CostCenter = f.CostCenterId,
                        CreditSum = (decimal?) f.LedgerEntry.Sum (c => (decimal?) c.Credit),
                        DebitSum = (decimal?) f.LedgerEntry.Sum (d => (decimal?) d.Debit),
                        Type = f.Catagory.AccountType.TypeOfNavigation.Type,
                        Balance = (decimal?) f.OpeningBalance,
                        Year = f.Year
                })
                .ToListAsync ();

            IList<Account> accountsList = new List<Account> ();

            int result = Int32.Parse (lastYear);

            var grouped = accounts.GroupBy (g => g.Type);

            foreach (var item in grouped) {

                foreach (var i in item) {
                    Account account = new Account () {
                        AccountId = i.AccountId,
                        ParentAccount = i.Parent,
                        AccountName = i.Name,
                        CostCenterId = i.CostCenter,
                        CatagoryId = i.Category,
                        OpeningBalance = 0,
                        Year = (result + 1).ToString ()
                    };

                    if (item.Key.ToUpper () == "ASSET") {
                        account.OpeningBalance = (float?) i.Balance + ((float?) i.DebitSum - (float?) i.CreditSum);

                    } else if (item.Key.ToUpper () == "LIABILITY" || item.Key.ToUpper () == "CAPITAL") {
                        account.OpeningBalance = (float?) i.Balance + ((float?) i.CreditSum - (float?) i.DebitSum);

                    }

                    accountsList.Add (account);
                }
            }
            await _database.Account.AddRangeAsync (accountsList);
            await _database.SaveAsync ();

            return Unit.Value;

        }
    }
}