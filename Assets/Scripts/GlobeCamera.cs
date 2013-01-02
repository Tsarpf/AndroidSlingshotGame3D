using UnityEngine;
using System.Collections;

public class GlobeCamera : MonoBehaviour {

    Transform lookTarget;
    Transform gravityCenter;
	// Use this for initialization
	void Start ()
    {
        lookTarget = GameObject.Find("TheBall").transform;
        gravityCenter = GameObject.Find("GravityCenter").transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.LookAt(lookTarget.position);

        transform.RotateAround(gravityCenter.position, Vector3.up, StaticData.upAngle);
        transform.RotateAround(gravityCenter.position, Vector3.forward, StaticData.forwardAngle);
	}
}
