using UnityEngine;
using System.Collections;

namespace Quadrocopter
{
    public class UserController : MonoBehaviour
    {

        QuadrocopterStabilizer1 quadrocopterStabilizer;
        // Use this for initialization
        void Start()
        {
            quadrocopterStabilizer = GetComponent<QuadrocopterStabilizer1>();
        }

        // Update is called once per frame
        void Update()
        {
            quadrocopterStabilizer.Throttle = 0.5f + Input.GetAxis("Thorttle") *0.5f;
            quadrocopterStabilizer.Target.Pitch = Input.GetAxis("Vertical")*30;
            quadrocopterStabilizer.Target.Roll = Input.GetAxis("Horizontal") * 30;
        }
    }
}