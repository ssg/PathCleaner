using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PathCleaner
{
    internal class NoExecutablesPathChecker : IPathChecker
    {
        private static readonly HashSet<string> executableExtensions = new HashSet<string>(System.StringComparer.OrdinalIgnoreCase)
        {
            ".exe", ".com", ".bat", ".cmd", ".ps1", ".dll"
        };

        public NoExecutablesPathChecker()
        {
            // TODO: Make the class compatible with executable file extensions defined in the PATHEXT to prevent EmptyPathChecker from producing false positives.
        }

        public string Reason => "No executables";

        public bool Identify(string folder, string previousFolder)
        {
            return !Directory.EnumerateFiles(folder)
                .Any(s => executableExtensions.Contains(Path.GetExtension(s)));
        }
    }
}