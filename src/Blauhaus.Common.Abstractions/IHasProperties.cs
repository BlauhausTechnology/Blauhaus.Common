using System.Collections.Generic;

namespace Blauhaus.Common.Abstractions
{
    public interface IHasProperties
    {
        public Dictionary<string, string> Properties { get; }
    }
}