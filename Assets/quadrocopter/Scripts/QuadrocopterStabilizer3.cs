using UnityEngine;
using System.Collections;

namespace Quadrocopter
{
    public class QuadrocopterStabilizer3 : MonoBehaviour
    {

        public GameObject Sensor;

        public GameObject Target;

        QuadrocopterStabilizer1 quadrocopterStabilizer1;
        QuadrocopterStabilizer2 quadrocopterStabilizer2;

        public float PX;
        public float PY;
        public float PZ;

        PIDStabilizer pidX = new PIDStabilizer();
        PIDStabilizer pidY = new PIDStabilizer();
        PIDStabilizer pidZ = new PIDStabilizer();

        // Use this for initialization
        void Start()
        {
            quadrocopterStabilizer1 = GetComponent<QuadrocopterStabilizer1>();
            quadrocopterStabilizer2 = GetComponent<QuadrocopterStabilizer2>();
            pidX.P = PX;
            pidY.P = PY;
            pidZ.P = PZ;
            quadrocopterStabilizer1.Target.Yaw = 0;
        }

        
        void FixedUpdate()
        {
            var dt = Time.fixedDeltaTime;
            quadrocopterStabilizer2.ForwardTarget = -pidZ.Update(Sensor.transform.position.z, Target.transform.position.z, dt).Limit(-1, 1);
            quadrocopterStabilizer2.SideTarget = -pidZ.Update(Sensor.transform.position.x, Target.transform.position.x, dt).Limit(-1, 1);
            quadrocopterStabilizer2.VerticalTarget = -pidZ.Update(Sensor.transform.position.y, Target.transform.position.y, dt).Limit(-1,1);
        }
    }
}