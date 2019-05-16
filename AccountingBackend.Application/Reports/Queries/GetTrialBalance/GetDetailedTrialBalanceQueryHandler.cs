/*
 * @CreateTime: May 15, 2019 7:34 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 15, 2019 7:35 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Application.Reports.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AccountingBackend.Application.Reports.Queries.GetTrialBalance {
    public class GetDetailedTrialBalanceQueryHandler : IRequestHandler<GetDetailedTrialBalanceQuery, IEnumerable<TrialBalanceDetailModel>> {
        private readonly IAccountingDatabaseService _database;

        public GetDetailedTrialBalanceQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public Task<IEnumerable<TrialBalanceDetailModel>> Handle (GetDetailedTrialBalanceQuery request, CancellationToken cancellationToken) {

            var xy = (from acc in _database.Account join jor in _database.LedgerEntry on acc.Id equals jor.AccountId select new TrialBalanceDetailListModel () {
                ControlAccountId = acc.ParentAccountNavigation.AccountId,
                    SubSidaryId = acc.AccountId,
                    AccountName = acc.AccountName,
                    Credit = (decimal?) jor.Credit,
                    Debit = (decimal?) jor.Debit,
            });

            var dd = from m in _database.Account
            join e1 in _database.Account on m.ParentAccount equals e1.Id
            select new TrialBalanceDetailListModel {
                ControlAccountId = m.ParentAccountNavigation.AccountId,
                SubSidaryId = m.AccountId,
                AccountName = e1.AccountName,

            };

            var d = _database.Account
                .FromSql ("select distinct ANY_VALUE(c.AccountId), account.AccountId, ANY_VALUE(a.type), SUM(le.credit),   SUM(le.debit) from account join account as c on account.ID = c.parent_account join ledger_entry le on account.ID = le.ACCOUNT_ID join account_catagory ac on account.CATAGORY_ID = ac.ID join account_type a on ac.account_type_id = a.ID join account_type at on a.type_of = at.ID group by account.AccountId");

            foreach (var item in d) {
                Console.WriteLine ($"{item.AccountName}");
            }

            foreach (var item in dd) {
                Console.WriteLine ($"{item.ControlAccountId} Subsidary {item.SubSidaryId}  {item.Credit} {item.Debit}  {item.AccountName}");

            }

            IEnumerable<TrialBalanceDetailModel> detail = new List<TrialBalanceDetailModel> ();

            return Task.FromResult (detail);
            /* return await _database.Account
                .Where (a => a.ParentAccountNavigation == null)
                .Where (a => a.Year == request.Year)
                .Select (TrialBalanceDetailModel.Projection)
                .ToListAsync (); */

        }
    }
}