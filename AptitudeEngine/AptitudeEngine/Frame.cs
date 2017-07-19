using System;
using System.Drawing;

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

        /// <summary>
        /// This is the color used for drawing shapes and attaching to textures.
        /// </summary>
        public static Color DrawColor
        {
            get
            {
                float[] bkColor = new float[3];
                GL.GetFloat(GetPName.CurrentColor, bkColor);
                int red = int.Parse((255f * bkColor[0]).ToString("0"));
                int green = int.Parse((255f * bkColor[1]).ToString("0"));
                int blue = int.Parse((255f * bkColor[2]).ToString("0"));
                return Color.FromArgb(red, green, blue);
            }
            set
            {
                GL.Color4(value);
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
            Clear();

            GL.Begin(PrimitiveType.Quads);
            GL.Vertex2(0, 0);
            GL.Vertex2(0, 25);
            GL.Vertex2(25, 25);
            GL.Vertex2(25, 0);
            GL.End();

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
