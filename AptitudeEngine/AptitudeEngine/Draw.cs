using System;
using System.Collections.Generic;
using System.Drawing;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace AptitudeEngine
{
    public static class Draw
    {
        public static List<Vector2> SelectedVectors = new List<Vector2>();
        public static List<Color> SelectedColors = new List<Color>();

        public static void Quad()
        {
            if (SelectedVectors.Count == 0 || SelectedColors.Count == 0)
            {
                return;
            }

            GL.Begin(PrimitiveType.Quads);

            Color loopColor = Color.White;

            int currentIndex = 0;
            foreach (Vector2 v in SelectedVectors)
            {
                if (currentIndex <= SelectedColors.Count - 1)
                {
                    loopColor = SelectedColors[currentIndex];
                }

                GL.Color4(loopColor);
                GL.Vertex2(v);

                currentIndex++;
            }

            GL.End();
        }
    }
}
