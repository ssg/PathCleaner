using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PathCleaner
{
    class PathString
    {
        private const string pathKey = "PATH";

        private static HashSet<string> executableExtensions = new HashSet<string>() 
        { 
            ".exe", ".com", ".bat", ".cmd", ".ps1", ".dll"
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

        private PathProblem getProblem(string folder, int index, List<string> folders)
        {
            if (index > 0 && String.Compare(folder, folders[index - 1], StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                return new PathProblem(folder, PathProblemType.Duplicate);
            }
            if (!Directory.Exists(folder))
            {
                return new PathProblem(folder, PathProblemType.MissingFolder);
            }
            if (!Directory.EnumerateFiles(folder).Any())
            {
                return new PathProblem(folder, PathProblemType.Empty);
            }
            if (!Directory.EnumerateFiles(folder).Where(s => executableExtensions.Contains(Path.GetExtension(s))).Any())
            {
                return new PathProblem(folder, PathProblemType.NoExecutables);
            }
            return null;
        }

        public IEnumerable<PathProblem> Problems
        {
            get
            {
                var sortedFolders = Folders.OrderBy(s => s).ToList();
                for (int n = 0; n < sortedFolders.Count; n++)
                {
                    var folder = sortedFolders[n];
                    var problem = getProblem(folder, n, sortedFolders);
                    if (problem != null)
                    {
                        yield return problem;
                    }
                }
            }
        }
    }
}
