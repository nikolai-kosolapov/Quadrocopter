using UnityEngine;
using System.Collections;

namespace Quadrocopter
{
    public class Target
    {
        private float pitch = 0;
        public float Pitch
        {
            get
            {
                return pitch;
            }
            set
            {
                if (value < 180 && value > -180) pitch = value;
            }
        }
        private float roll = 0;
        public float Roll
        {
            get
            {
                return roll;
            }
            set
            {
                if (value < 180 && value > -180) roll = value;
            }
        }
        private float yaw = 0;
        public float Yaw
        {
            get
            {
                return yaw;
            }
            set
            {
                if (value < 180 && value > -180) yaw = value;
            }
        }
    }
}


