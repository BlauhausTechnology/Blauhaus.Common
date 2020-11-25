namespace Blauhaus.Common.Utils.Contracts
{
    public interface IId<out TId>
    {
        TId Id { get; }
    }
}