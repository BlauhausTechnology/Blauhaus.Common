using System;
using System.Runtime.CompilerServices;
using Blauhaus.Common.ValueObjects._Base;

namespace Blauhaus.Common.ValueObjects.Errors
{
    public class Error : BaseValueObject<Error>
    {
        public Error(string code, string description)
        {
            Code = code;
            Description = description;
        }

        public string Code { get; }
        public string Description { get; }

        public static Error Create(string errorDescription, [CallerMemberName] string errorCode = "")
        {
            return new Error(errorCode, errorDescription);
        }

        public static Error Deserialize(string serializedError)
        {
            var deserialized = serializedError.Split(new []{" ::: "}, StringSplitOptions.None);
            if (deserialized.Length != 2)
            {
                throw new ArgumentException($"Input {serializedError} is not a valid serialized Error");
            }
            return new Error(deserialized[0], deserialized[1]);
        }
        
        public override string ToString()
        {
            return $"{Code} ::: {Description}";
        }


        protected override int GetHashCodeCore()
        {
            unchecked
            {
                return (Code.GetHashCode() * 397) ^ Description.GetHashCode();
            }
        }

        protected override bool EqualsCore(Error other)
        {
            return Code == other.Code && Description == other.Description;
        }

    }
}