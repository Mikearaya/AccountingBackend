/*
 * @CreateTime: May 15, 2019 9:02 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 15, 2019 6:53 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountingBackend.Application.Reports.Models;
using AccountingBackend.Application.Reports.Queries;
using AccountingBackend.Application.Reports.Queries.GetSubsidaryLedger;
using AccountingBackend.Application.Reports.Queries.GetTrialBalance;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AccountingBackend.Api.Controllers.Reports {

    [Route ("api/reports")]
    public class ReportController : Controller {
        private readonly IMediator _Mediator;

        public ReportController (IMediator mediator) {
            _Mediator = mediator;
        }

        /// <summary>
        /// returns list of ledger entries made by filtering them with 
        /// the criteria provided in the query string
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet ("ledger-checklists")]
        public async Task<ActionResult<IEnumerable<LedgerChecklistModel>>> GetLedgerEntryCheckList ([FromQuery] GetLedgerCheckListQuery query) {
            var result = await _Mediator.Send (query);
            return Ok (result);

        }

        /// <summary>
        /// returns transactions recorded under each account by filtering them with
        /// the criterias provided in the query string
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet ("subsidary-ledgers")]
        public async Task<ActionResult<IEnumerable<SubsidaryLedgerModel>>> GetSubsidaryLedger ([FromQuery] GetSubsidaryLedgerQuery query) {
            var result = await _Mediator.Send (query);
            return Ok (result);
        }

        [HttpGet ("trial-balance/consolidated")]
        public async Task<ActionResult<IEnumerable<TrialBalanceModel>>> GetConsolidatedTrialBalance ([FromQuery] GetConsolidatedTrialBalanceQuery query) {
            var result = await _Mediator.Send (query);
            return Ok (result);
        }

    }
}