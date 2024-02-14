在 TypeScript 中使用 C# 类库需要使用 TypeScript 的 `import` 语法来导入并调用 C# 类库的方法。首先，确保你已经安装了 `edge-js` 或者 `edge-cs` 这样的库，它们可以帮助你在 Node.js 中运行 .NET 代码。

## edge-js (推荐)

1. 安装 `edge-js` ：

   ```bash
   npm install edge-js
   ```

2. 创建一个 TypeScript 文件，比如 `app.ts`，并在该文件中导入并调用 C# 类库中的方法：

   ```typescript
   import * as edge from 'edge-js';
   
   // 使用 edge.func 导入 C# 类库
   const runCommand = edge.func({
       assemblyFile: './ShellLibrary.dll', // 替换为实际的路径
       typeName: 'ShellLibrary.Shell',
       methodName: 'RunCommand'
   });
   
   // 调用 C# 类库中的方法
   runCommand(
       {
           command: "your_command", 
           count: "1",
           hideWindow: "false",
           async: false,
           useDataflow: false,
           showProgress: false
       },
       (error: any, result: any) => {
           if (error) throw error;
           console.log(result);
       }
   );
   ```

使用 `tsc` 命令将 TypeScript 文件编译为 JavaScript 文件，最后在 Node.js 中运行该 JavaScript 文件即可调用 C# 类库中的方法。

## edge-cs

当使用 `edge-cs` 时，你可以按照以下步骤来在 TypeScript 中使用 C# 类库：

1. 首先，安装 `edge-cs`：

```bash
npm install edge-cs
```

2. 创建一个 TypeScript 文件，比如 `app.ts`，并在该文件中导入并调用 C# 类库中的方法：

```typescript
import * as edge from 'edge-cs';

// 使用 edge.func 导入 C# 类库
const runCommand = edge.func({
    source: `
        using System;
        using System.Threading.Tasks.Dataflow;

        public class Startup
        {
            public async Task<object> Invoke(dynamic input)
            {
                var command = (string)input.command;
                var count = (string)input.count;
                var hideWindow = (string)input.hideWindow;
                var async = (bool)input.async;
                var useDataflow = (bool)input.useDataflow;
                var showProgress = (bool)input.showProgress;
                
                // 调用 ShellLibrary.Shell.RunCommand 方法
                ShellLibrary.Shell.RunCommand(command, count, hideWindow, async, useDataflow, showProgress);
                
                return null;
            }
        }
    `,
    typeName: 'Startup',
    methodName: 'Invoke'
});

// 调用 C# 类库中的方法
runCommand(
    {
        command: "your_command",
        count: "1",
        hideWindow: "false",
        async: false,
        useDataflow: false,
        showProgress: false
    },
    (error: any, result: any) => {
        if (error) throw error;
        console.log(result);
    }
);
```

3. 编译 TypeScript 文件并在 Node.js 中运行生成的 JavaScript 文件即可调用 C# 类库中的方法。

请确保将 C# 类库的实际路径替换为正确的路径，并根据实际情况调整代码中的参数和方法名称。