using System;
using System.Numerics;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsEngine.Shapes
{
    internal class Triangle : Shape
    {
        public Triangle(Vector2 position, float size) : base(CreateVertices(position, size))
        { }

        private static float[] CreateVertices(Vector2 position, float size)
        {
                var centre = new Vector3(position.X, position.Y, 0);
                var top = new Vector3(centre.X, centre.Y + size, 0);
                var dx = size * (float)System.Math.Cos(Math.Radians(30));
                var dy = size * (float)System.Math.Sin(Math.Radians(30));
                var left = new Vector3(centre.X - dx, centre.Y - dy, 0);
                var right = new Vector3(centre.X + dx, centre.Y - dy, 0);

                return new float[] { top.X, top.Y, top.Z, left.X, left.Y, left.Z, right.X, right.Y, right.Z };
        }
    }
}
