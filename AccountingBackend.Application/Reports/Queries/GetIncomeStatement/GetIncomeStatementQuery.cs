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
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}