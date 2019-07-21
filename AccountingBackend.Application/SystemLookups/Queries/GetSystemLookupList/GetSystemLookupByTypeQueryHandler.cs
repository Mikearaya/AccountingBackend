/*
 * @CreateTime: May 6, 2019 11:47 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 10, 2019 3:42 PM
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
    public class GetSystemLookupByTypeQueryHandler : IRequestHandler<GetSystemLookupByTypeQuery, IEnumerable<SystemLookUpIndexModel>> {
        private readonly IAccountingDatabaseService _database;

        public GetSystemLookupByTypeQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public Task<IEnumerable<SystemLookUpIndexModel>> Handle (GetSystemLookupByTypeQuery request, CancellationToken cancellationToken) {
            var lookup = _database.SystemLookup
                .Where (c => c.Value.ToUpper ().Contains (request.SearchString.ToUpper ()));

            if (request.Type != null) {
                lookup = lookup.Where (c => c.Type.ToLower () == request.Type.ToLower ());
            }
            var lookups = lookup.Select (SystemLookUpIndexModel.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<SystemLookUpIndexModel> (request.SelectedColumns))
                .Skip (request.PageNumber * request.PageSize)
                .Take (request.PageSize)
                .ToList ();

            return Task.FromResult<IEnumerable<SystemLookUpIndexModel>> (lookups);
        }
    }
}