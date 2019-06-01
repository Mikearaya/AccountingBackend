/*
 * @CreateTime: May 15, 2019 9:02 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 25, 2019 5:28 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountingBackend.Application.Models;
using AccountingBackend.Application.Reports.Models;
using AccountingBackend.Application.Reports.Queries;
using AccountingBackend.Application.Reports.Queries.GetBalanceSheet;
using AccountingBackend.Application.Reports.Queries.GetIncomeStatement;
using AccountingBackend.Application.Reports.Queries.GetSubsidaryLedger;
using AccountingBackend.Application.Reports.Queries.GetTrialBalance;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AccountingBackend.Api.Controllers.Reports {

    /// <summary>
    /// generates diffrent type of reports related including
    /// - income statement
    /// - balance sheet
    /// - consolidated trial balance
    /// - detail trial balance
    /// - transactions checklist
    /// - subsidary ledger transaction etc...
    /// </summary>
    [Route ("api/report")]
    public class ReportController : Controller {
        private readonly IMediator _Mediator;

        /// <summary>
        /// initialized the report controller by injecting mediator instance and making it available to use
        /// </summary>
        /// <param name="mediator"></param>
        public ReportController (IMediator mediator) {
            _Mediator = mediator;
        }

        /// <summary>
        /// returns list of ledger entries made by filtering them with 
        /// the criteria provided in the query string
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost ("ledger-checklists")]
        public async Task<ActionResult<FilterResultModel<LedgerChecklistModel>>> GetLedgerEntryCheckList ([FromBody] GetLedgerCheckListQuery query) {
            var result = await _Mediator.Send (query);
            return Ok (result);

        }

        /// <summary>
        /// returns transactions recorded under each account by filtering them with
        /// the criterias provided in the query string
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost ("subsidary-ledgers")]
        public async Task<ActionResult<IEnumerable<SubsidaryLedgerModel>>> GetSubsidaryLedger ([FromBody] GetSubsidaryLedgerQuery query) {
            var result = await _Mediator.Send (query);
            return Ok (result);
        }

        /// <summary>
        /// returns a summerized transaction trial balance by filtering them using parameters provided in the query string
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>

        [HttpPost ("trial-balance/consolidated")]
        public async Task<ActionResult<IEnumerable<TrialBalanceModel>>> GetConsolidatedTrialBalance ([FromBody] GetConsolidatedTrialBalanceQuery query) {
            var result = await _Mediator.Send (query);
            return Ok (result);
        }

        /// <summary>
        /// returns detailed trial balance information by filtering them using the parameters provided in the query string
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost ("trial-balance/detail")]
        public async Task<ActionResult<FilterResultModel<TrialBalanceDetailModel>>> GetDettailedTrialBalance ([FromBody] GetDetailedTrialBalanceQuery query) {
            var result = await _Mediator.Send (query);
            return Ok (result);
        }

        /// <summary>
        /// returns yearly based income statement and filter them using parameters provided in the query string
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet ("income-statement")]
        public async Task<ActionResult<IncomeStatementViewModel>> GetIcomeStatement ([FromQuery] GetIncomeStatementQuery query) {
            var result = await _Mediator.Send (query);
            return Ok (result);
        }

        /// <summary>
        /// returns yearly based balance sheet and filter it using parameters provided ing the query string
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet ("balance-sheet")]
        public async Task<ActionResult<BalanceSheetViewModel>> GetBalanceSheet ([FromQuery] GetBalanceSheetQuery query) {
            var result = await _Mediator.Send (query);
            return Ok (result);
        }

        /// <summary>
        /// returns yearly based balance sheet and filter it using parameters provided ing the query string
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet ("dashboard")]
        public async Task<ActionResult<DashboardViewModel>> GetDashboardSummary ([FromQuery] GetDashboardDataQuery query) {
            var result = await _Mediator.Send (query);
            return Ok (result);
        }

    }
}