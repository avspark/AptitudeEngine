using System;
using System.Collections;
using System.IO;

namespace AptitudeEngine
{
    public static class GraphicsHandler
    {
        private static Hashtable Textures = new Hashtable();

        public static void AddTexture(Texture2D tex)
        {
            Textures.Add(tex.Name, tex);
        }

        public static Texture2D GetTexture(string texName)
        {
            if (texName != null)
            {
                if (Textures.ContainsKey(texName))
                {
                    return (Texture2D)Textures[texName];
                }
                else
                {
                    return new Texture2D(0, 0, 0, "");
                }
            }
            else
            {
                Environment.Exit(0);
                return new Texture2D(0, 0, 0, "");
            }
        }

        public static void Begin(string texLoadPath)
        {
            foreach (string s in Directory.GetFiles(texLoadPath + "\\"))
            {
                if (s.EndsWith(".png"))
                {
                    AddTexture(ContentPipe.LoadTextureFromPath(s));
                }
            }
        }
    }
}
