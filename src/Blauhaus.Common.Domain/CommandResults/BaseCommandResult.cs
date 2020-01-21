using System;
using System.Collections.Generic;
using System.Linq;

namespace Blauhaus.Common.Domain.CommandResults
{
    public abstract class BaseCommandResult<TResult, TPayload> : ICommandResult<TPayload> where TResult : BaseCommandResult<TResult, TPayload>, new()
    {
        public TPayload Payload { get; set; }
        public List<CommandError> UserErrors { get; set; } = new List<CommandError>();

        public static TResult Success(TPayload payload) => new TResult{Payload = payload};

        public static TResult Error(params string[] userErrors)
        {
            var errors = new List<CommandError>();
            foreach (var userError in userErrors)
            {
                errors.Add(new CommandError(userError));
            }
            return new TResult{Payload = default, UserErrors =  errors};
        }

        public static TResult Error(string userError, Exception exception = null)
        {
            return new TResult
            {
                Payload = default, 
                UserErrors =  new List<CommandError> { new CommandError(userError, exception) }
            };
        }
    }
}