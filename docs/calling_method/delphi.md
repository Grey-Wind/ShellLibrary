首先需要在Delphi中添加对ShellLibrary.dll的引用。这可以通过在Delphi项目中添加一个COM引用来实现。具体步骤如下：

1. 打开Delphi IDE并打开您的项目。
2. 在菜单栏中选择“Project” -> “Import Type Library”。
3. 在“Import Type Library”对话框中，选择“Microsoft .NET Framework”并单击“Next”。
4. 在“Available .NET Framework Assemblies”列表中选择“ShellLibrary”并单击“Add”。
5. 单击“Next”并按照向导完成设置。

完成以上步骤后，您就可以在Delphi代码中创建对Shell类的实例并调用RunCommand方法了。例如：

```delphi
var
  shell: ShellLibrary.Shell;
begin
  shell := ShellLibrary.Shell.Create;
  shell.RunCommand('ping www.google.com', '1', 'false', False, False, False);
end;
```
