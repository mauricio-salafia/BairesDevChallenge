using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Portfolio.Application.Common.Models
{
    [ExcludeFromCodeCoverage]
    /// <summary>
    /// Wrapper class to encapsulate any operation
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Succeeded property
        /// </summary>
        public bool Succeeded { get; set; }
        /// <summary>
        /// Errors property
        /// </summary>
        public List<string> Errors { get; set; }

        /// <summary>
        /// Internal Constructor
        /// The class can be created by CreateSuccess or CreateFailure
        /// </summary>
        /// <param name="succeeded">Status of succeeded</param>
        /// <param name="errors">List of errors</param>
        internal Result(bool succeeded, List<string> errors)
        {
            Succeeded = succeeded;
            Errors = errors;
        }

        /// <summary>
        /// Create a succeded Result object
        /// No errors
        /// </summary>
        /// <returns>A Result with success</returns>
        public static Result CreateSuccess()
        {
            return new Result(true, new List<string>());
        }

        /// <summary>
        /// Create a failure Result object
        /// </summary>
        /// <param name="errors">List of errors</param>
        /// <returns>A Result with the errors</returns>
        public static Result CreateFailure(IEnumerable<string> errors)
        {
            return new Result(false, errors.ToList());
        }
    }
}
