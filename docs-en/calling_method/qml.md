Although it looks a little complicated, but fortunately, the operation is actually not difficult



Main window code

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

    property string dllPath: "path/to/your/dll/ShellLibrary.dll" // Adjust the value based on the actual DLL file path

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

Create a new QML file (for example, `Process.qml` )

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

Import `Process.qml` into the qml file in the main window (for example, `main.qml` )

```qml
import "./Process.qml" // Adjust the file path based on the actual file path
```

Make sure that the DLL file path is updated to the actual DLL file path. Parameters are passed by modifying `commandField` ,  `countField` , and `hideWindowField` .