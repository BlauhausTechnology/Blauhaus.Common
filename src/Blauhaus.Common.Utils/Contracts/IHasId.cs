namespace Blauhaus.Common.Utils.Contracts
{
    public interface IHasId<out TId>
    {
        TId Id { get; }
    }
}