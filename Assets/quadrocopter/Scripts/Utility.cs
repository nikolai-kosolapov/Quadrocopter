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

        public static float Looped(this float value, float min, float max)
        {
            if (value >= min && value <= max) return value;
            if (value < min) return max - min + value;
            return min + value - max;
        }
    }
}
