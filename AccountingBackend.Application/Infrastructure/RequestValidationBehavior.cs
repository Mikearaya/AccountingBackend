/*
 * @CreateTime: Apr 24, 2019 5:06 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 24, 2019 5:06 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using ValidationException = Northwind.Application.Exceptions.ValidationException;

namespace AccountingBackend.Application.Infrastructure {
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse> {
            private readonly IEnumerable<IValidator<TRequest>> _validators;

            public RequestValidationBehavior (IEnumerable<IValidator<TRequest>> validators) {
                _validators = validators;
            }

            public Task<TResponse> Handle (TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next) {
                var context = new ValidationContext (request);

                var failures = _validators
                    .Select (v => v.Validate (context))
                    .SelectMany (result => result.Errors)
                    .Where (f => f != null)
                    .ToList ();

                if (failures.Count != 0) {
                    throw new ValidationException (failures);
                }

                return next ();
            }
        }
}