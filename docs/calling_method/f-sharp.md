在F#中使用C#库非常简单，你只需要将该类库引入到你的F#项目中即可。以下是一个示例代码：

```fsharp
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

在上述示例中，我们使用F#的async块和异步编程模型来调用C#的Shell库。注意使用`Async.AwaitTask`方法将异步操作转换为F#的异步工作单元。

**注意：**使用 *.NET 6.0* 以及之后版本的项目需要使用2.0.0(不包括2.0.0)之前的版本，使用 *.NET Framework 4.7.2* 及以后版本的项目需要使用2.0.0及之后的版本。
