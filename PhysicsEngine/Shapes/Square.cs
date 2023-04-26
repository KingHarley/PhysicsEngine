using OpenTK.Graphics.ES11;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsEngine.Shapes
{
    internal class Square : Shape
    {
        public Square(Vector2 pos, float size, Vector2 vel) : base(CreateVertices(pos, size), new uint[] { 0, 1, 3, 1, 2, 3 }, vel)
        { }

        private static float[] CreateVertices(Vector2 pos, float size)
        {
            return new float[]
            {
                pos.X - size, pos.Y + size, 0,
                pos.X + size, pos.Y + size, 0,
                pos.X + size, pos.Y - size, 0,
                pos.X - size, pos.Y - size, 0
            };
        }
    }
}
