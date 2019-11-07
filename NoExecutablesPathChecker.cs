using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PathCleaner
{
    internal class NoExecutablesPathChecker : IPathChecker
    {
        private static readonly HashSet<string> executableExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            ".exe", ".com", ".bat", ".cmd", ".ps1", ".dll"
        };

        static NoExecutablesPathChecker()
        {
            string rawText = Environment.GetEnvironmentVariable("PATHEXT", EnvironmentVariableTarget.Machine);
            if (rawText == null)
            {
                return;
            }

            foreach (string ext in rawText.Split(';').Where(ext => !string.IsNullOrWhiteSpace(ext)))
            {
                executableExtensions.Add(ext);
            }
        }

        public string Reason => "No executables";

        public bool Identify(string folder, string previousFolder)
        {
            return !Directory.EnumerateFiles(folder)
                .Where(s => executableExtensions.Contains(Path.GetExtension(s)))
                .Any();
        }
    }
}