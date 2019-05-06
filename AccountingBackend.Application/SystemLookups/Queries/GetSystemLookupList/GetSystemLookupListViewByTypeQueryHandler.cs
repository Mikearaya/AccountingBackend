/*
 * @CreateTime: May 6, 2019 11:47 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 6, 2019 11:51 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Application.SystemLookups.Models;
using AccountingBackend.Commons.QueryHelpers;
using MediatR;

namespace AccountingBackend.Application.SystemLookups.Queries.GetSystemLookupList {
    public class GetSystemLookupListViewByTypeQueryHandler : IRequestHandler<GetSystemLookupListViewByTypeQuery, IEnumerable<SystemLookupViewModel>> {
        private readonly IAccountingDatabaseService _database;

        public GetSystemLookupListViewByTypeQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public Task<IEnumerable<SystemLookupViewModel>> Handle (GetSystemLookupListViewByTypeQuery request, CancellationToken cancellationToken) {
            var lookup = _database.SystemLookup
                .Where (c => c.Type.ToLower () == request.Type.ToLower ())
                .Select (SystemLookupViewModel.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<SystemLookupViewModel> (request.SelectedColumns))
                .Skip (request.PageNumber * request.PageSize)
                .Take (request.PageSize)
                .ToList ();

            return Task.FromResult<IEnumerable<SystemLookupViewModel>> (lookup);
        }
    }
}