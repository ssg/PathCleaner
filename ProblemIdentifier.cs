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

        public IEnumerable<PathProblem> Problems
        {
            get
            {
                var sortedFolders = new List<string>(PathString.Folders.OrderBy(s => s));
                string previousFolder = null;
                foreach(string folder in sortedFolders)
                {
                    string expandedFolder = folder;
                    if (folder.IndexOf('%') >= 0)
                    {
                        expandedFolder = Environment.ExpandEnvironmentVariables(folder);
                    }
                    var problem = Checkers.Where(c => c.Identify(expandedFolder, previousFolder))
                        .Select(c => new PathProblem
                        {
                            Path = folder,
                            Reason = c.Reason,
                        })
                        .FirstOrDefault();
                    if (problem != null)
                    {
                        yield return problem;
                    }
                    previousFolder = folder;
                }
            }
        }
    }
}
