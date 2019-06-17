/*
 * @CreateTime: Jun 5, 2019 1:31 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 5, 2019 2:26 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Application.Models;
using AccountingBackend.Application.Reports.Models;
using AccountingBackend.Commons;
using MediatR;

namespace AccountingBackend.Application.Reports.Queries.GetCostOfGoodsSold {
    public class GetCostOfGoodsSoldQueryHandler : IRequestHandler<GetCostOfGoodsSoldQuery, CostofGoodsSoldModel> {
        private readonly IAccountingDatabaseService _database;

        public CustomDateConverter dateConverter { get; }

        public GetCostOfGoodsSoldQueryHandler (IAccountingDatabaseService database) {
            _database = database;
            dateConverter = new CustomDateConverter ();
        }

        public Task<CostofGoodsSoldModel> Handle (GetCostOfGoodsSoldQuery request, CancellationToken cancellationToken) {

            var query = (from account_type in _database.AccountType
                .Where (a => a.TypeOfNavigation != null && a.TypeOfNavigation.Type.ToUpper () == "COST OF GOODS SOLD") join account_category in _database.AccountCatagory on account_type.Id equals account_category.AccountTypeId join account in _database.Account.Where (a => a.Year == request.Year) on account_category.Id equals account.CatagoryId join ledger_entry in _database.LedgerEntry on account.Id equals ledger_entry.AccountId select new {

                    Category = account_category,
                        Credit = ledger_entry.Credit,
                        Entry = ledger_entry,
                        Debit = ledger_entry.Debit,
                        type = account_type.TypeOfNavigation.Type

                });

            if (request.StartDate.Trim () != "") {
                query = query.Where (q => q.Entry.DateAdded >= dateConverter.EthiopicToGregorian (request.StartDate));
            }

            if (request.EndDate.Trim () != "") {
                query = query.Where (q => q.Entry.DateAdded <= dateConverter.EthiopicToGregorian (request.EndDate));
            }

            var result = query.GroupBy (ef => ef.Category.Catagory).ToList ()
                .Select (g => new {
                    CreditSum = g.Sum (t => t.Credit),
                        DebitSum = g.Sum (t => t.Debit),
                        AccountCategory = g.Key,

                });

            CostofGoodsSoldModel filter = new CostofGoodsSoldModel ();

            foreach (var item in result) {
                ((IList<CostOfGoodsSoldItemsModel>) filter.Accounts).Add (new CostOfGoodsSoldItemsModel () {
                    Value = item.DebitSum - item.CreditSum,
                        AccountName = item.AccountCategory
                });
            }

            return Task.FromResult<CostofGoodsSoldModel> (filter);
        }
    }
}