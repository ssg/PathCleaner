using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathCleaner
{
    class PathString
    {
        private const string pathKey = "PATH";

        private static HashSet<string> executableExtensions = new HashSet<string>() 
        { 
            ".exe", ".com", ".bat", ".cmd", ".ps1" 
        };

        public List<string> Folders;

        public PathString()
        {
            string rawText = Environment.GetEnvironmentVariable(pathKey, EnvironmentVariableTarget.Machine);
            this.Folders = rawText.Split(';').ToList();
        }

        public override string ToString()
        {
            return String.Join(";", Folders);
        }

        public void Update()
        {
            string newPath = this.ToString();
            Environment.SetEnvironmentVariable(pathKey, newPath, EnvironmentVariableTarget.Machine);
        }

        public IEnumerable<PathProblem> Problems
        {
            get
            {
                var sortedFolders = Folders.OrderBy(s => s).ToList();
                for (int n = 0; n < sortedFolders.Count; n++)
                {
                    var folder = sortedFolders[n];
                    var problems = PathProblemTypes.None;
                    if (n > 0 && String.Compare(folder, sortedFolders[n - 1], StringComparison.InvariantCultureIgnoreCase) == 0)
                    {
                        problems |= PathProblemTypes.Duplicate;
                        goto Skip;
                    }
                    if (!Directory.Exists(folder))
                    {
                        problems |= PathProblemTypes.MissingFolder;
                    }
                    else
                    {
                        if (!Directory.EnumerateFiles(folder).Any())
                        {
                            problems |= PathProblemTypes.Empty;
                        }
                        else if (!Directory.EnumerateFiles(folder).Where(s => executableExtensions.Contains(Path.GetExtension(s))).Any())
                        {
                            problems |= PathProblemTypes.NoExecutables;
                        }
                    }
                Skip:
                    if(problems != PathProblemTypes.None)
                    {
                        yield return new PathProblem()
                        {
                            Path = folder,
                            Problems = problems,
                        };
                    }
                }
            }
        }
    }
}
