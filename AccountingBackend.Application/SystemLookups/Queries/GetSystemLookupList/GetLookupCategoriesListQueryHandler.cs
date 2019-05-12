/*
 * @CreateTime: May 12, 2019 2:26 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 12, 2019 2:59 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Application.SystemLookups.Models;
using AccountingBackend.Commons.QueryHelpers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AccountingBackend.Application.SystemLookups.Queries.GetSystemLookupList {
    public class GetSystemLookupCategoriesListQueryHandler : ApiQueryString, IRequestHandler<GetSystemLookupCategoriesListQuery, IEnumerable<SystemLookupCategoryIndexView>> {
        private readonly IAccountingDatabaseService _database;

        public GetSystemLookupCategoriesListQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<SystemLookupCategoryIndexView>> Handle (GetSystemLookupCategoriesListQuery request, CancellationToken cancellationToken) {
            return await _database.SystemLookup
                .Where (l => l.Type.ToLower () == "lookup_category")
                .Select (SystemLookupCategoryIndexView.Project)
                .ToListAsync ();
        }
    }
}