using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PathCleaner
{
    class NoExecutablesPathChecker : IPathChecker
    {
        private static HashSet<string> executableExtensions = new HashSet<string>() 
        { 
            ".exe", ".com", ".bat", ".cmd", ".ps1", ".dll"
        };

        public string Reason
        {
            get { return "No executables"; }
        }

        public bool Identify(string folder, string previousFolder)
        {
            return !Directory.EnumerateFiles(folder)
                .Where(s => executableExtensions.Contains(Path.GetExtension(s)))
                .Any();
        }
    }

}
