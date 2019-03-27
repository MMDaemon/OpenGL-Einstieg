using System.Drawing;

namespace OpenGL_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            MyWindow window = new MyWindow();

            window.Size = new Size(600, 600);

            window.Run();
        }
    }
}
