using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;

using Newtonsoft.Json;

namespace AptitudeEngine
{
    public class Window : GameWindow
    {
        #region CameraManagement
        public List<Camera> Cameras = new List<Camera>();

        private int _CurrentCameraID = 0;
        public int CurrentCameraID
        {
            get
            {
                return _CurrentCameraID;
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

                Cameras[_CurrentCameraID].Stop();
                _CurrentCameraID = value;
                Cameras[_CurrentCameraID].Start();
            }
        }

        public void CreateCamera(float x, float y, float width, float height)
        {
            Camera c = new Camera(width, height, x, y);
            Cameras.Add(c);
        }

        public Camera CurrentCamera
        {
            get
            {
                return Cameras[CurrentCameraID];
            }
        }
        #endregion

        GameSettings settings;

        public Window(int width, int height) : base (width, height, GraphicsMode.Default, "Aptitude Engine", GameWindowFlags.FixedWindow, DisplayDevice.Default)
        {
            Frame.ClearColor = Color.CornflowerBlue;

            CreateCamera(0, 0, 100, 100);
            CreateCamera(0, 0, 75, 75);
            CreateCamera(0, 50, 250, 250);
            CreateCamera(50, 50, 250, 250);
            CurrentCameraID = 0;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //Load Settings from JSon file "Settings.json"
            Newtonsoft.Json.Linq.JObject jo = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(File.ReadAllText("Settings.json"));
            settings = jo.ToObject<GameSettings>();

            //Set window properties
            this.Width = settings.WindowWidth;
            this.Height = settings.WindowHeight;
            this.Title = settings.Title;

            //Load Textures
            GraphicsHandler.Begin(settings.TexturePath);
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
                CurrentCameraID = 0;
            }
            if (Frame.KeyboardState[Key.Number2])
            {
                CurrentCameraID = 1;
            }
            if (Frame.KeyboardState[Key.Number3])
            {
                CurrentCameraID = 2;
            }
            if (Frame.KeyboardState[Key.Number4])
            {
                CurrentCameraID = 3;
            }

            if (Frame.KeyboardState[Key.W])
            {
                CurrentCamera.Move(0, -1);
            }
            if (Frame.KeyboardState[Key.A])
            {
                CurrentCamera.Move(-1, 0);
            }
            if (Frame.KeyboardState[Key.S])
            {
                CurrentCamera.Move(0, 1);
            }
            if (Frame.KeyboardState[Key.D])
            {
                CurrentCamera.Move(1, 0);
            }

            this.SwapBuffers();
        }
    }
}
