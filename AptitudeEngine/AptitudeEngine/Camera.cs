using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace AptitudeEngine
{
    class Camera
    {
        private Vector2 position;
        private Matrix4 projection;

        private bool enabled = false;

        public Camera(float width, float height, float x, float y)
        {
            projection = Matrix4.CreateOrthographic(width, height, 0, 100);
            position = new Vector2(x, y);
        }

        public void setPosition(Vector2 pos)
        {
            if (!enabled) return;
            this.position = pos;
            GL.LoadMatrix(ref projection);
            GL.Translate(new Vector3(pos.X, pos.Y, 0));
        }

        public void setPosition(float x, float y)
        {
            setPosition(new Vector2(x, y));
        }

        public void move(float x, float y)
        {
            setPosition(position.X + x, position.Y + y);
        }

        public void install()
        {
            enabled = true;
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
            setPosition(position);
        }

        public void disable()
        {
            enabled = false;
        }

        public Matrix4 getProjectionMatrix()
        {
            return projection;
        }
    }
}
