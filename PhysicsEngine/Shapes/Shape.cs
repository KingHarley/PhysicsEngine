using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsEngine.Shapes
{
    internal class Shape : IShape, IVelocity
    {
        private float[] Vertices;
        private readonly uint[] Indices;
        private Vector2 Velocity;
        private int VertexArrayObject;
        private int VertexBufferObject;
        private int ElementBufferObject;
        private const int NumberOfVertices = 3;

        public Shape(float[] vertices, uint[] indices, Vector2 velocity)
        {
            Vertices = vertices;
            Indices = indices;
            Velocity = velocity;
            Setup();
        }

        private void Setup()
        {
            VertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(VertexArrayObject);

            VertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, Vertices.Length * sizeof(float), Vertices, BufferUsageHint.DynamicDraw);

            ElementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ElementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, Indices.Length * sizeof(uint), Indices, BufferUsageHint.DynamicDraw);

            GL.VertexAttribPointer(0, NumberOfVertices, VertexAttribPointerType.Float, false, NumberOfVertices * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
            GL.BindVertexArray(0);
        }

        public void Draw()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, Vertices.Length * sizeof(float), Vertices, BufferUsageHint.DynamicDraw);
            GL.BindVertexArray(VertexArrayObject);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ElementBufferObject);
            GL.DrawElements(PrimitiveType.Triangles, Indices.Length, DrawElementsType.UnsignedInt, 0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
        }

        public void UpdatePosition()
        {
            Vertices = Vertices.Select((v, i) =>
            {
                var del = ((i + 1) % 3) switch
                {
                    0 => 0,
                    1 => Velocity.X,
                    2 => Velocity.Y,
                    _ => throw new Exception($"Invalid remainder on modulo detected when trying to Update shape position")
                };
                var newV = v + del;
                if (newV > 1)
                    return newV - 2;
                if (newV < -1)
                    return newV + 2;
                return newV;
            }).ToArray();
        }
    }
}
