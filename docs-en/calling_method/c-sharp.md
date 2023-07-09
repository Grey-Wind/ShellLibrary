### 1. Static call mode

In this way, you do not need to create an instance of the Shell class, you can call the Shell.RunCommand method directly by the class name.

```c#
using ShellLibrary;

class Program
{
    static void Main()
    {
        string command = "dir";  // Customize the commands to be executed
        int count = 3;          // Customize the number of times it needs to be executed
        bool hideWindow = true; // Customize whether to hide command line Windows

        Shell.RunCommand(command, count, hideWindow);
    }
}
```

### 2. Instantiate the invocation mode

In this way, you first need to create an instance of the Shell class, and then invoke the RunCommand method through that instance.

```c#
using ShellLibrary;

class Program
{
    static void Main()
    {
        string command = "dir";  // Customize the commands to be executed
        int count = 3;          // Customize the number of times it needs to be executed
        bool hideWindow = true; // Customize whether to hide command line Windows

        Shell shell = new Shell();  // Create an instance of a Shell class
        shell.RunCommand(command, count, hideWindow);  // Invoke the instance's RunCommand method
    }
}
```