/*
 * @CreateTime: May 6, 2019 11:38 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 6, 2019 11:44 AM
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
using Microsoft.EntityFrameworkCore;

namespace AccountingBackend.Application.SystemLookups.Queries.GetSystemLookupList {
    public class GetSystemLookupListQueryHandler : ApiQueryString, IRequestHandler<GetSystemLookupListQuery, IEnumerable<SystemLookupViewModel>> {
        private readonly IAccountingDatabaseService _database;

        public GetSystemLookupListQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public Task<IEnumerable<SystemLookupViewModel>> Handle (GetSystemLookupListQuery request, CancellationToken cancellationToken) {
            var lookup = _database.SystemLookup
                .Select (SystemLookupViewModel.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<SystemLookupViewModel> (request.SelectedColumns))
                .Skip (request.PageNumber * request.PageSize)
                .Take (request.PageSize)
                .ToList ();

            return Task.FromResult<IEnumerable<SystemLookupViewModel>> (lookup);
        }
    }
}