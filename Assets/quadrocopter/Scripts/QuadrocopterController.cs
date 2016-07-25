using UnityEngine;
using System.Collections;
using System;

namespace Quadrocopter
{
    public class QuadrocopterController : MonoBehaviour
    {

        public GameObject LFWEngine;
        public GameObject RFCEngine;
        public GameObject LBCEngine;
        public GameObject RBWEngine;


        public int PowerFactor = 100;

        private Rigidbody rb;

        #region[Throttles]
        float lfwEngineThrottle;
        public float LFWEngineThrottle
        {
            set
            {
                if (value <= 0)
                {
                    lfwEngineThrottle = 0;
                }
                if (value >= 1)
                {
                    lfwEngineThrottle = 1;
                }

                if (value > 0 && value < 1)
                    lfwEngineThrottle = value;
            }
            private get
            {
                return lfwEngineThrottle;
            }
        }

        float rfcEngineThrottle;
        public float RFCEngineThrottle
        {
            set
            {
                if (value <= 0)
                    rfcEngineThrottle = 0;
                if (value >= 1)
                    rfcEngineThrottle = 1;
                if (value > 0 && value < 1)
                    rfcEngineThrottle = value;
            }
            private get
            {
                return rfcEngineThrottle;
            }
        }

        float lbcEngineThrottle;
        public float LBCEngineThrottle
        {
            set
            {
                if (value <= 0)
                    lbcEngineThrottle = 0;
                if (value >= 1)
                    lbcEngineThrottle = 1;
                if (value > 0 && value < 1)
                    lbcEngineThrottle = value;
            }
            private get
            {
                return lbcEngineThrottle;
            }
        }

        float rbwEngineThrottle;
        public float RBWEngineThrottle
        {
            set
            {
                if (value <= 0)
                    rbwEngineThrottle = 0;
                if (value >= 1)
                    rbwEngineThrottle = 1;
                if (value > 0 && value < 1)
                    rbwEngineThrottle = value;
            }
            private get
            {
                return rbwEngineThrottle;
            }
        }
        #endregion

        #region[Forces]
        float lfwEngineForce = 0;
        float rfcEngineForce = 0;
        float lbcEngineForce = 0;
        float rbwEngineForce = 0;
        #endregion
        // Use this for initialization
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }



        // Update is called once per frame
        void Update()
        {
            
        }

        public void FixedUpdate()
        {
            UpdateForces();
            AddPullForces();
            AddRotationForces();
        }

        private void UpdateForces()
        {
            var dt = Time.fixedDeltaTime;
            lfwEngineForce +=  ((LFWEngineThrottle - lfwEngineForce) / 0.25f) * dt;
            rfcEngineForce += ((RFCEngineThrottle - rfcEngineForce) / 0.25f) * dt;
            lbcEngineForce += ((LBCEngineThrottle - lbcEngineForce) / 0.25f) * dt;
            rbwEngineForce += ((RBWEngineThrottle - rbwEngineForce) / 0.25f) * dt;
        }

        private void AddRotationForces()
        {
            var lfwForce = Vector3.Cross(LFWEngine.transform.position - rb.worldCenterOfMass, LFWEngine.transform.TransformDirection(new Vector3(0, lfwEngineForce, 0)));
            rb.AddForceAtPosition(lfwForce, LFWEngine.transform.position);

            var rfcForce = Vector3.Cross(RFCEngine.transform.position - rb.worldCenterOfMass, RFCEngine.transform.TransformDirection(new Vector3(0, -rfcEngineForce, 0)));
            rb.AddForceAtPosition(rfcForce, RFCEngine.transform.position);

            var lbcForce = Vector3.Cross(LBCEngine.transform.position - rb.worldCenterOfMass, LBCEngine.transform.TransformDirection(new Vector3(0, -lbcEngineForce, 0)));
            rb.AddForceAtPosition(lbcForce, LBCEngine.transform.position);

            var rbwForce = Vector3.Cross(RBWEngine.transform.position - rb.worldCenterOfMass, RBWEngine.transform.TransformDirection(new Vector3(0, rbwEngineForce, 0)));
            rb.AddForceAtPosition(rbwForce, RBWEngine.transform.position);
        }

        private void AddPullForces()
        {
            rb.AddForceAtPosition(rb.transform.TransformDirection(
                     new Vector3(0, lfwEngineForce * PowerFactor, 0)
                ),
                LFWEngine.transform.position);

            rb.AddForceAtPosition(rb.transform.TransformDirection(
                     new Vector3(0, rfcEngineForce * PowerFactor, 0)
                ),
                RFCEngine.transform.position);

            rb.AddForceAtPosition(rb.transform.TransformDirection(
                     new Vector3(0, lbcEngineForce * PowerFactor, 0)
                ),
                LBCEngine.transform.position);

            rb.AddForceAtPosition(rb.transform.TransformDirection(
                     new Vector3(0, rbwEngineForce * PowerFactor, 0)
                ),
                RBWEngine.transform.position);
        }
    }
}