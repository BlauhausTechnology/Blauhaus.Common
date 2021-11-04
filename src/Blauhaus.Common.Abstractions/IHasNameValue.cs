namespace Blauhaus.Common.Abstractions
{
    public interface IHasNameValue<out TValue> : IHasName 
    {
        TValue Value { get; }
    }
}