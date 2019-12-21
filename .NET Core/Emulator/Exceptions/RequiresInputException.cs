using System;
using System.Runtime.Serialization;

namespace TNRD.AdventOfCode.Emulation
{
    [Serializable]
    public class RequiresInputException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public RequiresInputException()
        {
        }

        public RequiresInputException(string message) : base(message)
        {
        }

        public RequiresInputException(string message, Exception inner) : base(message, inner)
        {
        }

        protected RequiresInputException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
