using UnityEngine;
using System.Collections;

namespace Quadrocopter
{
    public class PIDStabilizer
    {

        public float P { private get; set; }
        public float I { private get; set; }
        public float D { private get; set; }
        float sumErrors = 0;
        float oldValue = 0;
        public float Update(float sensor, float target, float dt)
        {
            var error = sensor - target;
            sumErrors += error;
            var result = (error * P) + (D * ((error - oldValue) / dt)) + (I * sumErrors * dt);
            oldValue = error;
            return result;
        }
    }

}