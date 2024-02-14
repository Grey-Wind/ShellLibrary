首先，创建一个 C++/CLI 封装库，比如名为 "ShellLibraryWrapper"，包含以下内容：

### ShellLibraryWrapper.h

```cpp
#pragma once

#include <QString>
#include <QObject>

ref class ShellLibraryWrapper : public QObject
{
    Q_OBJECT

public:
    Q_INVOKABLE void runCommand(QString command, QString count, QString hideWindow, bool async, bool useDataflow, bool showProgress);
};
```

### ShellLibraryWrapper.cpp

```cpp
#include "ShellLibraryWrapper.h"
#include "ShellLibrary.h"

void ShellLibraryWrapper::runCommand(QString command, QString count, QString hideWindow, bool async, bool useDataflow, bool showProgress)
{
    // 调用 C# 类库的 RunCommand 方法
    ShellLibrary::Shell::RunCommand(command.toStdString(), count.toStdString(), hideWindow.toStdString(), async, useDataflow, showProgress);
}
```

然后，在 QML 项目中使用该封装库：

### main.qml

```qml
import QtQuick 2.15
import QtQuick.Controls 2.15

ApplicationWindow {
    visible: true
    width: 400
    height: 400
    title: "Shell Command Runner"

    Button {
        text: "Run Command"
        anchors.centerIn: parent
        onClicked: {
            // 调用 C# 类库的方法
            shellWrapper.runCommand("your_command_here", "1", "false", false, false, false);
        }
    }

    // 引入封装库
    ShellLibraryWrapper {
        id: shellWrapper
    }
}
```

在这个示例中，我们创建了一个按钮来触发调用 C# 类库的方法。通过封装库的 QML 接口，实现了从 QML 中调用 C# 类库的功能。

请确保将 C++/CLI 封装库编译为可供 QML 使用的库，并在 QML 项目中正确引用和使用该库。这样就能够在 QML 中使用 C# 类库的功能了。