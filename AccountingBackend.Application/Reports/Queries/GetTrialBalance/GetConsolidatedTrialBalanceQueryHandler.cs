/*
 * @CreateTime: May 15, 2019 6:47 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 15, 2019 7:09 PM
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
    public class GetConsolidatedTrialBalanceQueryHandler : IRequestHandler<GetConsolidatedTrialBalanceQuery, IEnumerable<TrialBalanceModel>> {
        private readonly IAccountingDatabaseService _database;

        public GetConsolidatedTrialBalanceQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<TrialBalanceModel>> Handle (GetConsolidatedTrialBalanceQuery request, CancellationToken cancellationToken) {

            return await _database.LedgerEntry.Join (_database.Account, l => l.AccountId, a => a.Id, (l, a) => new {
                    AccountId = a.ParentAccountNavigation.AccountId,
                        AccountName = a.ParentAccountNavigation.AccountName,
                        Credit = a.LedgerEntry.Sum (c => (decimal?) c.Credit),
                        Debit = a.LedgerEntry.Sum (c => (decimal?) c.Debit)
                }).GroupBy (a => a.AccountId)
                .Select (x => new TrialBalanceModel () {
                    AccountId = x.Key,
                        Credit = x.Sum (c => c.Credit),
                        AccountName = x.Select (s => s.AccountName).First (),
                        Debit = x.Sum (c => c.Debit),
                }).ToListAsync ();

        }
    }
}