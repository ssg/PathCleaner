using System.IO;
using System.Linq;

namespace PathCleaner
{
    class EmptyPathChecker : IPathChecker
    {
        public string Reason
        {
            get { return "Empty"; }
        }

        public bool Identify(string folder, string previousFolder)
        {
            return !Directory.EnumerateFiles(folder).Any();
        }
    }

}
