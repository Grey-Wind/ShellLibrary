导入命名空间直接调用

```vb
Imports ShellLibrary

Public Class Main
    Public Shared Sub Main(args As String())
        Shell.RunCommand("command_here", "count_here", "hideWindow_here")
    End Sub
End Class
```

将`command_here`、`count_here`和`hideWindow_here`替换为您想要执行的命令、执行次数和隐藏窗口的参数值