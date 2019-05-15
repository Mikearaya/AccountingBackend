using System;
/*
 * @CreateTime: May 15, 2019 8:32 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 15, 2019 8:32 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using AccountingBackend.Application.Reports.Models;
using AccountingBackend.Commons.QueryHelpers;
using MediatR;

namespace AccountingBackend.Application.Reports.Queries {
    public class GetLedgerCheckListQuery : ApiQueryString, IRequest<IEnumerable<LedgerChecklistModel>> {
        public string Year { get; set; } = DateTime.Now.Year.ToString ();
        public string FromVoucherId { get; set; } = "";
        public string ToVoucherId { get; set; } = "";
        public DateTime? StartDate { get; set; }
        public DateTime EndDate { get; set; } = DateTime.Now;

    }
}