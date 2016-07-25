using UnityEngine;
using System.Collections;
using System;

namespace Quadrocopter
{
    public class QuadrocopterStabilizer1 : MonoBehaviour
    {
        #region[Coefficients]
        public float PP = 0;
        public float IP = 0;
        public float DP = 0;
        public float PR = 0;
        public float IR = 0;
        public float DR = 0;
        public float PY = 0;
        public float IY = 0;
        public float DY = 0;
        #endregion
        public float Throttle = 0;
        public Target Target = new Target();
        public GameObject Sensor;

        Sensor sensor;
        PIDStabilizer pitch;
        PIDStabilizer roll;
        PIDStabilizer yaw;
        
        QuadrocopterController quadrocopterController;
        // Use this for initialization
        void Start()
        {
            quadrocopterController = gameObject.GetComponent<QuadrocopterController>();
            sensor = new Sensor(Sensor);
            pitch = new PIDStabilizer { P = PP, I = IP, D = DP };
            roll = new PIDStabilizer { P = PR, I = IR, D = DR };
            yaw = new PIDStabilizer { P = PY, I = IY, D = DY };
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            UpdateCoefficients();
            var dt = Time.fixedDeltaTime;
            var pitchResult = pitch.Update(sensor.Pitch, Target.Pitch, dt);
            var rollResult = roll.Update(sensor.Roll, Target.Roll, dt);
            var yawResult = yaw.Update(sensor.Yaw, Target.Yaw, dt);
            var throttles = new Throttles();
            SumResults(ref throttles, pitchResult, rollResult, yawResult);
            SetEngineThrottles(ref throttles);
            
        }

        private void SumResults(ref Throttles throttles, float pitchResult, float rollResult, float yawResult)
        {
            throttles.LBC = Throttle - pitchResult - rollResult - yawResult;
            throttles.LFW = Throttle + pitchResult - rollResult + yawResult;
            throttles.RBW = Throttle - pitchResult + rollResult + yawResult;
            throttles.RFC = Throttle + pitchResult + rollResult - yawResult;
        }

        private void SetEngineThrottles(ref Throttles throttles)
        {
            quadrocopterController.LBCEngineThrottle = throttles.LBC;
            quadrocopterController.LFWEngineThrottle = throttles.LFW;
            quadrocopterController.RBWEngineThrottle = throttles.RBW;
            quadrocopterController.RFCEngineThrottle = throttles.RFC;
        }

        private void UpdateCoefficients()
        {
            pitch.P = PP;
            pitch.I = IP;
            pitch.D = DP;
            roll.P = PR;
            roll.I = IR;
            roll.D = DR;
            yaw.P = PY;
            yaw.I = IY;
            yaw.D = DY;
        }

        struct Throttles
        {
            public float LFW;
            public float RFC;
            public float LBC;
            public float RBW;
        }
    }
}