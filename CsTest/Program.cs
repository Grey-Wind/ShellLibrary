using ShellLibrary;

namespace CsTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shell.RunCommand("ipconfig", "2", "false", false, false, false);
            Shell.RunCommand("pause");
        }
    }
}
