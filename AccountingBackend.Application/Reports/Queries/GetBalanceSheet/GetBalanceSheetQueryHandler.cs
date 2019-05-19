/*
 * @CreateTime: May 19, 2019 8:54 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 19, 2019 9:57 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Application.Reports.Models;
using MediatR;

namespace AccountingBackend.Application.Reports.Queries.GetBalanceSheet {
    public class GetBalanceSheetQueryHandler : IRequestHandler<GetBalanceSheetQuery, BalanceSheetViewModel> {
        private readonly IAccountingDatabaseService _database;

        public GetBalanceSheetQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public Task<BalanceSheetViewModel> Handle (GetBalanceSheetQuery request, CancellationToken cancellationToken) {
            var query = (from account_type in _database.AccountType
                .Where (a => a.TypeOfNavigation != null && (a.TypeOfNavigation.Type.ToUpper () == "ASSET" ||
                    a.TypeOfNavigation.Type.ToUpper () == "CAPITAL" ||
                    a.TypeOfNavigation.Type.ToUpper () == "LIABILITY"

                )) join account_category in _database.AccountCatagory on account_type.Id equals account_category.AccountTypeId join account in _database.Account.Where (a => a.Year == request.Year) on account_category.Id equals account.CatagoryId join ledger_entry in _database.LedgerEntry on account.Id equals ledger_entry.AccountId select new {
                    AccountType = account_type,
                        Category = account_category,
                        Credit = ledger_entry.Credit,
                        Entry = ledger_entry,
                        Debit = ledger_entry.Debit,
                        type = account_type.TypeOfNavigation.Type
                });

            if (request.StartDate != null) {
                query = query.Where (l => l.Entry.DateAdded >= request.StartDate);
            }

            if (request.EndDate != null) {
                query = query.Where (l => l.Entry.DateAdded <= request.EndDate);
            }

            var result = query.GroupBy (ef => ef.AccountType.IsSummery == 1 ? ef.AccountType.Type : ef.Category.Catagory).ToList ()
                .Select (g => new {
                    CreditSum = g.Sum (t => t.Credit),
                        DebitSum = g.Sum (t => t.Debit),
                        AccountCategory = g.Key,
                        Type = g.Select (d => d.type)
                });

            BalanceSheetViewModel balanceSheet = new BalanceSheetViewModel ();
            float? totalAsset = 0;
            float? totalLiability = 0;
            float? totalCapital = 0;

            float? capital = 0;
            float? asset = 0;
            float? liability = 0;

            foreach (var item in result) {

                Console.WriteLine ($"{item.AccountCategory}  --- credit --- {item.CreditSum} -- debit --- {item.DebitSum} --");
                if (item.Type.FirstOrDefault ().ToString ().ToUpper () == "ASSET") {
                    asset = item.DebitSum - item.CreditSum;
                    totalAsset = asset;
                    balanceSheet.Assets.Add (new BalanceSheetItemModel () {
                        AccountCategory = item.AccountCategory,
                            Amount = asset
                    });
                } else if (item.Type.FirstOrDefault ().ToString ().ToUpper () == "LIABILITY") {
                    liability = item.CreditSum - item.DebitSum;
                    totalLiability = liability;
                    balanceSheet.Liabilities.Add (new BalanceSheetItemModel () {
                        AccountCategory = item.AccountCategory,
                            Amount = liability
                    });

                } else if (item.Type.FirstOrDefault ().ToString ().ToUpper () == "CAPITAL") {
                    capital = item.CreditSum - item.DebitSum;
                    totalCapital = capital;
                    balanceSheet.Capitals.Add (new BalanceSheetItemModel () {
                        AccountCategory = item.AccountCategory,
                            Amount = capital
                    });

                }
            }

            balanceSheet.TotalCapital = totalCapital;
            balanceSheet.TotalAsset = totalAsset - totalLiability;
            balanceSheet.TotalLiability = totalLiability;

            return Task.FromResult (balanceSheet);
        }
    }

}