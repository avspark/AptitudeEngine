using System;

namespace AptitudeEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            AptitudeEngine ae = new AptitudeEngine();
            ae.StartWindow(500, 500, OpenTK.VSyncMode.On);
        }
    }
}
