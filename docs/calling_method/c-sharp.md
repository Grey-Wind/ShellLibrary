要使用Shell库中的RunCommand方法，你可以按照以下步骤进行操作：

1. 在你的项目中引用ShellLibrary命名空间。
2. 调用Shell.RunCommand方法并传入相应的参数。
   - command参数是要执行的命令。
   - count参数是要执行命令的次数（可选，默认为1）。
   - hideWindow参数是一个布尔值，用于指定是否隐藏命令行窗口（可选，默认为false）。
   - async参数是一个布尔值，用于指定是否异步执行命令（可选，默认为true）。
   - useDataflow参数是一个布尔值，用于指定是否使用数据流进行异步执行（可选，默认为false）。
   - showProgress参数是一个布尔值，用于指定是否显示命令执行进度条（可选，默认为false）。

以下是一个示例代码：

```csharp
using ShellLibrary;

class Program
{
    static async Task Main()
    {
        string command = "dir"; // 要执行的命令
        string count = "5"; // 执行命令的次数
        string hideWindow = "false"; // 是否隐藏命令行窗口
        bool async = true; // 是否异步执行命令
        bool useDataflow = false; // 是否使用数据流进行异步执行
        bool showProgress = true; // 是否显示命令执行进度条

        await Shell.RunCommand(command, count, hideWindow, async, useDataflow, showProgress);
    }
}
```

在上面的示例中使用Shell.RunCommand方法执行了5次"dir"命令，并且显示了命令执行的进度条。

**注意：**使用 *.NET 6.0* 以及之后版本的项目需要使用2.0.0(不包括2.0.0)之前的版本，使用 *.NET Framework 4.7.2* 及以后版本的项目需要使用2.0.0及之后的版本。
