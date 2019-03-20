
using OpenTK;

namespace OpenGLExample
{
    class Program
    {
        static void Main(string[] args)
        {
            MyWindow window = new MyWindow();
            window.WindowState = WindowState.Maximized;
            window.Run();
        }
    }
}
