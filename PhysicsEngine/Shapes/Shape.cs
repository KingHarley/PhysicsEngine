using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsEngine.Shapes
{
    internal class Shape : IShape
    {
        public readonly float[] Vertices;
        private int VertexArrayObject;
        private int VertexBufferObject;
        private const int NumberOfVertices = 3;

        public Shape(float[] vertices)
        {
            Vertices = vertices;
            Setup();
        }

        private void Setup()
        {
            VertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(VertexArrayObject);

            VertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, Vertices.Length * sizeof(float), Vertices, BufferUsageHint.StaticDraw);

            GL.VertexAttribPointer(0, NumberOfVertices, VertexAttribPointerType.Float, false, NumberOfVertices * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
        }

        public void Draw()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
            GL.BindVertexArray(VertexArrayObject);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
        }
    }
}
