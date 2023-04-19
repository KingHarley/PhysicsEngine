using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using PhysicsEngine.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsEngine
{
    internal class Window : GameWindow
    {
        private Shader Shader = null!;
        private List<Triangle> Triangles = new List<Triangle>();
        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
            Shader = new Shader("shader.vert", "shader.frag");
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
            if(IsKeyPressed(OpenTK.Windowing.GraphicsLibraryFramework.Keys.Escape))
                Close();
        }

        protected override void OnLoad()
        {
            base.OnLoad();
            GL.ClearColor(Color4.Black);
            Triangles.Add(new Triangle(new System.Numerics.Vector2(0.0f, 0.0f), 0.25f));
            Triangles.Add(new Triangle(new System.Numerics.Vector2(0.2f, 0.2f), 0.1f));
            Shader.Use();
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            Shader.Use();
            foreach (var tr in Triangles)
                tr.Draw();

            SwapBuffers();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, e.Width, e.Height);
        }

        protected override void OnUnload()
        {
            base.OnUnload();
            Shader.Dispose();
        }
    }
}
