using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathCleaner
{
    enum PathProblemType
    {
        MissingFolder,
        Empty,
        Duplicate,
        NoExecutables,
    }

    class PathProblem
    {
        public string Path;
        public PathProblemType Type;

        public PathProblem(string path, PathProblemType problems)
        {
            this.Path = path;
            this.Type = problems;
        }

        private Dictionary<PathProblemType, string> flagMap = new Dictionary<PathProblemType, string>()
        {
            { PathProblemType.MissingFolder, "Missing" },
            { PathProblemType.Empty, "Empty" },
            { PathProblemType.NoExecutables, "No executables" }, 
            { PathProblemType.Duplicate, "Duplicate" },
        };

        public string Reason
        {
            get
            {
                return flagMap[Type];
            }
        }
    }

}
