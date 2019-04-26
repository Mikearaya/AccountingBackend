using System.Threading.Tasks;
using AccountingBackend.Application.Models;
using AccountingBackend.API.Commons;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AccountingBackend.Api.Controllers.Security {
    public class AccessController : Controller {
        private readonly IConfiguration _configuration;
        private readonly IMediator _Mediator;

        public AccessController (IMediator mediator,
            IConfiguration configuration) {
            _configuration = configuration;
            _Mediator = mediator;
        }

    }
}