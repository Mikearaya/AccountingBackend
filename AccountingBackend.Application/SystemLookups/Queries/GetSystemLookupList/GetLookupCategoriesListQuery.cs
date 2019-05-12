/*
 * @CreateTime: May 12, 2019 2:24 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 12, 2019 2:29 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using AccountingBackend.Application.SystemLookups.Models;
using MediatR;

namespace AccountingBackend.Application.SystemLookups.Queries.GetSystemLookupList {
    public class GetLookupCategoriesListQuery : IRequest<IEnumerable<SystemLookupCategoryIndexView>> {

    }
}