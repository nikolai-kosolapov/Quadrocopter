using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Quadrocopter;
public class VelInfo : MonoBehaviour {

    public GameObject Quadrocopter;
    public GameObject Forward;

    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
       // Forward.GetComponent<Text>().text = Quadrocopter.GetComponent<QuadrocopterStabilizer2>().SpeedSensor.Forward.ToString();

    }
}
