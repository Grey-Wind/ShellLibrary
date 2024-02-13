使用Python的`ctypes`模块

```python
import ctypes

# 加载ShellLibrary.dll
shell_library = ctypes.WinDLL('Path_to_the_dll/ShellLibrary.dll')

# 设置RunCommand函数的参数类型
shell_library.RunCommand.argtypes = [ctypes.c_char_p, ctypes.c_char_p, ctypes.c_char_p]

# 调用RunCommand函数
def run_command(command, count="1", hide_window="false"):
    command_bytes = command.encode('utf-8')
    count_bytes = count.encode('utf-8')
    hide_window_bytes = hide_window.encode('utf-8')

    shell_library.RunCommand(command_bytes, count_bytes, hide_window_bytes)

# 示例调用
run_command("your_command_here", "your_count_here", "your_hideWindow_here")
```

请将`Path_to_the_dll`替换为实际的dll文件路径，将`your_command_here`、`your_count_here`和`your_hideWindow_here`替换为您想要执行的命令、执行次数和隐藏窗口的参数值。