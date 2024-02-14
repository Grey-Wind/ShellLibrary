- 在 C++ 项目/本机中有头文件 `windows.h`。(一般都是有的，可忽略)
- 使用 `LoadLibrary` 加载 ShellLibrary.dll。
- 定义函数指针来指向 C# 类库中的函数。
- 使用 `GetProcAddress` 获取函数地址，然后调用该函数指针执行 C# 类库中的函数。

以下是一个简单的示例代码，在 C++ 中调用 C# 类库的方法：
```cpp
#include <windows.h>
#include <iostream>

typedef void (*RunCommandFunc)(const char*, const char*, const char*, bool, bool, bool);

int main() {
    HINSTANCE hDll = LoadLibrary(TEXT("ShellLibrary.dll"));
    if (hDll == NULL) {
        std::cerr << "Failed to load the DLL" << std::endl;
        return 1;
    }

    RunCommandFunc runCommand = (RunCommandFunc) GetProcAddress(hDll, "RunCommand");
    if (runCommand == NULL) {
        std::cerr << "Failed to get function address" << std::endl;
        FreeLibrary(hDll);
        return 1;
    }

    // 调用 C# 类库中的函数
    runCommand("dir", "1", "false", false, false, false);

    FreeLibrary(hDll);
    return 0;
}
```

请注意，由于 C# 和 C++ 之间存在数据类型和内存管理方面的区别，因此需要特别小心处理参数传递和内存分配。上述示例代码仅作为演示，实际使用时需根据具体情况进行适当修改和错误处理。