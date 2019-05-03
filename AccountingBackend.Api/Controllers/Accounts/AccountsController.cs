/*
 * @CreateTime: May 3, 2019 11:09 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 3, 2019 11:23 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountingBackend.Application.Accounts.Commands.CreateAccount;
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
        public async Task<ActionResult<IEnumerable<AccountViewModel>>> GetAccountsList () {

            var result = await _Mediator.Send (new GetAccountsListQuery ());
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

    }
}