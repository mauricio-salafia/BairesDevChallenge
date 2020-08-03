using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Portfolio.Application.Common.Behaviors
{
    /// <summary>
    /// Pipeline with valiation
    /// </summary>
    /// <typeparam name="TRequest">Request</typeparam>
    /// <typeparam name="TResponse">Response</typeparam>
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="validators">Validators to execute</param>
        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        /// <summary>
        /// Handler a request with validation
        /// </summary>
        /// <param name="request">The request to validate</param>
        /// <param name="cancellationToken">CancellationToken to stop the operation </param>
        /// <param name="next">The next action to execute</param>
        /// <returns></returns>
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())
            {
                //var context = new ValidationContext(request);
                var failures = _validators.Select(x => x.Validate(request))
                    .SelectMany(result => result.Errors)
                    .Where(e => e != null).ToList();
                if (failures.Count > 0)
                {
                    throw new ValidationException(failures);
                }
            }

            //MediatR delegates for the next action
            return next();
        }
    }
}
