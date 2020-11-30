using System.Threading.Tasks;

namespace Blauhaus.Common.Utils.Contracts
{
    public interface IAsyncReloadable
    {
        Task ReloadAsync();
    }
}