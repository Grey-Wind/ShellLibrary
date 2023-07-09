Import namespace calls directly

```vb
Imports ShellLibrary

Public Class Main
    Public Shared Sub Main(args As String())
        Shell.RunCommand("command_here", "count_here", "hideWindow_here")
    End Sub
End Class
```

Replace `command_here` , `count_here` , and `hideWindow_here` with the command you want to execute, the number of times it is executed, and the parameter values for the hidden window