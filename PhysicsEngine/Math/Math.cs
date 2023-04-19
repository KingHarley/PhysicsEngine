using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsEngine
{
    static internal class Math
    {
        public static float Radians(float degrees) =>
            (float)(degrees * System.Math.PI / 180);
    }
}
