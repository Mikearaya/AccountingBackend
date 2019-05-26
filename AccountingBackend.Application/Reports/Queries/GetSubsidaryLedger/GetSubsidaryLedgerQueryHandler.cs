/*
 * @CreateTime: May 15, 2019 10:16 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 15, 2019 10:19 AM
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

namespace AccountingBackend.Application.Reports.Queries.GetSubsidaryLedger {
    public class GetSubsidaryLedgerQueryHandler : IRequestHandler<GetSubsidaryLedgerQuery, IEnumerable<SubsidaryLedgerModel>> {
        private readonly IAccountingDatabaseService _database;

        public GetSubsidaryLedgerQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<SubsidaryLedgerModel>> Handle (GetSubsidaryLedgerQuery request, CancellationToken cancellationToken) {
            var list = _database.Account
                .Where (x => x.ParentAccountNavigation != null)
                .Where (x => x.Year == request.Year && x.LedgerEntry.Count > 0);

            if (request.ControlAccountId.Trim () != "") {
                list = list.Where (l => l.ParentAccountNavigation.AccountId == request.ControlAccountId);
            }

            if (request.SubsidaryId.Trim () != "") {
                list = list.Where (l => l.AccountId == request.SubsidaryId);
            }
            if (request.StartDate != null) {

                list = list.Where (a => a.LedgerEntry
                    .Any (e => e.Ledger.Date <= request.EndDate));
            }

            if (request.EndDate != null) {

                list = list.Where (a => a.LedgerEntry
                    .Any (e => e.Ledger.Date <= request.EndDate));
            }

            var filteredList = await list
                .Select (SubsidaryLedgerModel.Projection)
                .Skip (request.PageNumber)
                .Take (request.PageSize)
                .ToListAsync ();

            List<SubsidaryLedgerModel> adjusted = new List<SubsidaryLedgerModel> ();

            foreach (var item in filteredList) {
                var balance = item.BBF;
                SubsidaryLedgerModel mod = new SubsidaryLedgerModel () {
                    AccountId = item.getAccountId (),
                    Id = item.Id,
                    AccountName = item.AccountName,
                    AccountType = item.AccountType,
                    BBF = balance

                };
                foreach (var entry in item.Entries) {
                    balance = balance + (entry.Debit - entry.Credit);
                    entry.Balance = balance;
                    mod.Entries.Add (entry);
                }
                adjusted.Add (mod);
            }

            return adjusted;
        }
    }
}