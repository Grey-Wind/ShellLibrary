using System.Diagnostics;
using System.Threading.Tasks.Dataflow;

namespace ShellLibrary
{
    public class Shell
    {
        /// <summary>
        /// Runs a command in the shell. / 在shell中运行命令。
        /// </summary>
        /// <param name="command">The command to be executed. / 要执行的命令。</param>
        /// <param name="count">The number of times to execute the command (default: 1). / 执行命令的次数(默认为1)。</param>
        /// <param name="hideWindow">Flag to hide the shell window (default: false). / 隐藏shell窗口的标志(默认:false)。</param>
        /// <param name="async">Flag to specify whether to run the commands asynchronously (default: false). / 用于指定是否异步运行命令的标志(默认:false)。</param>
        /// <param name="useDataflow">Flag to specify whether to use dataflow for asynchronous execution (default: false). / 指定是否使用数据流进行异步执行的标志(默认:false)。</param>
        /// <param name="showProgress">Flag to display a progress bar for command execution (default: false). / 指示命令执行的进度条(默认:false)。</param>
        public static async Task RunCommand(string command, string count = "1", string hideWindow = "false", bool async = false, bool useDataflow = false, bool showProgress = false)
        {
            // 尝试将count转换为int类型，如果转换失败，则使用默认值1
            if (!int.TryParse(count, out int executionCount))
            {
                Console.WriteLine("Invalid execution count. Using default value of 1.");
                executionCount = 1;
            }

            // 尝试将hideWindow转换为bool类型，如果转换失败，则使用默认值false
            if (!bool.TryParse(hideWindow, out bool isHideWindow))
            {
                Console.WriteLine("Invalid hide window flag. Using default value of false.");
                isHideWindow = false;
            }

            // 如果async为false，则使用同步方式执行命令
            if (!async)
            {
                for (int i = 0; i < executionCount; i++)
                {
                    // 创建一个ProcessStartInfo对象，用于描述命令行参数
                    var processStartInfo = new ProcessStartInfo()
                    {
                        FileName = "cmd.exe",
                        Arguments = $"/c {command}",
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = isHideWindow
                    };

                    // 创建一个Process对象，用于执行命令行参数
                    using (var process = new Process())
                    {
                        process.StartInfo = processStartInfo;
                        process.Start();

                        // 读取命令行参数的输出
                        string output = process.StandardOutput.ReadToEnd();
                        Console.WriteLine(output);

                        // 等待命令行参数执行完毕
                        process.WaitForExit();
                    }
                }
            }
            // 如果async为true，则使用异步方式执行命令
            else
            {
                // 如果useDataflow为true，则使用Dataflow方式执行命令
                if (useDataflow)
                {
                    // 创建一个ActionBlock对象，用于异步执行命令
                    var dataflowBlock = new ActionBlock<int>(async (index) =>
                    {
                        // 创建一个ProcessStartInfo对象，用于描述命令行参数
                        var processStartInfo = new ProcessStartInfo()
                        {
                            FileName = "cmd.exe",
                            Arguments = $"/c {command}",
                            RedirectStandardOutput = true,
                            UseShellExecute = false,
                            CreateNoWindow = isHideWindow
                        };

                        // 创建一个Process对象，用于执行命令行参数
                        using (var process = new Process())
                        {
                            process.StartInfo = processStartInfo;
                            process.Start();

                            // 读取命令行参数的输出
                            string output = await process.StandardOutput.ReadToEndAsync();
                            Console.WriteLine(output);

                            // 等待命令行参数执行完毕
                            process.WaitForExit();
                        }
                    });

                    // 循环执行命令，并显示进度条
                    for (int i = 0; i < executionCount; i++)
                    {
                        await dataflowBlock.SendAsync(i);
                        if (showProgress)
                        {
                            float progress = ((float)i + 1) / executionCount * 100;
                            Console.WriteLine($"Progress: {progress}%");
                        }
                    }

                    // 等待ActionBlock对象执行完毕
                    dataflowBlock.Complete();
                    await dataflowBlock.Completion;
                }
                // 如果useDataflow为false，则使用Task方式执行命令
                else
                {
                    // 创建一个Task数组，用于异步执行命令
                    var tasks = new Task[executionCount];
                    for (int i = 0; i < executionCount; i++)
                    {
                        // 创建一个Task对象，用于异步执行命令
                        tasks[i] = Task.Run(async () =>
                        {
                            // 创建一个ProcessStartInfo对象，用于描述命令行参数
                            var processStartInfo = new ProcessStartInfo()
                            {
                                FileName = "cmd.exe",
                                Arguments = $"/c {command}",
                                RedirectStandardOutput = true,
                                UseShellExecute = false,
                                CreateNoWindow = isHideWindow
                            };

                            // 创建一个Process对象，用于执行命令行参数
                            using (var process = new Process())
                            {
                                process.StartInfo = processStartInfo;
                                process.Start();

                                // 读取命令行参数的输出
                                string output = await process.StandardOutput.ReadToEndAsync();
                                Console.WriteLine(output);

                                // 等待命令行参数执行完毕
                                process.WaitForExit();
                            }
                        });

                        // 显示进度条
                        if (showProgress)
                        {
                            float progress = ((float)i + 1) / executionCount * 100;
                            Console.WriteLine($"Progress: {progress}%");
                        }
                    }
                    // 等待所有Task对象执行完毕
                    await Task.WhenAll(tasks);
                }
            }
        }
    }
}