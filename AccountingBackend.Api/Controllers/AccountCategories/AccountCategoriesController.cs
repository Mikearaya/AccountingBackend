/*
 * @CreateTime: Apr 30, 2019 3:47 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 30, 2019 3:56 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountingBackend.Application.AccountCategories.Commands.CreateAccountCategory;
using AccountingBackend.Application.AccountCategories.Models;
using AccountingBackend.Application.AccountCategories.Queries.GetAccountCategory;
using AccountingBackend.Application.AccountCategories.Queries.GetAccountCategoryList;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.API.Commons;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AccountingBackend.Api.Controllers.AccountCategories {

    /// <summary>
    /// exposes api functions that will allow the reading adding, editing and deleteing of account categories
    /// </summary>

    [Route ("api/account-categories")]
    public class AccountCategoriesController : Controller {
        private readonly IMediator _Mediator;

        /// <summary>
        /// used to initialize account category controller at the time of creation
        /// </summary>
        public AccountCategoriesController (IMediator mediator) {
            _Mediator = mediator;
        }

        /// <summary>
        /// gets single account category from  database based on the id provided in the url
        /// or returns not found status code in the event the category doesnt exist
        /// </summary>
        /// <param name="id"></param>
        /// <returns>AccountCategoryView</returns>
        [HttpGet ("{id}")]
        public async Task<ActionResult<AccountCategoryView>> FindAccountCategoryById (int id) {

            try {
                var result = await _Mediator.Send (new GetAccountCategoryQuery () { Id = id });
                return Ok (result);
            } catch (NotFoundException e) {
                return NotFound (e.Message);
            }

        }

        /// <summary>
        /// gets list of account categories list based on the filter criterias provided by query string
        /// </summary>
        /// <returns>AccountCategoryView</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountCategoryView>>> GetAccountCategoryList () {

            var result = await _Mediator.Send (new GetAccountCategoryListQuery ());
            return Ok (result);

        }

        /// <summary>
        /// creates new account category passed through its parameter
        /// </summary>
        /// <param name="model"></param>
        /// <returns>AccountCategoryView</returns>
        [HttpPost]
        public async Task<ActionResult<AccountCategoryView>> CreateAccountCategory ([FromBody] CreateAccountCategoryCommand model) {

            try {
                var result = await _Mediator.Send (model);

                if (result != 0) {
                    var newCategory = await _Mediator.Send (new GetAccountCategoryQuery () { Id = result });
                    return StatusCode (201, newCategory);
                }

                return new InvalidInputResponse (ModelState);

            } catch (NotFoundException e) {
                return NotFound (e.Message);
            }

        }

    }
}