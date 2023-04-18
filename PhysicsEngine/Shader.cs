using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsEngine
{
    internal class Shader : IDisposable
    {
        int Handle;
        public Shader(string vertexShaderFile, string fragmentShaderFile)
        {
            int vertexHandle = GL.CreateShader(ShaderType.VertexShader);
            var vertexSource = File.ReadAllText(vertexShaderFile);
            GL.ShaderSource(vertexHandle, vertexSource);

            int fragmentHandle = GL.CreateShader(ShaderType.FragmentShader);
            var fragmentSource = File.ReadAllText(fragmentShaderFile);
            GL.ShaderSource(fragmentHandle, fragmentSource);

            GL.CompileShader(vertexHandle);
            GL.GetShader(vertexHandle, ShaderParameter.CompileStatus, out int vertexStatus);

            if (vertexStatus == 0)
                throw new Exception($"Could not compile vertex shader: {GL.GetShaderInfoLog(vertexHandle)}");

            GL.CompileShader(fragmentHandle);
            GL.GetShader(fragmentHandle, ShaderParameter.CompileStatus, out int fragmentStatus);

            if (fragmentStatus == 0)
                throw new Exception($"Could not compile fragment shader: {GL.GetShaderInfoLog(fragmentHandle)}");

            Handle = GL.CreateProgram();
            GL.AttachShader(Handle, fragmentHandle);
            GL.AttachShader(Handle, vertexHandle);

            GL.LinkProgram(Handle);
            GL.GetProgram(Handle, GetProgramParameterName.LinkStatus, out int programStatus);

            Console.WriteLine(GL.GetProgramInfoLog(Handle));
            if (programStatus == 0)
                throw new Exception($"Could not link program: {GL.GetProgramInfoLog(Handle)}");

            GL.DetachShader(Handle, fragmentHandle);
            GL.DetachShader(Handle, vertexHandle);
            GL.DeleteShader(fragmentHandle);
            GL.DeleteShader(vertexHandle);
        }

        public void Use()
        {
            GL.UseProgram(Handle);
        }

        public void Dispose()
        {
            GL.DeleteProgram(Handle);
        }
    }
}
