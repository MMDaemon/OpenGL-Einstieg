using System.Collections.Generic;
using OpenTK;
using OpenTK.Input;

namespace OpenGLExample
{
    public class KeyboardState
    {
        private readonly HashSet<Key> _pressedKeys;

        public KeyboardState(INativeWindow window)
        {
            _pressedKeys = new HashSet<Key>();
            window.KeyDown += Window_KeyDown;
            window.KeyUp += (sender, e) => _pressedKeys.Remove(e.Key);
        }

        private void Window_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            _pressedKeys.Add(e.Key);
        }

        public bool IsKeyPressed(Key key)
        {
            return _pressedKeys.Contains(key);
        }
    }
}
