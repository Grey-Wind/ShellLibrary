打开F#代码文件，在文件顶部添加对ShellLibrary命名空间的引用：

```F#
open System.Diagnostics
open ShellLibrary
```

使用Shell类的RunCommand方法，并传递三个参数，如下所示：

```F#
[<EntryPoint>]
let main argv =
    Shell.RunCommand "your_command_here" count="your_count_here" hideWindow="your_hideWindow_here"
    0 // 返回值
```

将`your_command_here`、`your_count_here`和`your_hideWindow_here`替换为您想要执行的命令、执行次数和隐藏窗口的参数值。