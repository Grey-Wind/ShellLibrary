using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ShellLibrary
{
    public class Shell
    {
        public static async Task RunCommand(string command, string count = "1", string hideWindow = "false", bool async = false, bool useDataflow = false, bool showProgress = false)
        {
            if (!int.TryParse(count, out int executionCount))
            {
                Console.WriteLine("无效的执行计数，请使用数字。目前使用默认值1运行。");
                executionCount = 1;
            }

            if (!bool.TryParse(hideWindow, out bool isHideWindow))
            {
                Console.WriteLine("无效的隐藏窗口属性，请使用布尔值。现使用false运行。");
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

        private static void RunCommandSync(string command, int executionCount, bool isHideWindow)
        {
            for (int i = 0; i < executionCount; i++)
            {
                ProcessCommand(command, isHideWindow).Wait();
            }
        }

        private static async Task RunCommandAsyncWithActionBlock(string command, int executionCount, bool isHideWindow, bool showProgress)
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

        private static async Task RunCommandAsyncWithTasks(string command, int executionCount, bool isHideWindow, bool showProgress)
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
                if (!isHideWindow)
                {
                    // 暂停代码执行，保持 Shell 窗口不消失
                    Console.WriteLine("按任意键退出...");
                    Console.ReadKey();
                }
                process.WaitForExit();
            }
        }
    }
}
