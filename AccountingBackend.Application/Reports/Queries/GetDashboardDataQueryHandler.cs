/*
 * @CreateTime: May 25, 2019 4:09 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 25, 2019 5:27 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Application.Reports.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AccountingBackend.Application.Reports.Queries {
    public class GetDashboardDataQueryHandler : IRequestHandler<GetDashboardDataQuery, DashboardViewModel> {
        private readonly IAccountingDatabaseService _database;

        public GetDashboardDataQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<DashboardViewModel> Handle (GetDashboardDataQuery request, CancellationToken cancellationToken) {

            var result = await (from account_type in _database.AccountType.Where (a => a.TypeOfNavigation != null) join account_category in _database.AccountCatagory on account_type.Id equals account_category.AccountTypeId join account in _database.Account on account_category.Id equals account.Id select new {

                    accountType = account_type.TypeOfNavigation.Type,
                        creditSum = account_category.Account.Sum (e => (decimal?) e.LedgerEntry.Sum (c => (decimal?) c.Credit)),
                        debitSum = account_category.Account.Sum (e => (decimal?) e.LedgerEntry.Sum (d => (decimal?) d.Debit)),
                        openingBalance = account_category.Account.Sum (e => (decimal?) e.OpeningBalance)
                })
                .GroupBy (c => c.accountType)
                .ToListAsync ();

            DashboardViewModel view = new DashboardViewModel ();

            foreach (var item in result) {
                var CreditSum = item.Sum (c => (decimal?) c.creditSum);
                var DebitSum = item.Sum (c => (decimal?) c.debitSum);
                var OpeningBalanceSum = item.Sum (o => (decimal?) o.openingBalance);
                var credit = 0;
                var debit = 0;
                var openingBalance = 0;

                if (item.Key.ToUpper () == "LIABILITY") {
                    view.TotalLiability = openingBalance + (CreditSum - DebitSum);

                } else if (item.Key.ToUpper () == "CAPITAL") {
                    view.TotalCapital = openingBalance + (CreditSum - DebitSum);

                } else if (item.Key.ToUpper () == "ASSET") {
                    view.TotalAssets = openingBalance + (DebitSum + CreditSum);

                } else if (item.Key.ToUpper () == "EXPENSE") {
                    view.TotalExpense = openingBalance + (DebitSum + CreditSum);

                } else if (item.Key.ToUpper () == "REVENUE") {
                    view.TotalRevenue = openingBalance + (DebitSum + CreditSum);

                }

            }
            return view;
        }
    }
}