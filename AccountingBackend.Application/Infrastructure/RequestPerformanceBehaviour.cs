/*
 * @CreateTime: Apr 24, 2019 5:06 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 24, 2019 5:06 PM
 * @Description: Modify Here, Please 
 */
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AccountingBackend.Application.Infrastructure {
    public class RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;

        public RequestPerformanceBehaviour (ILogger<TRequest> logger) {
            _timer = new Stopwatch ();

            _logger = logger;
        }

        public async Task<TResponse> Handle (TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next) {
            _timer.Start ();

            var response = await next ();

            _timer.Stop ();

            if (_timer.ElapsedMilliseconds > 500) {
                var name = typeof (TRequest).Name;

                _logger.LogWarning ("Smart accounting Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@Request}", name, _timer.ElapsedMilliseconds, request);
            }

            return response;
        }
    }
}