using System;
using System.Diagnostics;

namespace ShellLibrary
{
    public class Shell
    {
        public static void RunCommand(string command, string count = "1", string hideWindow = "false")
        {
            if (!int.TryParse(count, out int executionCount))
            {
                Console.WriteLine("Invalid execution count. Using default value of 1.");
                executionCount = 1;
            }

            bool isHideWindow;
            if (!bool.TryParse(hideWindow, out isHideWindow))
            {
                Console.WriteLine("Invalid hide window flag. Using default value of false.");
                isHideWindow = false;
            }

            for (int i = 0; i < executionCount; i++)
            {
                var processStartInfo = new ProcessStartInfo()
                {
                    FileName = "cmd.exe",
                    Arguments = $"/c {command}",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = isHideWindow
                };

                using (var process = new Process())
                {
                    process.StartInfo = processStartInfo;
                    process.Start();

                    // 可以选择读取和处理输出
                    string output = process.StandardOutput.ReadToEnd();
                    Console.WriteLine(output);

                    process.WaitForExit();
                }
            }
        }
    }
}
