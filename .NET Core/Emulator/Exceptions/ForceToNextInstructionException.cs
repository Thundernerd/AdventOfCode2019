using System;
using System.Runtime.Serialization;

namespace TNRD.AdventOfCode.Emulation
{
    [Serializable]
    public class ForceToNextInstructionException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public ForceToNextInstructionException()
        {
        }

        public ForceToNextInstructionException(string message) : base(message)
        {
        }

        public ForceToNextInstructionException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ForceToNextInstructionException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
