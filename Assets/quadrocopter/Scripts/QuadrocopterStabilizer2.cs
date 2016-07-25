using UnityEngine;
using System.Collections;
using System;

namespace Quadrocopter
{
    public class QuadrocopterStabilizer2 : MonoBehaviour
    {
        public GameObject Sensor;
        #region[Coefficients]
        public float PV = 0;
        public float IV = 0;
        public float DV = 0;
        public float PF = 0;
        public float IF = 0;
        public float DF = 0;
        public float PS = 0;
        public float IS = 0;
        public float DS = 0;
        #endregion
        public float VerticalTarget = 0;
        public float ForwardTarget = 0;
        public float SideTarget = 0;

        PIDStabilizer vertical;
        PIDStabilizer forward;
        PIDStabilizer side;

        SpeedSensor speedSensor;
        //temp for log
        public SpeedSensor SpeedSensor
        {
            get
            {
                return speedSensor;
            }
        }

        QuadrocopterStabilizer1 quadrocopterStabilizer1;
        // Use this for initialization
        void Start()
        {
            speedSensor = new SpeedSensor(Sensor, gameObject.GetComponent<Rigidbody>());
            vertical = new PIDStabilizer { P = PV, I = IV, D = DV };
            forward = new PIDStabilizer { P = PF, I = IF, D = DF };
            side = new PIDStabilizer { P = PS, I = IS, D = DS };
            quadrocopterStabilizer1 = GetComponent<QuadrocopterStabilizer1>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            UpdateCoefficients();
            var dt = Time.fixedDeltaTime;
            quadrocopterStabilizer1.Throttle = -vertical.Update(speedSensor.Vertical, VerticalTarget, dt);
            quadrocopterStabilizer1.Target.Pitch = -forward.Update(speedSensor.Forward, ForwardTarget, dt).Limit(-20, 20);
            quadrocopterStabilizer1.Target.Roll = -side.Update(speedSensor.Side, SideTarget, dt).Limit(-20, 20);

        }

        private void UpdateCoefficients()
        {
            vertical.P = PV;
            vertical.I = IV;
            vertical.D = DV;
            forward.P = PF;
            forward.I = IF;
            forward.D = DF;
            side.P = PS;
            side.I = IS;
            side.D = DS;
        }
    }
}