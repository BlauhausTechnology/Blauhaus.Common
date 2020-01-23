namespace Blauhaus.Common.Domain.Queries
{
    public interface IDomainQueryResult<TPayload>
    {
        TPayload Payload { get; set; }
        
    }
}