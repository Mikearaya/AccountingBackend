/*
 * @CreateTime: May 8, 2019 5:58 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 8, 2019 6:23 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountingBackend.Application.Ledgers.Commands.CreateLedgerEntry;
using AccountingBackend.Application.Ledgers.Commands.DeleteLedgerEntry;
using AccountingBackend.Application.Ledgers.Commands.UpdateLedgerEntry;
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
        public async Task<ActionResult<LedgerEntryViewModel>> FindLedgerEntryById (int id) {

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

        /// <summary>
        /// Creates new ledger entry and return the new entry on success
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<LedgerEntryViewModel>> CreateNewLedgerEntry ([FromBody] CreateLedgerEntryCommand model) {

            var result = await _Mediator.Send (model);
            var newEntry = await _Mediator.Send (new GetLedgerEntryByIdQuery () { Id = result });

            return StatusCode (201, newEntry);
        }

        /// <summary>
        /// updated single ledger entry instance and all of it details
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut ("{id}")]
        public async Task<ActionResult> UpdateLedgerEntry (int id, [FromBody] UpdateLedgerEntryCommand model) {
            await _Mediator.Send (model);
            return StatusCode (204);
        }

        /// <summary>
        /// deletes single instance of ledger entry based on the id provided in its url and body
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete ("{id}")]
        public async Task<ActionResult> DeleteLedgerEntry (int id) {
            await _Mediator.Send (new DeleteLedgerEntryCommand () { Id = id });
            return StatusCode (204);
        }
    }
}