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

            var query = (from account_type in _database.AccountType.Where (a => a.TypeOf == 6 || a.TypeOf == 4) join account_category in _database.AccountCatagory on account_type.Id equals account_category.AccountTypeId join account in _database.Account on account_category.Id equals account.CatagoryId join ledger_entry in _database.LedgerEntry on account.Id equals ledger_entry.AccountId select new {
                    AccountType = account_type,
                        Category = account_category,
                        Credit = ledger_entry.Credit,
                        Debit = ledger_entry.Debit,
                        type = account_type.TypeOfNavigation.Type

                })
                .GroupBy (ef => ef.AccountType.IsSummery == 1 ? ef.AccountType.Type : ef.Category.Catagory).ToList ()
                .Select (g => new {
                    CreditSum = g.Sum (t => t.Credit),
                        DebitSum = g.Sum (t => t.Debit),

                        AccountCategory = g.Key,
                        Type = g.Select (d => d.type)
                });

            IncomeStatementViewModel incomeStateMent = new IncomeStatementViewModel ();
            foreach (var item in query) {

                if (item.Type.FirstOrDefault ().ToString ().ToUpper () == "REVENUE") {
                    incomeStateMent.Revenue.Add (new IncomeStatementItemModel () {
                        AccountType = item.AccountCategory,
                            Amount = item.DebitSum - item.CreditSum
                    });
                } else if (item.Type.FirstOrDefault ().ToString ().ToUpper () == "EXPENSE")
                    incomeStateMent.Expense.Add (new IncomeStatementItemModel () {
                        AccountType = item.AccountCategory,
                            Amount = item.DebitSum - item.CreditSum
                    });

            }

            return Task.FromResult (incomeStateMent);
        }
    }
}