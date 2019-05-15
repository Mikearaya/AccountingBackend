/*
 * @CreateTime: May 15, 2019 9:02 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 15, 2019 9:02 AM
 * @Description: Modify Here, Please 
 */
using System.Threading.Tasks;
using AccountingBackend.Application.Reports.Models;
using AccountingBackend.Application.Reports.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AccountingBackend.Api.Controllers.Reports {

    [Route ("api/reports")]
    public class ReportController : Controller {
        private readonly IMediator _Mediator;

        public ReportController (IMediator mediator) {
            _Mediator = mediator;
        }

        [HttpGet ("ledger-checklist")]
        public async Task<ActionResult<LedgerChecklistModel>> GetLedgerEntryCheckList ([FromQuery] GetLedgerCheckListQuery query) {
            var result = await _Mediator.Send (query);
            return Ok (result);

        }

    }
}