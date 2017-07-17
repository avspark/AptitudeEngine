using System;
using OpenTK;

namespace AptitudeEngine
{
    public class AptitudeEngine
    {
        public AptitudeEngine()
        {

        }
        
        public void StartWindow(int width, int height, VSyncMode VSync)
        {
            Window mainGameWindow = new Window(width, height);
            mainGameWindow.VSync = VSync;
            mainGameWindow.Title = "Aptitude Engine";
            mainGameWindow.Run();
        }
    }
}
