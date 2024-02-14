using System.Diagnostics;
using System.Threading.Tasks.Dataflow;

namespace ShellLibrary
{
    internal class RunCommand
    {
        private static async Task ProcessCommand(string command, bool isHideWindow)
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
                string output = await process.StandardOutput.ReadToEndAsync();
                Console.WriteLine(output);
                process.WaitForExit();
            }
        }

        public static void RunCommandSync(string command, int executionCount, bool isHideWindow)
        {
            for (int i = 0; i < executionCount; i++)
            {
                ProcessCommand(command, isHideWindow).Wait();
            }
        }

        public static async Task RunCommandAsyncWithActionBlock(string command, int executionCount, bool isHideWindow, bool showProgress)
        {
            var dataflowBlock = new ActionBlock<int>(async (index) =>
            {
                await ProcessCommand(command, isHideWindow);
                if (showProgress)
                {
                    float progress = ((float)index + 1) / executionCount * 100;
                    Console.WriteLine($"Progress: {progress}%");
                }
            });

            for (int i = 0; i < executionCount; i++)
            {
                await dataflowBlock.SendAsync(i);
            }

            dataflowBlock.Complete();
            await dataflowBlock.Completion;
        }

        public static async Task RunCommandAsyncWithTasks(string command, int executionCount, bool isHideWindow, bool showProgress)
        {
            var tasks = new Task[executionCount];
            for (int i = 0; i < executionCount; i++)
            {
                int index = i; // 避免闭包中的变量捕获问题
                tasks[i] = Task.Run(async () =>
                {
                    await ProcessCommand(command, isHideWindow);
                    if (showProgress)
                    {
                        float progress = ((float)index + 1) / executionCount * 100;
                        Console.WriteLine($"Progress: {progress}%");
                    }
                });
            }

            await Task.WhenAll(tasks);
        }
    }
}
