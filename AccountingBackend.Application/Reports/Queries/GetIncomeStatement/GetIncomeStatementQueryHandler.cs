/*
 * @CreateTime: May 17, 2019 6:03 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 17, 2019 7:23 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Application.Reports.Models;
using MediatR;

namespace AccountingBackend.Application.Reports.Queries.GetIncomeStatement {
    public class GetIncomeStatementQueryHandler : IRequestHandler<GetIncomeStatementQuery, IncomeStatementViewModel> {
        private IAccountingDatabaseService _database;

        public GetIncomeStatementQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public Task<IncomeStatementViewModel> Handle (GetIncomeStatementQuery request, CancellationToken cancellationToken) {
            var x = _database.LedgerEntry.Join (_database.Account,
                    ledger => ledger.AccountId, account => account.Id, (ledger, account) => new { ledger, account })
                .Join (_database.AccountCatagory
                    .Where (a => a.AccountType.TypeOfNavigation.Type.ToUpper () == "EXPENSE" ||
                        a.AccountType.TypeOfNavigation.Type.ToUpper () == "REVENUE"), cat => cat.account.CatagoryId, account => account.Id, (cat, account) => new { cat, account })
                .Select (xf => new {
                    ShowGrouped = xf.cat.account.Catagory.AccountType.IsSummery == 1 ? true : false,
                        AccountType = xf.cat.account.Catagory.AccountType.Type,
                        Category = xf.cat.account.Catagory.Catagory,
                        Credit = (decimal?) xf.cat.ledger.Credit,
                        Debit = (decimal?) xf.cat.ledger.Debit
                }).ToList ();

            foreach (var item in x) {
                Console.WriteLine ($" ------ category {item.Category} ---- ACCOUNT TYPE ---- {item.AccountType} {item.Credit} {item.Debit} ");
            }

            IncomeStatementViewModel incomeStateMent = new IncomeStatementViewModel ();

            return Task.FromResult (incomeStateMent);
        }
    }
}