using System;
using System.Runtime.Serialization;

namespace TNRD.AdventOfCode.DayFive.Shared
{
    [Serializable]
    public class HaltException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public HaltException()
        {
        }

        public HaltException(string message) : base(message)
        {
        }

        public HaltException(string message, Exception inner) : base(message, inner)
        {
        }

        protected HaltException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
