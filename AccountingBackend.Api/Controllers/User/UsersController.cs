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
    [Route ("users")]
    public class UsersController : Controller {
        private readonly IMediator _Mediator;
        private readonly IConfiguration _configuration;

        public UsersController (IMediator mediator,
            IConfiguration configuration) {
            _Mediator = mediator;
            _configuration = configuration;
        }

        [HttpGet ("{id}")]
        [DisplayName ("View User Detail")]
        [ProducesResponseType (200)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<ApplicationUser>> GetUserById (string id) {

            var user = await _Mediator.Send (new GetUserViewByIdQuery () { Id = id });

            return StatusCode (200, user);
        }

        [HttpGet]
        [DisplayName ("View Users")]
        [ProducesResponseType (200)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<IActionResult> GetAllUsers () {

            var user = await _Mediator.Send (new GetUsersListViewQuery ());
            return StatusCode (200, user);
        }

        [HttpPost]
        [DisplayName ("Create User")]
        [ProducesResponseType (201)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public async Task<IActionResult> CreateUser ([FromBody] CreateUserCommand newUser) {

            if (newUser == null) {
                return StatusCode (400);
            }

            if (!ModelState.IsValid) {
                return new InvalidInputResponse (ModelState);
            }

            var result = await _Mediator.Send (newUser);

            return StatusCode (201, result);
        }

        [HttpPut ("{id}")]
        [DisplayName ("Update User")]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public async Task<IActionResult> UpdateUser ([FromBody] UpdateUserCommand updatedUser) {
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

        [HttpDelete ("{id}")]
        [DisplayName ("Delete Users")]
        [ProducesResponseType (200)]
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