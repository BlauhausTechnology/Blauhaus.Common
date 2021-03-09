using System.Threading.Tasks;

namespace Blauhaus.Common.Abstractions
{
    public interface IAsyncInitializable
    {
        Task InitializeAsync();
    }

    public interface IAsyncInitializable<in T>
    {
        Task InitializeAsync(T value);
    }
}