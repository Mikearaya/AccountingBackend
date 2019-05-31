using System;
/*
 * @CreateTime: May 15, 2019 8:32 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 20, 2019 5:50 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using AccountingBackend.Application.Models;
using AccountingBackend.Application.Reports.Models;
using AccountingBackend.Commons.QueryHelpers;
using MediatR;

namespace AccountingBackend.Application.Reports.Queries {
    public class GetLedgerCheckListQuery : ApiQueryString, IRequest<FilterResultModel<LedgerChecklistModel>> {

        public string FromVoucherId { get; set; } = "";
        public string ToVoucherId { get; set; } = "";
        public DateTime? StartDate { get; set; }
        public DateTime EndDate { get; set; } = DateTime.Now;

    }
}