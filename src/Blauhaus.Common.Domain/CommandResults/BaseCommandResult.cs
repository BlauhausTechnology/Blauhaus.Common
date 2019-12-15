using System.Collections.Generic;
using System.Linq;

namespace Blauhaus.Common.Domain.CommandResults
{
    public abstract class BaseCommandResult<TResult, TPayload> : ICommandResult<TPayload> where TResult : BaseCommandResult<TResult, TPayload>, new()
    {
        public TPayload Payload { get; set; }
        public List<string> UserErrors { get; set; } = new List<string>();

        public static TResult Success(TPayload payload) => new TResult{Payload = payload};
        public static TResult Error(params string[] userErrors) => new TResult{UserErrors = userErrors.ToList()};
    }
}