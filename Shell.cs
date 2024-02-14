using static ShellLibrary.RunCommand;

namespace ShellLibrary
{
    public class Shell
    {
        public static async Task RunCommand(string command, string count = "1", string hideWindow = "false", bool async = false, bool useDataflow = false, bool showProgress = false)
        {
            if (!int.TryParse(count, out int executionCount))
            {
                Console.WriteLine("Invalid execution count. Using default value of 1.");
                executionCount = 1;
            }

            if (!bool.TryParse(hideWindow, out bool isHideWindow))
            {
                Console.WriteLine("Invalid hide window flag. Using default value of false.");
                isHideWindow = false;
            }

            // 根据 async 参数选择执行方式
            if (async)
            {
                if (useDataflow)
                {
                    await RunCommandAsyncWithActionBlock(command, executionCount, isHideWindow, showProgress);
                }
                else
                {
                    await RunCommandAsyncWithTasks(command, executionCount, isHideWindow, showProgress);
                }
            }
            else
            {
                RunCommandSync(command, executionCount, isHideWindow);
            }
        }
    }
}
