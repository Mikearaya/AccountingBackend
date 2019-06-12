/*
 * @CreateTime: May 14, 2019 12:47 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 19, 2019 10:13 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountingBackend.Application.AccountTypes.Commands.CreateAccountType;
using AccountingBackend.Application.AccountTypes.Commands.DeleteAccountType;
using AccountingBackend.Application.AccountTypes.Commands.UpdateAccountType;
using AccountingBackend.Application.AccountTypes.Models;
using AccountingBackend.Application.AccountTypes.Queries.GetAccountType;
using AccountingBackend.Application.AccountTypes.Queries.GetAccountTypeList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AccountingBackend.Api.Controllers.AccountTypes {

    /// <summary>
    /// Handles account type related CRUD Operations
    /// </summary>
    [Route ("api/account-types")]
    public class AccountTypesController : Controller {
        private readonly IMediator _Mediator;

        /// <summary>
        /// initializes account type object by injecting mediator instance
        /// </summary>
        /// <param name="mediator"></param>
        public AccountTypesController (IMediator mediator) {
            _Mediator = mediator;
        }

        /// <summary>
        /// returns list of account types by filtering them using the parameters provided in the query string
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost ("filter")]
        public async Task<ActionResult<IEnumerable<AccountTypeView>>> GetAccountTypesList ([FromBody] GetAccountTypeListQuery query) {
            var accountType = await _Mediator.Send (query);
            return Ok (accountType);
        }

        /// <summary>
        /// returns a single instance of account type based on the id provided in the url
        /// or return not found status code if the account type doesnt exist
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet ("{id}")]
        public async Task<ActionResult<AccountTypeView>> FindAccountTypeById (uint id) {
            var accountTypeList = await _Mediator.Send (new GetAccountTypeQuery () { Id = id });
            return Ok (accountTypeList);
        }

        /// <summary>
        /// returns all account types for use as indexing or returns type of account type if the type is given in the query string
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>

        [HttpGet ("index")]
        public async Task<ActionResult<IEnumerable<AccountTypeIndexView>>> GetAccountTypeIndexList ([FromQuery] GetAccountTypeIndexQuery query) {
            var accountTypeIndex = await _Mediator.Send (query);
            return Ok (accountTypeIndex);
        }

        /// <summary>
        /// creates new account type and return the newly created account type appending the id generated
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<AccountTypeView>> CreateAccountType ([FromBody] CreateAccountTypeCommand command) {
            var newAccountTypeId = await _Mediator.Send (command);
            var newAccountType = await _Mediator.Send (new GetAccountTypeQuery () { Id = newAccountTypeId });

            return StatusCode (201, newAccountType);
        }
        /// <summary>
        /// updates single instance of account type based on the id provided in the url  and body of the request
        /// or return 404 status code in the case the account type could not be found
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut ("{id}")]
        public async Task<ActionResult> UpdateAccountType (uint id, [FromBody] UpdateAccountTypeCommand command) {

            await _Mediator.Send (command);
            return NoContent ();
        }

        /// <summary>
        /// deletes a single instance of account type based on the id provided in the url or
        /// returns 404 status code in the case the account type is not found
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete ("{id}")]
        public async Task<ActionResult> DeleteAccountType (uint id) {
            await _Mediator.Send (new DeleteAccountTypeCommand () { Id = id });
            return NoContent ();
        }

    }
}