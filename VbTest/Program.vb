Imports ShellLibrary

Module Program

    Sub Main()
        ' 调用 RunCommand 方法运行命令
        Shell.RunCommand("ping 127.0.0.1", count:="3", hideWindow:="false", async:=False, useDataflow:=False, showProgress:=False)

        Console.ReadLine()
    End Sub

End Module
