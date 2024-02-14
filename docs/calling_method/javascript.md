## edge.js

如果你是基于 Node.js 的 JavaScript 开发，你可以使用 `edge.js` 这个库来调用 C# 类库。`edge.js` 允许你在 Node.js 中直接调用 .NET 代码。

首先，确保你已经在你的 Node.js 项目中安装了 `edge.js`:

```sh
npm install edge.js
```

然后，你可以按照以下步骤在你的 Node.js 项目中调用 C# 类库：

1. 将 C# 类库编译成可供 Node.js 使用的 .NET Standard 程序集（DLL 文件）。

2. 在 Node.js 代码中使用 `edge.js` 来加载并调用 C# 类库的函数。

下面是一个简单的示例：

```javascript
const edge = require('edge');

// 加载编译好的C#类库
const runCommand = edge.func({
    assemblyFile: './ShellLibrary.dll', // 替换为你的C#类库的路径
    typeName: 'ShellLibrary.Shell',
    methodName: 'RunCommand'
});

// 调用C#函数
runCommand({
    command: "your_command",
    count: "1",
    hideWindow: "false",
    async: false,
    useDataflow: false,
    showProgress: false
}, function (error, result) {
    if (error) throw error;
    console.log(result);
});
```

## WebAssembly 模块

要在 JavaScript 中使用 C# 类库，你需要先使用 `dotnet` 命令行工具将 C# 代码编译成可供 JavaScript 使用的 WebAssembly 模块。以下是具体步骤：

### 步骤1：编译 C# 代码为 WebAssembly 模块

首先，确保你的开发环境中已经安装了 .NET Core SDK。然后，在命令行中进入包含 `ShellLibrary.cs` 文件的目录，并执行以下命令：

```sh
dotnet publish -c Release -r browser-wasm
```

这将使用 .NET Core 发行版功能将 C# 代码编译为 WebAssembly 模块，并将输出文件放置在发布目录中。

### 步骤2：将输出文件用于 JavaScript
将上一步生成的输出文件 `ShellLibrary.dll` 和相关的 JavaScript 文件引入到你的 JavaScript 项目中。可以将它们放在你的网站根目录下的一个子目录中。

### 步骤3：在 JavaScript 中使用 WebAssembly 模块
你可以使用 `WebAssembly.instantiateStreaming()` 函数加载和实例化你的 WebAssembly 模块。接下来，你可以通过调用 C# 类库中的函数来运行命令。

```javascript
(async () => {
  const response = await fetch('./ShellLibrary.dll');
  const bytes = new Uint8Array(await response.arrayBuffer());
  const { instance } = await WebAssembly.instantiate(bytes);

  // 调用 C# 函数
  instance.exports.RunCommand("your_command", "count_value", "hideWindow_value", async_value, useDataflow_value, showProgress_value);
})();
```

### 注意事项
- 请确保你的浏览器支持 WebAssembly。
- 在某些情况下，可能需要处理跨域请求问题以确保能够成功加载 WebAssembly 模块。
