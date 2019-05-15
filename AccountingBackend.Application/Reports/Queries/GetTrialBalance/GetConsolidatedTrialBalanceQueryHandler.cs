/*
 * @CreateTime: May 15, 2019 6:47 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 15, 2019 7:09 PM
 * @Description: Modify Here, Please 
 */
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
            var trialBalance = _database.LedgerEntry
                .Where (a => a.Ledger.Date.Year.ToString () == request.Year)
                .Where (a => a.Account.ParentAccountNavigation == null);

            if (request.StartDate != null) {
                trialBalance = trialBalance.Where (t => t.Ledger.Date >= request.StartDate);
            }

            if (request.EndDate != null) {
                trialBalance = trialBalance.Where (t => t.Ledger.Date <= request.EndDate);
            }

            return await trialBalance
                .Select (TrialBalanceModel.Projection)
                .ToListAsync ();
        }
    }
}