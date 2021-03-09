namespace Blauhaus.Common.Abstractions
{
    public interface IInitializable
    {
        void Initialize();
    }

    public interface IInitializable<in T>
    {
        void Initialize(T initialValue);
    }
}