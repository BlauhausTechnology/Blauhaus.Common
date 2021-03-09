using System.Threading.Tasks;

namespace Blauhaus.Common.Abstractions
{
    public interface IAsyncReloadable
    {
        Task ReloadAsync();
    }
}