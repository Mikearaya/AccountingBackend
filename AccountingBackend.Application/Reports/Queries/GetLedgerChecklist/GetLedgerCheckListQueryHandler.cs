/*
 * @CreateTime: May 15, 2019 8:32 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 22, 2019 4:45 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Application.Reports.Models;
using AccountingBackend.Application.Reports.Queries.GetLedgerChecklist;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AccountingBackend.Application.Reports.Queries {
    public class GetLedgerCheckListQueryHandler : IRequestHandler<GetLedgerCheckListQuery, LedgerChecklistView> {
        private readonly IAccountingDatabaseService _database;

        public GetLedgerCheckListQueryHandler (IAccountingDatabaseService database) {
            _database = database;

        }

        public async Task<LedgerChecklistView> Handle (GetLedgerCheckListQuery request, CancellationToken cancellationToken) {

            LedgerChecklistView view = new LedgerChecklistView ();
            var list = _database.Ledger
                .Where (x => x.Date.Year.ToString () == request.Year);

            if (request.FromVoucherId.Trim () != "") {
                list = list.Where (l => l.VoucherId.CompareTo (request.FromVoucherId) > 0 || l.VoucherId.CompareTo (request.FromVoucherId) == 0);
            }

            if (request.ToVoucherId.Trim () != "") {
                list = list.Where (l => l.VoucherId.CompareTo (request.ToVoucherId) < 0 || l.VoucherId.CompareTo (request.ToVoucherId) == 0);
            }

            if (request.StartDate != null) {

                list = list.Where (a => a.LedgerEntry
                    .Any (e => e.Ledger.Date > request.StartDate && e.Ledger.Date < request.EndDate));
            }
            view.Count = list.Count ();
            view.Items = await list
                .Select (LedgerChecklistModel.Projection)

                .Skip (request.PageNumber)
                .Take (request.PageSize)
                .ToListAsync ();

            return view;
        }

    }
}