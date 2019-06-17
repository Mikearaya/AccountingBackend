using System;
/*
 * @CreateTime: May 15, 2019 6:46 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 15, 2019 7:09 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using AccountingBackend.Application.Models;
using AccountingBackend.Application.Reports.Models;
using AccountingBackend.Commons.QueryHelpers;
using MediatR;

namespace AccountingBackend.Application.Reports.Queries.GetTrialBalance {
    public class GetConsolidatedTrialBalanceQuery : ApiQueryString, IRequest<FilterResultModel<TrialBalanceModel>> {

        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}