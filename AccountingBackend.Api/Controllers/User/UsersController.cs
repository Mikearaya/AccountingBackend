/*
 * @CreateTime: Apr 26, 2019 11:17 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 26, 2019 12:34 PM
 * @Description: Modify Here, Please 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Users.Commands.CreateUser;
using AccountingBackend.Application.Users.Commands.DeleteUser;
using AccountingBackend.Application.Users.Commands.UpdateUser;
using AccountingBackend.Application.Users.Models;
using AccountingBackend.Application.Users.Queries.GetUser;
using AccountingBackend.Application.Users.Queries.GetUserList;
using AccountingBackend.API.Commons;
using AccountingBackend.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AccountingBackend.API.Controllers.User {

    /// <summary>
    /// Manages system user data
    /// </summary>

    [ApiController]
    [ApiConventionType (typeof (DefaultApiConventions))]
    [Route ("users")]
    public class UsersController : Controller {
        private readonly IMediator _Mediator;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// constructor for user manager 
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="configuration"></param>
        public UsersController (IMediator mediator,
            IConfiguration configuration) {
            _Mediator = mediator;
            _configuration = configuration;
        }

        /// <summary>
        /// gets a single instance of user data based on  
        /// id value passed in the parameter
        /// </summary>
        /// <param name="id"></param>
        /// <returns>UserViewModel</returns>
        [HttpGet ("{id}")]
        [DisplayName ("View User Detail")]
        [ProducesResponseType (200)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<UserViewModel>> GetUserById (string id) {

            var user = await _Mediator.Send (new GetUserViewByIdQuery () { Id = id });

            return StatusCode (200, user);
        }

        /// <summary>
        /// returns list of userviewmodel instances available in the system 
        /// </summary>
        /// <returns>UserViewModel</returns>
        [HttpGet]
        [DisplayName ("View Users")]
        [ProducesResponseType (200)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetAllUsers () {

            var user = await _Mediator.Send (new GetUsersListViewQuery ());
            return StatusCode (200, user);
        }

        /// <summary>
        /// Creates a new user in the system
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns>UserViewModel</returns>
        [HttpPost]
        [DisplayName ("Create User")]
        [ProducesResponseType (201)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<UserViewModel>> CreateUser ([FromBody] CreateUserCommand newUser) {

            if (newUser == null) {
                return StatusCode (400);
            }

            if (!ModelState.IsValid) {
                return new InvalidInputResponse (ModelState);
            }

            var result = await _Mediator.Send (newUser);

            var user = _Mediator.Send (new GetUserViewByIdQuery () { Id = result });
            return StatusCode (201, user);
        }

        /// <summary>
        /// updates single user data base on the id passed on the parameter
        /// </summary>
        /// <param name="updatedUser"></param>
        /// <param name="id"></param>
        /// <returns>void</returns>
        [HttpPut ("{id}")]
        [DisplayName ("Update User")]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]

        public async Task<ActionResult> UpdateUser (string id, [FromBody] UpdateUserCommand updatedUser) {
            try {

                if (updatedUser == null) {
                    return StatusCode (400);
                }

                if (!ModelState.IsValid) {
                    return new InvalidInputResponse (ModelState);
                }
                var asss = await _Mediator.Send (updatedUser);

                return StatusCode (204);
            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }
        }

        /// <summary>
        /// updates a single user password based on the id passed on the parameter
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedUserPassword"></param>
        /// <returns>void</returns>
        [HttpPut ("{id}/password")]
        [DisplayName ("Change account password")]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public async Task<IActionResult> UpdateUserPassword (string id, [FromBody] UpdateUserPasswordCommand updatedUserPassword) {
            try {

                if (!ModelState.IsValid) {
                    return new InvalidInputResponse (ModelState);
                }

                var asss = await _Mediator.Send (updatedUserPassword);

                return StatusCode (204);
            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            } catch (Exception e) {
                return StatusCode (500, e.Message);
            }
        }

        /// <summary>
        /// deletes single user instance based on the id passed in the url
        /// </summary>
        /// <param name="id"></param>
        /// <returns>void</returns>
        [HttpDelete ("{id}")]
        [DisplayName ("Delete Users")]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<IActionResult> DeleteUser (string id) {

            try {
                var user = await _Mediator.Send (new DeleteUserCommand () { Id = id });
                return StatusCode (204);
            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }
        }
    }
}