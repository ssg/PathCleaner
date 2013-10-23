using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathCleaner
{
    [Flags]
    enum PathProblemTypes
    {
        None = 0,
        MissingFolder = 1,
        Empty = 2,
        Duplicate = 4,
        NoExecutables = 8,
    }

    class PathProblem
    {
        public string Path;
        public PathProblemTypes Problems;

        private Dictionary<PathProblemTypes, string> flagMap = new Dictionary<PathProblemTypes, string>()
        {
            { PathProblemTypes.MissingFolder, "Missing" },
            { PathProblemTypes.Empty, "Empty" },
            { PathProblemTypes.NoExecutables, "No executables" }, 
            { PathProblemTypes.Duplicate, "Duplicate" },
        };

        public string Reason
        {
            get
            {
                var reasons = flagMap.Where(m => Problems.HasFlag(m.Key)).Select(m => m.Value);
                return String.Join(", ", reasons);
            }
        }
    }

}
