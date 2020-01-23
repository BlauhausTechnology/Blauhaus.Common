namespace Blauhaus.Common.Domain.Queries
{
    public abstract class BaseDomainQueryResult<TPayload> : IDomainQueryResult<TPayload>
    {
        public TPayload Payload { get; set; }
    }
}