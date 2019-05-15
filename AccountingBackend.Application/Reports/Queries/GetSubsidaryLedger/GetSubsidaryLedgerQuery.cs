/*
 * @CreateTime: May 15, 2019 10:15 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 15, 2019 10:17 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using AccountingBackend.Application.Reports.Models;
using AccountingBackend.Commons.QueryHelpers;
using MediatR;

namespace AccountingBackend.Application.Reports.Queries.GetSubsidaryLedger {
    public class GetSubsidaryLedgerQuery : ApiQueryString, IRequest<IEnumerable<SubsidaryLedgerModel>> {

    }
}