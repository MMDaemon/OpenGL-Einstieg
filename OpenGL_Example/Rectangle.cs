using System.Drawing;
using OpenTK;

namespace OpenGL_Example
{
    public class Rectangle
    {
        private Vector2 _position;
        private float _size;

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public float Size
        {
            get => _size;
            set => _size = value;
        }

        public Color Color { get; set; }

        public Rectangle(Vector2 position, float size, Color color)
        {
            _position = position;
            _size = size;
            Color = color;
        }
    }
}
