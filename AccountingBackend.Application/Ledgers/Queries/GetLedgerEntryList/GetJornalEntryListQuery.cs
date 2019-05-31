/*
 * @CreateTime: May 8, 2019 5:16 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 8, 2019 5:16 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using AccountingBackend.Application.Ledgers.Models;
using AccountingBackend.Application.Models;
using AccountingBackend.Commons.QueryHelpers;
using MediatR;

namespace AccountingBackend.Application.Ledgers.Queries.GetLedgerEntryList {
    public class GetJornalEntryListQuery : ApiQueryString, IRequest<FilterResultModel<JornalEntryListView>> {

    }
}