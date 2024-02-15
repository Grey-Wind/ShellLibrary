## C# .NET Framework

```c#
using ShellLibrary;

namespace CsTest
{
    internal class Program
    {
        private async void Main(string[] args)
        {
            await Task.Run(() =>
            {
                Shell.RunCommand("ipconfig", "2", "false", false, false, false);
            Shell.RunCommand("pause");
            }
        }
    }
}
```

## Visual Basic .NET Framework

```vb
Using ShellLibrary

Namespace VbTest
    Public Class Program
        Private Async Sub Main(args As String())
            Await Task.Run(Sub()
                Shell.RunCommand("ipconfig", "2", "False", False, False, False)
            Shell.RunCommand("pause")
            End Sub)
        End Sub
    End Class
End Namespace
```

## F# .NET Framework

```F#
open ShellLibrary
open System.Threading.Tasks

type Program() =
    member this.Main(args : string array) =
        let task = async {
            do! Shell.RunCommand("ipconfig", "2", "false", false, false, false) |> Async.AwaitTask
            Shell.RunCommand("pause") |> ignore
        }
        task |> Async.Start
```

