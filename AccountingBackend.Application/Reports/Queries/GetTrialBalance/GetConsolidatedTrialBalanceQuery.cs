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
using AccountingBackend.Application.Reports.Models;
using MediatR;

namespace AccountingBackend.Application.Reports.Queries.GetTrialBalance {
    public class GetConsolidatedTrialBalanceQuery : IRequest<IEnumerable<TrialBalanceModel>> {
        public string Year { get; set; } = DateTime.Now.ToString ();
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}