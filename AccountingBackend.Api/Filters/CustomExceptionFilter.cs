/*
 * @CreateTime: Apr 24, 2019 6:36 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 24, 2019 6:36 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Northwind.Application.Exceptions;

namespace AccountingBackend.Api.Filters {
    [AttributeUsage (AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute {
        public override void OnException (ExceptionContext context) {
            if (context.Exception is ValidationException) {
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                context.Result = new JsonResult (
                    ((ValidationException) context.Exception).Failures);

                return;
            }

            var code = HttpStatusCode.InternalServerError;

            if (context.Exception is NotFoundException) {
                code = HttpStatusCode.NotFound;
            }

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int) code;
            context.Result = new JsonResult (new {
                error = new [] { context.Exception.Message },
                    stackTrace = context.Exception.StackTrace
            });
        }
    }
}