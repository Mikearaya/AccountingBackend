/*
 * @CreateTime: May 6, 2019 11:29 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 6, 2019 11:31 AM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Application.SystemLookups.Models;
using MediatR;

namespace AccountingBackend.Application.SystemLookups.Queries.GetSystemLookup {
    public class GetSystemLookupQuery
        : IRequest<SystemLookupViewModel> {
            public int Id { get; set; }
        }
}