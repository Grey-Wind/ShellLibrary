Use the Node.js `edge-js` module

Install the `edge-js` module:

```bash
npm install edge-js
```

Write call code

```typescript
const edge = require('edge-js');

// Create C# function proxies
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

Replace `path/to/your/ShellLibrary.dll` with the actual path to ShellLibrary.dll

Run the following command to compile and execute the TypeScript file:

```bash
npx tsc callShellLibrary.ts && node callShellLibrary.js
```