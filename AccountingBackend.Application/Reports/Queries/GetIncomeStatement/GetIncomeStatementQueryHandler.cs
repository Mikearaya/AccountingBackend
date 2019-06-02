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

            var query = (from account_type in _database.AccountType
                .Where (a => a.TypeOfNavigation != null && (a.TypeOfNavigation.Type.ToUpper () == "EXPENSE" || a.TypeOfNavigation.Type.ToUpper () == "REVENUE")) join account_category in _database.AccountCatagory on account_type.Id equals account_category.AccountTypeId join account in _database.Account.Where (a => a.Year == request.Year) on account_category.Id equals account.CatagoryId join ledger_entry in _database.LedgerEntry on account.Id equals ledger_entry.AccountId select new {
                    AccountType = account_type,
                        Category = account_category,
                        Credit = ledger_entry.Credit,
                        Entry = ledger_entry,
                        Debit = ledger_entry.Debit,
                        type = account_type.TypeOfNavigation.Type

                });

            if (request.StartDate != null) {
                query = query.Where (q => q.Entry.DateAdded >= request.StartDate);
            }

            if (request.EndDate != null) {
                query = query.Where (q => q.Entry.DateAdded <= request.EndDate);
            }

            var result = query.GroupBy (ef => ef.AccountType.IsSummery == 1 ? ef.AccountType.Type : ef.Category.Catagory).ToList ()
                .Select (g => new {
                    CreditSum = g.Sum (t => t.Credit),
                        DebitSum = g.Sum (t => t.Debit),
                        AccountCategory = g.Key,
                        Type = g.Select (d => d.type)
                });

            IncomeStatementViewModel incomeStateMent = new IncomeStatementViewModel ();

            float? totalRevenue = 0;
            float? totalExpence = 0;
            float? revenue = 0;
            float? expense = 0;
            foreach (var item in result) {

                if (item.Type.FirstOrDefault ().ToString ().ToUpper () == "REVENUE") {
                    revenue = item.DebitSum - item.CreditSum;
                    totalRevenue += revenue;
                    incomeStateMent.Revenue.Add (new IncomeStatementItemModel () {
                        AccountType = item.AccountCategory,
                            Amount = revenue
                    });
                } else if (item.Type.FirstOrDefault ().ToString ().ToUpper () == "EXPENSE") {
                    expense = item.CreditSum - item.DebitSum;
                    totalExpence += expense;
                    incomeStateMent.Expense.Add (new IncomeStatementItemModel () {
                        AccountType = item.AccountCategory,
                            Amount = expense
                    });
                }

            }

            incomeStateMent.NetSurplus = totalRevenue - totalExpence;

            return Task.FromResult (incomeStateMent);
        }
    }
}