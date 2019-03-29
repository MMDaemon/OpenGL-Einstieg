using System;
using System.Collections.Generic;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace OpenGLExample
{
    public class MyWindow : GameWindow
    {
        private List<Rectangle> _rectangles;
        private Random _random;
        private KeyboardState _keyboard;

        private bool _wasSpacePressed = false;

        public MyWindow()
        {
            _rectangles = new List<Rectangle>();
            _random = new Random();
            _keyboard = new KeyboardState(this);

            InitializeRectangles();

            GL.ClearColor(Color.Blue);
            GL.Color3(Color.Red);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);

            foreach (Rectangle rectangle in _rectangles)
            {
                DrawRectangle(rectangle.Position, rectangle.Size);
            }

            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            if (_keyboard.IsKeyPressed(Key.Space) && !_wasSpacePressed)
            {
                InitializeRectangles();
            }

            _wasSpacePressed = _keyboard.IsKeyPressed(Key.Space);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);
        }

        private void DrawRectangle(Vector2 position, float size)
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex2(position + new Vector2(-size / 2, -size / 2));
            GL.Vertex2(position + new Vector2(size / 2, -size / 2));
            GL.Vertex2(position + new Vector2(size / 2, size / 2));
            GL.Vertex2(position + new Vector2(-size / 2, size / 2));
            GL.End();
        }

        private void InitializeRectangles()
        {
            _rectangles.Clear();

            for (int i = 0; i < 10; i++)
            {
                _rectangles.Add(new Rectangle(new Vector2((float)_random.NextDouble() * 2 - 1, (float)_random.NextDouble() * 2 - 1), (float)_random.NextDouble() * 0.49f + 0.01f));
            }
        }
    }
}
