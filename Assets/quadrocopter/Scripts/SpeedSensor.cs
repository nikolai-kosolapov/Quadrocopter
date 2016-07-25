using UnityEngine;
using System.Collections;
namespace Quadrocopter
{
    public class SpeedSensor
    {

        Rigidbody rigidbody;
        GameObject sensor;

        public SpeedSensor(GameObject snsr, Rigidbody rb)
        {
            rigidbody = rb;
            sensor = snsr;
        }

        public float Vertical
        {
            get
            {
                return rigidbody.velocity.y;
            }
        }

        public float Forward
        {
            get
            {
                return sensor.transform.InverseTransformVector(rigidbody.velocity).z;
            }
        }

        public float Side
        {
            get
            {
                return sensor.transform.InverseTransformVector(rigidbody.velocity).x;
            }
        }
    }
}