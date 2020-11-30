using System.Threading.Tasks;

namespace Blauhaus.Common.Utils.Contracts
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