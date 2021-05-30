using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;


namespace Practico3
{

    public class Window : GameWindow
    {
        Silla silla;
        Silla silla1;
        Silla silla2;
        Silla silla3;

        private double _time;
        private Matrix4 _view;
        private Matrix4 _projection;

        Cubo cubo;

        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings)
        {
        }

        protected override void OnLoad()
        {
            
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            //GL.Enable(EnableCap.DepthTest);

            silla = new Silla(0.5f, 0.5f, 0.8f, 0.4f, 0.05f, 0, 0, 0);
            silla1 = new Silla(0.5f, 0.5f, 0.8f, 0.4f, 0.05f, 1, 1, 1);
            silla2 = new Silla(0.5f, 0.5f, 0.8f, 0.4f, 0.05f, 1, -1, 0);
            silla3 = new Silla(0.5f, 0.5f, 0.8f, 0.4f, 0.05f, -1, -1, 0);

            cubo = new Cubo(0.5f, 0.5f, 0.5f, 0, 0, 0);

            _view = Matrix4.CreateTranslation(0.0f, 0.0f, -3.0f);
            _projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45f), Size.X / (float)Size.Y, 0.1f, 100.0f);

            base.OnLoad();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            _time += 25.0 * e.Time;
            var model = Matrix4.Identity * Matrix4.CreateRotationY((float)MathHelper.DegreesToRadians(_time));
            var aux = model * _view;
            aux = aux * _projection;

            


            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            silla.draw(aux);
            silla1.draw(aux);
            silla2.draw(aux);
            silla3.draw(aux);


            SwapBuffers();

            base.OnRenderFrame(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            var input = KeyboardState;

            if (input.IsKeyDown(Keys.Escape))
            {
                Close();
            }

            base.OnUpdateFrame(e);
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            GL.Viewport(0, 0, Size.X, Size.Y);
            base.OnResize(e);
        }

        protected override void OnUnload()
        {
            silla.dispose();
            silla1.dispose();
            silla2.dispose();
            silla3.dispose();

            base.OnUnload();
        }
    }
}