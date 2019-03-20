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
        private float _aspect;
        private Random _random;
        private KeyboardState _keyboard;

        private List<Box> _boxes;

        private bool _wasSpacePressed = false;

        public MyWindow()
        {
            _random = new Random();
            _boxes = new List<Box>();
            _keyboard = new KeyboardState(this);

            InitializeBoxes();

            GL.ClearColor(Color.CornflowerBlue);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);

            foreach (var box in _boxes)
            {
                DrawRectangle(box.Position, box.Size, box.Color);
            }



            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            if (_keyboard.IsKeyPressed(Key.Space) &&!_wasSpacePressed)
            {
                InitializeBoxes();
            }

            _wasSpacePressed = _keyboard.IsKeyPressed(Key.Space);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);
            _aspect = (float)Height / Width;

            GL.LoadIdentity();
            GL.Scale(_aspect, 1f, 1f);

            foreach (var box in _boxes)
            {
                box.Aspect = _aspect;
            }
        }

        private void DrawRectangle(Vector2 position, float size, Color color)
        {
            GL.Color3(color);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex2(position + new Vector2(-size / 2, -size / 2));
            GL.Vertex2(position + new Vector2(size / 2, -size / 2));
            GL.Vertex2(position + new Vector2(size / 2, size / 2));
            GL.Vertex2(position + new Vector2(-size / 2, size / 2));
            GL.End();
        }

        private void InitializeBoxes()
        {
            _boxes.Clear();

            for (int i = 0; i < 10; i++)
            {
                _boxes.Add(new Box(_random, _aspect));
            }
        }
    }
}
