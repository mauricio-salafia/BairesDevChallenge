using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Portfolio.Application.Common.Excecptions
{
    /// <summary>
    /// Custom ValiationException
    /// </summary>
    public class ValidationException : Exception
    {
        /// <summary>
        /// Dictionary with Errors by property
        /// </summary>
        public Dictionary<string, string[]> Errors { get; set; }

        /// <summary>
        /// Constructor
        /// Initialize the dictionary to avoid potential Null Reference Exception
        /// </summary>
        public ValidationException()
            : base("One more errors ocurred during the validation.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        /// <summary>
        /// Constructor
        /// Add to the dictionary the errors detected in the validation
        /// </summary>
        /// <param name="failures"></param>
        public ValidationException(List<ValidationFailure> failures)
            : this()
        {
            Errors = failures.GroupBy(x => x.PropertyName)
                .Select(x => new KeyValuePair<string, string[]>(x.Key, x.Select(y => y.ErrorMessage).ToArray()))
                .ToDictionary(x => x.Key, y => y.Value);
        }
    }
}
