In your C++ project, include the header file "ShellLibraryWrapper.h" and call the RunCommand function of the ShellLibrary class with the following code

```c++
#include <Windows.h>

typedef void(*RunCommandFunc)(const char*, const char*, const char*);

int main()
{
    HINSTANCE hDll = LoadLibrary("ShellLibrary.dll");
    if (hDll == NULL)
    {
        // Handle cases where a DLL cannot be loaded
        return 1;
    }

    RunCommandFunc runCommand = (RunCommandFunc)GetProcAddress(hDll, "ShellLibrary.Shell.RunCommand");
    if (runCommand == NULL)
    {
        // Handle cases where the function address cannot be obtaineds
        FreeLibrary(hDll);
        return 1;
    }

    runCommand("echo Hello World!", "3", "false");

    FreeLibrary(hDll);
    return 0;
}
```