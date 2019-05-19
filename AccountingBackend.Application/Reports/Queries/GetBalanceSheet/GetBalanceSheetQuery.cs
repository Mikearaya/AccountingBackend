/*
 * @CreateTime: May 19, 2019 8:53 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 19, 2019 8:53 AM
 * @Description: Modify Here, Please 
 */
using System;
using AccountingBackend.Application.Reports.Models;
using MediatR;

namespace AccountingBackend.Application.Reports.Queries.GetBalanceSheet {
    public class GetBalanceSheetQuery : IRequest<BalanceSheetViewModel> {
        public string Year { get; set; } = "";
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}