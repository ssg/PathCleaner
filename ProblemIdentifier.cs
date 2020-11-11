using System;
using System.Collections.Generic;
using System.Linq;

namespace PathCleaner
{
    class ProblemIdentifier
    {
        public IEnumerable<IPathChecker> Checkers { get; private set; }
        public PathString PathString { get; private set; }

        public ProblemIdentifier(PathString pathString, IEnumerable<IPathChecker> checkers)
        {
            this.PathString = pathString;
            this.Checkers = checkers;
        }

        public IEnumerable<PathProblem> FindProblems()
        {
            var sortedFolders = new List<string>(PathString.Folders.OrderBy(s => s));
            string previousFolder = null;
            foreach (string folder in sortedFolders)
            {
                string expandedFolder = folder;
                if (folder.IndexOf('%') >= 0)
                {
                    expandedFolder = Environment.ExpandEnvironmentVariables(folder);
                }
                var successfulChecker = Checkers.FirstOrDefault(c => c.Identify(expandedFolder, previousFolder));
                if (successfulChecker != null)
                {
                    var problem = new PathProblem
                    {
                        Path = folder,
                        Reason = successfulChecker.Reason,
                    };
                    yield return problem;
                }
                previousFolder = folder;
            }
        }
    }
}
