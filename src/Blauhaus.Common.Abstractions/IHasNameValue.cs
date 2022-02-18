namespace Blauhaus.Common.Abstractions
{
        
    public interface IHasNameValue : IHasNameValue<string>
    {
    }
    public interface IHasNameValue<out TValue> : IHasName 
    {
        TValue Value { get; }
    }
}