/*
 * @CreateTime: Jun 4, 2019 1:24 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 4, 2019 2:10 PM
 * @Description: Modify Here, Please 
 */
using System;
using AccountingBackend.Application.Models;
using AccountingBackend.Application.Reports.Models;
using AccountingBackend.Commons;
using AccountingBackend.Commons.QueryHelpers;
using MediatR;

namespace AccountingBackend.Application.Reports.Queries {
    public class GetAccountScheduleQuery : ApiQueryString, IRequest<FilterResultModel<AccountScheduleModel>> {
        private CustomDateConverter dateConverter;
        public GetAccountScheduleQuery () {
            dateConverter = new CustomDateConverter ();
        }

        public string ControlAccountId { get; set; }

        public string StartDate { get; set; }
        public string EndDate { get; set; }

    }
}