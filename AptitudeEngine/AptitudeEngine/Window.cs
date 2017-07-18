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
            FrameRender.ClearColor = Color.FromArgb(13, 15, 50);
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

            FrameRender.RenderFrame(e);

            this.Title = "Clear Color: RGB(" + FrameRender.ClearColor.R + "," + FrameRender.ClearColor.G + ","+ FrameRender.ClearColor.B + ")";
            this.SwapBuffers();
        }
    }
}
