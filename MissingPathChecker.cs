using System.IO;

namespace PathCleaner
{
    class MissingPathChecker : IPathChecker
    {
        public string Reason
        {
            get { return "Missing"; }
        }

        public bool Identify(string folder, string previousFolder)
        {
            return !Directory.Exists(folder);
        }
    }
}