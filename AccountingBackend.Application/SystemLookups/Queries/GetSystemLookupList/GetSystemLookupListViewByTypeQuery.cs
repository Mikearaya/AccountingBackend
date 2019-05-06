/*
 * @CreateTime: May 6, 2019 11:45 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 6, 2019 11:50 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using AccountingBackend.Application.SystemLookups.Models;
using AccountingBackend.Commons.QueryHelpers;
using MediatR;

namespace AccountingBackend.Application.SystemLookups.Queries.GetSystemLookupList {
    public class GetSystemLookupListViewByTypeQuery : ApiQueryString, IRequest<IEnumerable<SystemLookupViewModel>> {
        public string Type { get; set; }
    }
}