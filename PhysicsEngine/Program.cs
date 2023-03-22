using OpenTK.Windowing.Desktop;

namespace PhysicsEngine
{
    internal class Program
    {
        static void Main()
        {
            var nwsettings = NativeWindowSettings.Default;
            using var gw = new Window(GameWindowSettings.Default, NativeWindowSettings.Default);
            gw.Run();
        }
    }
}