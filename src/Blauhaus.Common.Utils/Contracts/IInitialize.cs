using System.Threading.Tasks;

namespace Blauhaus.Common.Utils.Contracts
{
    public interface IInitialize
    {
        Task InitializeAsync();
    }

    public interface IInitialize<in T>
    {
        Task InitializeAsync(T value);
    }
}