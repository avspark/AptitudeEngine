using System;
using System.Drawing;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;

namespace AptitudeEngine
{
    public class Window : GameWindow
    {
        private Camera camera1, camera2;

        public Window(int x, int y) : base (x, y, GraphicsMode.Default, "Aptitude Engine", GameWindowFlags.FixedWindow, DisplayDevice.Default)
        {
            Frame.ClearColor = Color.FromArgb(13, 15, 50);
            camera1 = new Camera(x, y, -(x/2), -(y/2));
            camera2 = new Camera(x, y, -100, -100);
            camera1.install();

            Frame.ClearColor = Color.FromArgb(13, 15, 50);
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

            Frame.RenderFrame(e);

            camera1.move(1, 1);

            var state = OpenTK.Input.Keyboard.GetState();

            if (state[Key.L])
            {
                camera1.disable();
                camera2.install();
            }

            if(state[Key.K])
            {
                camera2.disable();
                camera1.install();
            }

            this.Title = "Clear Color: RGB(" + Frame.ClearColor.R + "," + Frame.ClearColor.G + ","+ Frame.ClearColor.B + ")";
            this.SwapBuffers();
        }
    }
}
