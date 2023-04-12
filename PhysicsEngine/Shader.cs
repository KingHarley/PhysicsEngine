using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsEngine
{
    internal class Shader
    {
        int Handle;
        int VertexHandle;
        int FragmentHandle;
        public Shader(string vertexShaderFile, string fragmentShaderFile)
        {
            VertexHandle = GL.CreateShader(ShaderType.VertexShader);
            var vertexSource = File.ReadAllText(vertexShaderFile);
            GL.ShaderSource(VertexHandle, vertexSource);

            FragmentHandle = GL.CreateShader(ShaderType.FragmentShader);
            var fragmentSource = File.ReadAllText(fragmentShaderFile);
            GL.ShaderSource(FragmentHandle, fragmentSource);

            GL.CompileShader(VertexHandle);
        }
    }
}
