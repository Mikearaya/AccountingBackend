/*
 * @CreateTime: Apr 25, 2019 9:35 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 25, 2019 9:35 AM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Api.Configurations;
using AccountingBackend.Api.Models;
using AccountingBackend.Domain.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AccountingBackend.Api.Controllers.Security {
    public class SecurityController : Controller {
        private readonly JwtSettings _settings;

        public SecurityController (JwtSettings settings) {
            _settings = settings;
        }

        [HttpPost ("login")]
        public IActionResult LogIn ([FromBody] ApplicationUser user) {
            IActionResult ret = null;

            AppUserAuth auth = new AppUserAuth ();
            SecurityManager mgr = new SecurityManager (_settings);

            return StatusCode (200);

        }
    }
}