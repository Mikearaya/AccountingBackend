/*
 * @CreateTime: Apr 24, 2019 5:32 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 24, 2019 5:32 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Northwind.Application.Infrastructure {
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest> {
        private readonly ILogger _logger;

        public RequestLogger (ILogger<TRequest> logger) {
            _logger = logger;
        }

        public Task Process (TRequest request, CancellationToken cancellationToken) {
            var name = typeof (TRequest).Name;

            _logger.LogInformation ("Smart accounting Request: {Name} {@Request}", name, request);

            return Task.CompletedTask;
        }
    }
}