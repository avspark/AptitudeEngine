using System;
using System.Drawing;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace AptitudeEngine
{
    public class Window : GameWindow
    {
        public Window(int x, int y) : base (x, y, GraphicsMode.Default, "Aptitude Engine", GameWindowFlags.FixedWindow, DisplayDevice.Default)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.ClearColor(Color.CornflowerBlue);
            GL.Clear(ClearBufferMask.ColorBufferBit);


            GL.Flush();
            this.SwapBuffers();
        }
    }
}
