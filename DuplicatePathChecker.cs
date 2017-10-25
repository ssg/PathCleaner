using System;

namespace PathCleaner
{
    class DuplicatePathChecker : IPathChecker
    {
        public string Reason => "Duplicate";

        public bool Identify(string folder, string previousFolder)
        {
            return previousFolder != null 
                && String.Compare(folder, previousFolder, StringComparison.OrdinalIgnoreCase) == 0;
        }
    }
}
