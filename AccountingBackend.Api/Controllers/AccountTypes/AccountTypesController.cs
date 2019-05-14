/*
 * @CreateTime: May 14, 2019 12:47 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 12:55 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Threading.Tasks;
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountTypeView>>> GetAccountTypesList ([FromQuery] GetAccountTypeListQuery query) {
            var accountType = _Mediator.Send (query);
            return Ok (accountType);
        }

        /// <summary>
        /// returns a single instance of account type based on the id provided in the url
        /// or return not found status code if the account type doesnt exist
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet ("{id}")]
        public async Task<ActionResult<AccountTypeView>> FindAccountTypeById ([FromQuery] GetAccountTypeQuery query) {
            var accountTypeList = await _Mediator.Send (query);
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
    }
}