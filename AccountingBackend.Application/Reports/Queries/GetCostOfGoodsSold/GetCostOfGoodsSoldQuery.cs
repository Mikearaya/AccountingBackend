/*
 * @CreateTime: Jun 5, 2019 1:31 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 5, 2019 2:27 PM
 * @Description: Modify Here, Please 
 */
using System;
using AccountingBackend.Application.Models;
using AccountingBackend.Application.Reports.Models;
using AccountingBackend.Commons.QueryHelpers;
using MediatR;

namespace AccountingBackend.Application.Reports.Queries.GetCostOfGoodsSold {
    public class GetCostOfGoodsSoldQuery : IRequest<CostofGoodsSoldModel> {

        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public string Year { get; set; }

    }
}