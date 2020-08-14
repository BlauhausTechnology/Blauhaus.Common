using System;
using Blauhaus.Common.Utils.Attributes;

[assembly:Preserve]

namespace Blauhaus.Common.Utils.Attributes
{
   
    [AttributeUsage(AttributeTargets.All)]
    public class PreserveAttribute : Attribute 
    {
        public PreserveAttribute () {}
        public bool Conditional { get; set; }


    }
}