using UnityEngine;
using System.Collections;

public class RotateAroundGlobe : MonoBehaviour {
    Transform lookTarget;
    Transform gravityCenter;
	// Use this for initialization
	void Start () {
        lookTarget = GameObject.Find("GravityCenter").transform;
        gravityCenter = GameObject.Find("GravityCenter").transform;


	}
	
	// Update is called once per frame
	void Update () {
        //StaticData.upAngle = 20 * Time.deltaTime;
        //StaticData.forwardAngle = 20 * Time.deltaTime;

        transform.RotateAround(gravityCenter.position, Vector3.up, StaticData.upAngle);
        transform.RotateAround(gravityCenter.position, Vector3.forward, StaticData.forwardAngle);	
	}
}
