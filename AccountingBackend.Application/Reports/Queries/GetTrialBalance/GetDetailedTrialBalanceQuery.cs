/*
 * @CreateTime: May 15, 2019 7:32 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 15, 2019 7:32 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using AccountingBackend.Application.Models;
using AccountingBackend.Application.Reports.Models;
using AccountingBackend.Commons.QueryHelpers;
using MediatR;

namespace AccountingBackend.Application.Reports.Queries.GetTrialBalance {
    public class GetDetailedTrialBalanceQuery : ApiQueryString, IRequest<FilterResultModel<TrialBalanceDetailModel>> {
        public string Year { get; set; } = DateTime.Now.ToString ();
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}