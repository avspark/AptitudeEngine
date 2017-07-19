using System;
using System.Drawing;
using System.Collections.Generic;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;

namespace AptitudeEngine
{
    public class Window : GameWindow
    {
        #region CameraManagement
        public List<Camera> Cameras = new List<Camera>();

        private int _CurrentCamera = 0;
        public int CurrentCamera
        {
            get
            {
                return _CurrentCamera;
            }
            set
            {
                if (Cameras.Count == 0)
                {
                    return;
                }

                if (value > Cameras.Count - 1)
                {
                    return;
                }

                Cameras[_CurrentCamera].Stop();
                _CurrentCamera = value;
                Cameras[_CurrentCamera].Start();
            }
        }

        public void CreateCamera(float x, float y, float width, float height)
        {
            Camera c = new Camera(width, height, x, y);
            Cameras.Add(c);
        }
        #endregion

        public Window(int x, int y) : base (x, y, GraphicsMode.Default, "Aptitude Engine", GameWindowFlags.FixedWindow, DisplayDevice.Default)
        {
            Frame.ClearColor = Color.CornflowerBlue;
            Frame.CurrentColor = Color.DarkBlue;

            CreateCamera(0, 0, 100, 100);
            CreateCamera(0, 0, 75, 75);
            CurrentCamera = 0;
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

            if (Frame.KeyboardState[Key.Number1])
            {
                CurrentCamera = 0;
            }
            if (Frame.KeyboardState[Key.Number2])
            {
                CurrentCamera = 1;
            }
            
            this.SwapBuffers();
        }
    }
}
