using System;
using System.IO;

namespace PathCleaner
{
    class DuplicatePathChecker : IPathChecker
    {
        public string Reason => "Duplicate";

        public bool Identify(string folder, string previousFolder)
        {
            if (previousFolder == null)
            {
                return false;
            }

            return string.Compare(trimTrailingPathSeparators(folder), 
                       trimTrailingPathSeparators(previousFolder), StringComparison.OrdinalIgnoreCase) == 0;
        }

        private static string trimTrailingPathSeparators(string path)
        {
            return path.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
        }
    }
}
