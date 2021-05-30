using System;
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;


namespace Practico3
{
    public static class Program
    {
        private static void Main()
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new Vector2i(900, 900),
                Title = "LearnOpenTK - Creating a Window",
            };

            using (var window = new Window(GameWindowSettings.Default, nativeWindowSettings))
            {
                window.Run();
            }
        }
    }
}