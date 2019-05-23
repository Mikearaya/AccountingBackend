/*
 * @CreateTime: May 3, 2019 11:09 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 23, 2019 9:40 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountingBackend.Application.Accounts.Commands.CreateAccount;
using AccountingBackend.Application.Accounts.Commands.DeleteAccount;
using AccountingBackend.Application.Accounts.Commands.UpdateAccount;
using AccountingBackend.Application.Accounts.Models;
using AccountingBackend.Application.Accounts.Queries.GetAccount;
using AccountingBackend.Application.Accounts.Queries.GetAccountsList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AccountingBackend.Api.Controllers.Accounts {

    /// <summary>
    /// Handlers the creation, update delete and view requests related with account
    /// </summary>
    [Route ("api/accounts")]
    public class AccountsController : Controller {
        private readonly IMediator _Mediator;

        /// <summary>
        /// Creates new instance of account controller and injects mediator
        /// </summary>
        /// <param name="mediator"></param>
        public AccountsController (IMediator mediator) {
            _Mediator = mediator;
        }

        /// <summary>
        /// gets a single instance of account requested by id in its parameter or returns
        /// not found exception on the event the account does not exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns>AccountViewModel</returns>
        [HttpGet ("{id}")]
        public async Task<ActionResult<AccountViewModel>> FindAccountById (int id) {

            var result = await _Mediator.Send (new GetAccountQuery () { Id = id });
            return StatusCode (200, result);
        }

        /// <summary>
        /// returns array of account view model 
        /// </summary>
        /// <returns >AccountViewModel</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountViewModel>>> GetAccountsList ([FromQuery] GetAccountsListQuery query) {

            var result = await _Mediator.Send (query);
            return StatusCode (200, result);
        }

        /// <summary>
        /// Create a single account instance and returns account view model object on successful completion
        /// </summary>
        /// <param name="model"></param>
        /// <returns>AccountViewModel</returns>
        [HttpPost]
        public async Task<ActionResult<AccountViewModel>> CreateAccount ([FromBody] CreateAccountCommand model) {

            var result = await _Mediator.Send (model);

            var newAccount = await _Mediator.Send (new GetAccountQuery () { Id = result });
            return StatusCode (201, newAccount);
        }

        /// <summary>
        /// Updates single instance of account based on the id provided through its parameter or
        /// throws not found exception on the case the account with that id is not found
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut ("{id}")]
        public async Task<ActionResult> UpdateAccount (int id, [FromBody] UpdateAccountCommand model) {

            await _Mediator.Send (model);
            return NoContent ();
        }

        /// <summary>
        /// Deletes a single instance of account based on the id passed on its parameter ot
        /// throws not found exception in the case the account is not found
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete ("{id}")]
        public async Task<ActionResult> DeleteAccount (int id) {

            await _Mediator.Send (new DeleteAccountCommand () { Id = id });
            return NoContent ();
        }

        /// <summary>
        /// returns name and id of  top 10 accounts in the system based on given search criteria
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet ("index")]
        public async Task<ActionResult<IEnumerable<AccountIndexView>>> GetAccountIndex ([FromQuery] GetAccountIndexListQuery query) {

            var index = await _Mediator.Send (query);
            return Ok (index);
        }

        [HttpPost ("create-new-year")]
        public async Task<ActionResult> CreateNewFiscalYear () {
            var result = await _Mediator.Send (new CreateNewYearCommand ());
            return StatusCode (201);
        }

    }
}