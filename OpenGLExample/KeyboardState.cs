using System.Collections.Generic;
using OpenTK;
using OpenTK.Input;

namespace OpenGLExample
{
    class KeyboardState
    {
        private HashSet<Key> _pushedKeys = new HashSet<Key>();

        public KeyboardState(INativeWindow window)
        {
            window.KeyDown += Window_KeyDown;
            window.KeyUp += (sender, e) => _pushedKeys.Remove(e.Key);
        }

        private void Window_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            _pushedKeys.Add(e.Key);
        }

        public bool IsKeyPressed(Key key)
        {
            return _pushedKeys.Contains(key);
        }
    }
}
