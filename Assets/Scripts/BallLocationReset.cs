using UnityEngine;
using System.Collections;

public class BallLocationReset : MonoBehaviour {

	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.y < -40)
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            transform.position = MapInfo.startPos;
        }
	}
}
