namespace PathCleaner
{
    interface IPathChecker
    {
        string Reason { get; }
        bool Identify(string folder, string previousFolder);
    }

}
