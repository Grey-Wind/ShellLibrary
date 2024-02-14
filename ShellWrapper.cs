namespace ShellLibrary
{
    public class Wrapper
    {
        public static async void RunCommand(string command, string count = "1", string hideWindow = "false", bool async = false, bool useDataflow = false, bool showProgress = false)
        {
            await Shell.RunCommand(command, count, hideWindow, async, useDataflow, showProgress);
        }
    }
}
