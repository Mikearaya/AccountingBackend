/*
 * @CreateTime: May 17, 2019 6:03 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 17, 2019 6:03 PM
 * @Description: Modify Here, Please 
 */
using System;
using AccountingBackend.Application.Reports.Models;
using MediatR;

namespace AccountingBackend.Application.Reports.Queries.GetIncomeStatement {
    public class GetIncomeStatementQuery : IRequest<IncomeStatementViewModel> {
        public string Year { get; set; } = "2011";
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}