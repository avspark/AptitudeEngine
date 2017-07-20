using System;

namespace AptitudeEngine
{
    public struct Texture2D
    {
        public int Width
        {
            get;
            private set;
        }
        public int Height
        {
            get;
            private set;
        }

        public int ID
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }

        public Texture2D(int id, int width, int height, string name)
        {
            this.ID = id;
            this.Width = width;
            this.Height = height;
            this.Name = name;
        }
    }
}
