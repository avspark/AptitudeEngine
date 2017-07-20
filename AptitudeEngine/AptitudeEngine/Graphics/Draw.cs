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

        public static void Poly()
        {
            if (SelectedVectors.Count == 0 || SelectedColors.Count == 0)
            {
                return;
            }

            GL.Disable(EnableCap.Texture2D);
            GL.Begin(PrimitiveType.Polygon);

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

        public static void Tex(Texture2D tex)
        {
            if (SelectedVectors.Count < 4)
            {
                return;
            }

            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, tex.ID);
            GL.Color4(Color.Transparent);
            GL.Begin(PrimitiveType.Polygon);

            GL.TexCoord2(0, 0);
            GL.Vertex2(SelectedVectors[0]);

            GL.TexCoord2(1, 0);
            GL.Vertex2(SelectedVectors[1]);

            GL.TexCoord2(1, 1);
            GL.Vertex2(SelectedVectors[2]);

            GL.TexCoord2(0, 1);
            GL.Vertex2(SelectedVectors[3]);

            GL.End();
        }

        public static void Tex(Texture2D tex, float x, float y, float width, float height)
        {
            List<Vector2> vectors = ConvertRectangle(new RectangleF(x, y, width, height));

            if (vectors.Count < 4)
            {
                return;
            }

            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, tex.ID);
            GL.Color4(Color.Transparent);
            GL.Begin(PrimitiveType.Polygon);

            GL.TexCoord2(0, 0);
            GL.Vertex2(vectors[0]);

            GL.TexCoord2(1, 0);
            GL.Vertex2(vectors[1]);

            GL.TexCoord2(1, 1);
            GL.Vertex2(vectors[2]);

            GL.TexCoord2(0, 1);
            GL.Vertex2(vectors[3]);

            GL.End();
        }

        public static List<Vector2> ConvertRectangle(RectangleF r)
        {
            List<Vector2> toReturn = new List<Vector2>();

            toReturn.Add(new Vector2(r.X, r.Y));
            toReturn.Add(new Vector2(r.X + r.Width, r.Y));
            toReturn.Add(new Vector2(r.X + r.Width, r.Y + r.Height));
            toReturn.Add(new Vector2(r.X, r.Y + r.Height));

            return toReturn;
        } 
    }
}
