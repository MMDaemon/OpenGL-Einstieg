using OpenTK;

namespace OpenGLExample
{
    class Rectangle
    {
        private Vector2 _position;

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public float Size { get; set; }

        public Rectangle(Vector2 position, float size)
        {
            _position = position;
            Size = size;
        }
    }
}
