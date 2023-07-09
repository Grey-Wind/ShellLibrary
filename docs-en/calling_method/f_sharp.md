Open the F# code file and add a reference to the ShellLibrary namespace at the top:

```F#
open System.Diagnostics
open ShellLibrary
```

Use the RunCommand method of the Shell class and pass three parameters as follows:

```F#
[<EntryPoint>]
let main argv =
    Shell.RunCommand "your_command_here" count="your_count_here" hideWindow="your_hideWindow_here"
    0 // Return
```

Replace `your_command_here`, `your_count_here` , and `your_hideWindow_here` with the command you want to execute, the number of times it is executed, and the parameter values for the hidden window.