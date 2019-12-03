using System;
using System.Runtime.Serialization;
using RestSharp;

namespace TNRD.AdventOfCode.Foundation
{
    public class PuzzleInputDownloader
    {
        private const string INPUT_URL = "https://adventofcode.com/2019/day/{0}/input";

        public static string DownloadInput(int day, string sessionCookie)
        {
            string formattedUrl = string.Format(INPUT_URL, day);

            RestClient client = new RestClient(formattedUrl);
            IRestRequest request = new RestRequest(Method.GET);
            request.AddCookie("session", sessionCookie);
            IRestResponse response = client.Execute(request);

            if (!response.IsSuccessful)
                throw new DownloadInputException(day);

            return response.Content;
        }

        [Serializable]
        public class DownloadInputException : Exception
        {
            //
            // For guidelines regarding the creation of new exception types, see
            //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
            // and
            //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
            //

            public DownloadInputException(int day)
                : this($"Unable to download the input for puzzle {day}")
            {
            }

            private DownloadInputException(string message) : base(message)
            {
            }

            private DownloadInputException(string message, Exception inner) : base(message, inner)
            {
            }

            protected DownloadInputException(
                SerializationInfo info,
                StreamingContext context) : base(info, context)
            {
            }
        }
    }
}
