using UnityEngine;
using System.Collections;

namespace Quadrocopter
{
    public static class Utility
    {

        public static float Limit(this float value, float min, float max)
        {
            if (value > max)
                return max;
            if (value < min)
                return min;
            return value;
        }
    }
}
