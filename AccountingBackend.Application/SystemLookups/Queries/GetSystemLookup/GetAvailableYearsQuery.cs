/*
 * @CreateTime: May 22, 2019 4:58 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 22, 2019 4:58 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using AccountingBackend.Application.Models;
using MediatR;

namespace AccountingBackend.Application.SystemLookups.Queries.GetSystemLookup {
    public class GetAvailableYearsQuery : IRequest<IEnumerable<AvailableYearsModel>> {

    }
}