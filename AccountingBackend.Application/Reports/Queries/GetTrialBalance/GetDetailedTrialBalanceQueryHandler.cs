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
    public class GetDetailedTrialBalanceQueryHandler : IRequestHandler<GetDetailedTrialBalanceQuery, IList<TrialBalanceDetailModel>> {
        private readonly IAccountingDatabaseService _database;

        public GetDetailedTrialBalanceQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public Task<IList<TrialBalanceDetailModel>> Handle (GetDetailedTrialBalanceQuery request, CancellationToken cancellationToken) {

            var fromLedger = _database.LedgerEntry
                .Join (_database.Account.Where (a => a.Year == request.Year),
                    ledger => ledger.AccountId, account => account.Id, (ledger, account) => new {
                        ParentAccount = account.ParentAccountNavigation,
                            AccountId = $"{account.ParentAccountNavigation.AccountId} {account.AccountId}",
                            AccountName = $"{account.AccountName}",
                            Credit = (decimal?) account.LedgerEntry.Sum (d => d.Credit),
                            Debit = (decimal?) account.LedgerEntry.Sum (d => d.Debit)
                    }).ToList ();

            var grouped = fromLedger.GroupBy (c => c.ParentAccount)
                .Select (x => new {
                    ParentName = x.Key.AccountName,
                        ControlAccountId = x.Key.Id,
                        ParentId = x.Key.AccountId,
                        Subsidaries = x.Select (f => new {
                            AccountName = f.AccountName,
                                ControlAccountId = f.ParentAccount.Id,
                                AccountId = f.AccountId,
                                Credit = (decimal?) f.Credit,
                                Debit = (decimal?) f.Debit
                        })
                });

            IList<TrialBalanceDetailModel> detail = new List<TrialBalanceDetailModel> ();

            foreach (var parent in grouped) {
                TrialBalanceDetailModel temp = new TrialBalanceDetailModel () {
                    ControlAccountId = parent.ControlAccountId,
                    AccountId = parent.ParentId,
                    AccountName = parent.ParentName
                };

                foreach (var sub in parent.Subsidaries) {

                    temp.Entries.Add (new TrialBalanceDetailListModel () {
                        AccountName = sub.AccountName,
                            ControlAccountId = sub.ControlAccountId,
                            Credit = sub.Credit,
                            Debit = sub.Debit,
                            AccountId = sub.AccountId
                    });

                }

                detail.Add (temp);

            }

            return Task.FromResult (detail);

        }
    }
}