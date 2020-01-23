using System;
using System.Collections.Generic;

namespace Blauhaus.Common.Domain.Commands
{
    public abstract class BaseDomainCommandResult<TResult, TPayload> : IDomainCommandResult<TPayload> where TResult : BaseDomainCommandResult<TResult, TPayload>, new()
    {
        public TPayload Payload { get; set; }
        public List<DomainCommandError> Errors { get; set; } = new List<DomainCommandError>();

        public static TResult Success(TPayload payload) => new TResult{Payload = payload};

        public static TResult Error(params string[] userErrors)
        {
            var errors = new List<DomainCommandError>();
            foreach (var userError in userErrors)
            {
                errors.Add(new DomainCommandError(userError));
            }
            return new TResult{Payload = default, Errors =  errors};
        }

        public static TResult Error(string userError, Exception exception = null)
        {
            return new TResult
            {
                Payload = default, 
                Errors =  new List<DomainCommandError> { new DomainCommandError(userError, exception) }
            };
        }
    }
}