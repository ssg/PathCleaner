using System;
using System.Collections.Generic;
using System.Linq;

namespace PathCleaner
{
    class PathString
    {
        private const string pathKey = "PATH";

        public IList<string> Folders { get; private set; }

        public PathString()
        {
            string rawText = Environment.GetEnvironmentVariable(pathKey,
                EnvironmentVariableTarget.Machine);
            this.Folders = rawText.Split(';').ToList();
        }

        public override string ToString()
        {
            return String.Join(";", Folders);
        }

        public void UpdateEnvironmentVariable()
        {
            string newPath = this.ToString();
            Environment.SetEnvironmentVariable(pathKey, newPath, EnvironmentVariableTarget.Machine);
        }
    }
}