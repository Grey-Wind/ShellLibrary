在你的C++项目中，包含头文件 "ShellLibraryWrapper.h"，并使用以下代码调用ShellLibrary类的RunCommand函数

```c++
#include <Windows.h>

typedef void(*RunCommandFunc)(const char*, const char*, const char*);

int main()
{
    HINSTANCE hDll = LoadLibrary("ShellLibrary.dll");
    if (hDll == NULL)
    {
        // 处理无法加载DLL的情况
        return 1;
    }

    RunCommandFunc runCommand = (RunCommandFunc)GetProcAddress(hDll, "ShellLibrary.Shell.RunCommand");
    if (runCommand == NULL)
    {
        // 处理无法获取函数地址的情况
        FreeLibrary(hDll);
        return 1;
    }

    runCommand("echo Hello World!", "3", "false");

    FreeLibrary(hDll);
    return 0;
}
```