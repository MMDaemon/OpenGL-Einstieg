using System;
using System.Drawing;
using OpenTK;

namespace OpenGLExample
{
    class Box
    {
        private Vector2 _position;

        public Vector2 Position
        {
            get { return new Vector2(_position.X / Aspect, _position.Y); }
            set { _position = value; }
        }

        public float Aspect { private get; set; }

        public float Size { get; set; }
        public Color Color { get; set; }

        public Box(Random random, float aspect)
        {
            _position = new Vector2((float)random.NextDouble(), (float)random.NextDouble()) * 2 - Vector2.One;
            Aspect = aspect;
            Size = (float)random.NextDouble() / 2;
            Color = Color.Red;
        }
    }
}
