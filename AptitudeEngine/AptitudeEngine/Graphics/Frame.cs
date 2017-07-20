using System;
using System.Drawing;
using System.Collections.Generic;

using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace AptitudeEngine
{
    public static class Frame
    {
        #region Coloring
        /// <summary>
        /// This is the color that is used to clear the screen at the beginning of each frame.
        /// </summary>
        public static Color ClearColor
        {
            get
            {
                float[] bkColor = new float[3];
                GL.GetFloat(GetPName.ColorClearValue, bkColor);
                int red = int.Parse((255f * bkColor[0]).ToString("0"));
                int green = int.Parse((255f * bkColor[1]).ToString("0"));
                int blue = int.Parse((255f * bkColor[2]).ToString("0"));
                return Color.FromArgb(red, green, blue);
            }
            set
            {
                GL.ClearColor(value);
            }
        }
        #endregion

        #region States
        public static KeyboardState KeyboardState
        {
            get
            {
                return Keyboard.GetState();
            }
        }
        #endregion

        public static void RenderFrame(FrameEventArgs frameArgs)
        {
            //Clear Screen
            Clear();

            Draw.SelectedVectors = new List<Vector2>()
            {
                new Vector2(-25,-25),
                new Vector2(-50,25),
                new Vector2(0, 100),
                new Vector2(50,25),
                new Vector2(25,-25)
            };
            Draw.SelectedColors = new List<Color>()
            {
                Color.Red,
                Color.Green,
                Color.Blue,
                Color.Yellow,
                Color.Orange
            };
            Draw.Poly();

            Draw.Tex(GraphicsHandler.GetTexture("tex1"), 50, 50, 100, 100);

            //Finish and clean frame
            EndFrame();
        }

        public static void Clear()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
        }

        public static void EndFrame()
        {
            GL.Flush();
        }
    }
}
