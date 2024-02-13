使用Node.js的`edge-js`模块

安装`edge-js`模块：

```bash
npm install edge-js
```

编写调用代码

```typescript
const edge = require('edge-js');

// 创建C#函数代理
const runCommand = edge.func(`
    #r "path/to/your/ShellLibrary.dll"

    async (input) => {
        var Shell = new ShellLibrary.Shell();
        Shell.RunCommand(
            input.command,
            input.count.toString(),
            input.hideWindow.toString()
        );

        return null;
    }
`);

// 调用C#函数
runCommand(
    {
        command: "your_command_here",
        count: 1,
        hideWindow: false
    },
    (error: any) => {
        if (error) {
            console.error("Failed to call the C# function:", error);
        } else {
            console.log("C# function call succeeded.");
        }
    }
);
```

将`path/to/your/ShellLibrary.dll`替换为ShellLibrary.dll的实际路径

运行以下命令以编译并执行TypeScript文件：

```bash
npx tsc callShellLibrary.ts && node callShellLibrary.js
```