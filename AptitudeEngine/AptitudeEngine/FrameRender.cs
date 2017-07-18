using System;
using System.Drawing;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace AptitudeEngine
{
    public static class FrameRender
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
                int red = int.Parse((decimal.Multiply(255, (decimal)bkColor[0])).ToString("0"));
                int green = int.Parse((decimal.Multiply(255, (decimal)bkColor[1])).ToString("0"));
                int blue = int.Parse((decimal.Multiply(255, (decimal)bkColor[2])).ToString("0"));
                return Color.FromArgb(red, green, blue);
            }
            set
            {
                GL.Color4(value);
            }
        }
        #endregion

        public static void RenderFrame(FrameEventArgs frameArgs)
        {
            Clear();

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
