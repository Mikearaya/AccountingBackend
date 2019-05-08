/*
 * @CreateTime: May 8, 2019 5:58 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 8, 2019 6:12 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountingBackend.Application.Ledgers.Models;
using AccountingBackend.Application.Ledgers.Queries.GetLedgerEntry;
using AccountingBackend.Application.Ledgers.Queries.GetLedgerEntryList;
using AccountingBackend.Commons.QueryHelpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AccountingBackend.Api.Controllers.Ledgers {

    [Route ("api/ledger")]
    public class LedgerController : Controller {
        private readonly IMediator _Mediator;

        public LedgerController (IMediator mediator) {
            _Mediator = mediator;
        }

        /// <summary>
        /// returns single ledger entry id specified in the url
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet ("{id}")]
        public async Task<ActionResult<LedgerEntryDetailViewModel>> FindLedgerEntryById (int id) {

            var entry = await _Mediator.Send (new GetLedgerEntryByIdQuery () { Id = id });
            return Ok (entry);
        }

        /// <summary>
        /// returns list of jornal entries
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JornalEntryListView>>> GetLedgerEntryList ([FromQuery] GetJornalEntryListQuery query) {

            var entryList = await _Mediator.Send (query);
            return StatusCode (200, entryList);
        }
    }
}