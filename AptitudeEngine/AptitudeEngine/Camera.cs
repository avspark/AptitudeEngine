using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace AptitudeEngine
{
    public class Camera
    {
        public Vector2 Position
        {
            get;
            set;
        }
        public Vector2 Size
        {
            get;
            set;
        }
        public Matrix4 Projection;

        private bool enabled = false;

        public Camera(float width, float height, float x, float y)
        {
            Size = new Vector2(width, height);
            Projection = Matrix4.CreateOrthographic(width, -height, 0, 100);
            Position = new Vector2(-x, -y);
        }

        public void SetPosition(Vector2 pos)
        {
            SetPosition(pos.X, pos.Y);
        }

        public void SetPosition(float x, float y)
        {
            this.Position = new Vector2(x, y);
            if (!enabled) return;
            GL.LoadMatrix(ref Projection);
            GL.Translate(new Vector3(x, y, 0));
        }

        public void Move(float x, float y)
        {
            SetPosition(Position.X + -x, Position.Y + -y);
        }

        public void Start()
        {
            enabled = true;
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref Projection);
            SetPosition(Position);
        }

        public void Stop()
        {
            enabled = false;
        }

        public Matrix4 GetMatrix()
        {
            return Projection;
        }
    }
}