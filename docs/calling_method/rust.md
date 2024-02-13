编辑 Cargo.toml 文件，添加 `rustdotnet` 作为依赖项：

```toml
[dependencies]
rustdotnet = "0.9"
```

编写代码

```rust
extern crate rustdotnet;

use rustdotnet::coreclr::{ClrLoader, ClrObject};
use std::path::PathBuf;

fn main() {
    let dll_path = "<path_to_your_ShellLibrary.dll>";
    let clr_loader = ClrLoader::new(dll_path).expect("Failed to load CLR");

    let shell_type = clr_loader
        .find_type("ShellLibrary", "Shell")
        .expect("Failed to find Shell type");

    let run_command_method = clr_loader
        .find_method(&shell_type, "RunCommand", &["System.String", "System.String", "System.String"])
        .expect("Failed to find RunCommand method");

    let command = "your_command_here";
    let count = "1";
    let hide_window = "false";
    let parameters: Vec<ClrObject> = vec![
        clr_loader.wrap_string(command),
        clr_loader.wrap_string(count),
        clr_loader.wrap_string(hide_window),
    ];

    clr_loader.invoke_method(&run_command_method, Some(&parameters)).expect("Failed to invoke method");
}
```

将 `<path_to_your_ShellLibrary.dll>` 替换为ShellLibrary.dll的实际路径。

注意，使用 `rustdotnet` 库需要在您的系统上正确安装 .NET Core SDK