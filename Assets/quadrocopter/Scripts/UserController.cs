using UnityEngine;
using System.Collections;
using System;

namespace Quadrocopter
{
    public class UserController : MonoBehaviour
    {

        QuadrocopterStabilizer2 quadrocopterStabilizer2;
        QuadrocopterStabilizer1 quadrocopterStabilizer1;
        // Use this for initialization
        void Start()
        {
            quadrocopterStabilizer2 = GetComponent<QuadrocopterStabilizer2>();
            quadrocopterStabilizer1 = GetComponent<QuadrocopterStabilizer1>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey("space"))
            {
                ResetTarget();
                return;
            }
            var dt = Time.deltaTime;
            quadrocopterStabilizer2.VerticalTarget = (quadrocopterStabilizer2.VerticalTarget + Input.GetAxis("Thorttle") * dt).Limit(-2,2);
            quadrocopterStabilizer2.ForwardTarget = (quadrocopterStabilizer2.ForwardTarget + Input.GetAxis("Vertical") * dt).Limit(-2, 2);
            quadrocopterStabilizer2.SideTarget = (quadrocopterStabilizer2.SideTarget +  Input.GetAxis("Horizontal") * dt).Limit(-2, 2);
            quadrocopterStabilizer1.Target.Yaw = (quadrocopterStabilizer1.Target.Yaw + Input.GetAxis("Yaw") * dt * 45).Looped(-180, 180);
        }

        private void ResetTarget()
        {
            quadrocopterStabilizer2.VerticalTarget = 0;
            quadrocopterStabilizer2.ForwardTarget = 0;
            quadrocopterStabilizer2.SideTarget = 0;
        }
    }
}