using System;

namespace AptitudeEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            AptitudeEngine ae = new AptitudeEngine();
            ae.StartWindow(750, 750, OpenTK.VSyncMode.On);
        }
    }
}
