using UnityEngine;
using System.Collections;

namespace Quadrocopter
{
    class Sensor
    {
        GameObject gameObject;

        public Sensor(GameObject gObject)
        {
            gameObject = gObject;
        }

        public float Pitch
        {
            get
            {
                var value = gameObject.transform.eulerAngles.x;
                return ConvertTo180(value);
            }
        }

        public float Roll
        {
            get
            {
                var value = gameObject.transform.eulerAngles.z;
                return -ConvertTo180(value);
            }
        }

        public float Yaw
        {
            get
            {
                var value = gameObject.transform.eulerAngles.y;
                return ConvertTo180(value);
            }
        }

        float ConvertTo180(float value)
        {
            if (value > 180) return value - 360;
            return value;
        }
    }
}