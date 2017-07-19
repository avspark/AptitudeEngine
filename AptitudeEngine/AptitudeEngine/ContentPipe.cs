using System;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;

using OpenTK.Graphics.OpenGL;

namespace SolarEngine.Texture
{
    public class ContentPipe
    {
        public static Texture2D LoadTexture(string path)
        {
            if (!File.Exists(path))
            {
                System.Windows.Forms.MessageBox.Show("File not found at '" + path + "'");
                Environment.Exit(0);
            }
            using (Bitmap bmp = new Bitmap(path))
            {
                return LoadTextureFromBitmap(bmp);
            }
        }

        public static Texture2D LoadTextureFromBitmap(Bitmap bmp)
        {
            int id = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, id);

            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly,
            System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

            bmp.UnlockBits(data);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)
                TextureWrapMode.Clamp);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)
                TextureWrapMode.Clamp);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter,
                (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter,
                (int)TextureMagFilter.Linear);

            int w = bmp.Width;
            int h = bmp.Height;
            bmp.Dispose();
            return new Texture2D(id, w, h);
        }
    }
}
