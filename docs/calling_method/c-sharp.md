### 1. 静态调用方式

在这种方式下，不需要创建Shell类的实例，可以直接通过类名来调用Shell.RunCommand方法。

```c#
using ShellLibrary;

class Program
{
    static void Main()
    {
        string command = "dir";  // 自定义要执行的命令
        int count = 3;          // 自定义执行次数
        bool hideWindow = true; // 自定义是否隐藏命令行窗口

        Shell.RunCommand(command, count, hideWindow);
    }
}
```

### 2. 实例化调用方式

在这种方式下，首先需要创建Shell类的实例，然后通过该实例来调用RunCommand方法。

```c#
using ShellLibrary;

class Program
{
    static void Main()
    {
        string command = "dir";  // 自定义要执行的命令
        int count = 3;          // 自定义执行次数
        bool hideWindow = true; // 自定义是否隐藏命令行窗口

        Shell shell = new Shell();  // 创建Shell类的实例
        shell.RunCommand(command, count, hideWindow);  // 调用实例的RunCommand方法
    }
}
```