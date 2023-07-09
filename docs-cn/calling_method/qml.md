虽然看起来略有复杂，但还好，操作其实不困难

主窗口代码

```qml
import QtQuick 2.15
import QtQuick.Controls 2.15
import QtQuick.Window 2.15

ApplicationWindow {
    id: mainWindow
    visible: true
    width: 400
    height: 300
    title: "Shell Command Demo"

    property string dllPath: "path/to/your/dll/ShellLibrary.dll" // 根据实际DLL文件路径进行调整

    ColumnLayout {
        spacing: 10

        TextField {
            id: commandField
            placeholderText: "Enter command..."
        }

        TextField {
            id: countField
            placeholderText: "Execution count..."
        }

        TextField {
            id: hideWindowField
            placeholderText: "Hide window (true/false)..."
        }

        Button {
            text: "Run Command"
            onClicked: {
                var process = Qt.createQmlObject('import QtQuick 2.15; import QtQuick.Controls 2.15; Process { command: "' + commandField.text + '"; count: "' + countField.text + '"; hideWindow: "' + hideWindowField.text + '"; dllPath: mainWindow.dllPath; }', mainWindow);
                process.run();
            }
        }

        TextEdit {
            id: outputText
            readOnly: true
            wrapMode: TextEdit.Wrap
            height: mainWindow.height - 200
        }
    }
}
```

创建一个新的QML文件（例如`Process.qml`）

```qml
import QtQuick 2.15
import QtQuick.Controls 2.15
import QtQuick.Window 2.15

Process {
    id: process

    property string command
    property string count
    property string hideWindow
    property string dllPath

    function run() {
        if (dllPath !== "" && command !== "") {
            var shellLibrary = Qt.createQmlObject('import QtQuick 2.15; import QtQuick.Controls 2.15; ShellLibrary { }', window);
            shellLibrary.RunCommand(command, count, hideWindow);
        }
    }
}
```

在主窗口的QML文件（例如`main.qml`）中导入`Process.qml`

```qml
import "./Process.qml" // 根据实际文件路径进行调整
```

确保将DLL文件路径更新为实际的DLL文件路径。通过修改`commandField`、`countField`和`hideWindowField`来传递参数。