## C# .NET Framework

```c#
using ShellLibrary;

namespace CsTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shell.RunCommand("ipconfig", "2", "false", false, false, false);
            Shell.RunCommand("pause");
        }
    }
}
```

## Visual Basic .NET Framework

```vb
Imports ShellLibrary

Module Program

    Sub Main()
        ' 调用 RunCommand 方法运行命令
        Shell.RunCommand("ping 127.0.0.1", count:="3", hideWindow:="false", async:=False, useDataflow:=False, showProgress:=False)

        Console.ReadLine()
    End Sub

End Module
```

## F# .NET Framework

```F#
open ShellLibrary

[<EntryPoint>]
let main args =
    async {
        let command = "dir" // 要执行的命令
        let count = "5" // 执行命令的次数
        let hideWindow = "false" // 是否隐藏命令行窗口
        let async = true // 是否异步执行命令
        let useDataflow = false // 是否使用数据流进行异步执行
        let showProgress = true // 是否显示命令执行进度条

        do! Shell.RunCommand(command, count, hideWindow, async, useDataflow, showProgress) |> Async.AwaitTask
    } |> Async.RunSynchronously |> ignore

    0 // 返回一个整数结果，表示程序正常结束
```

