using UnityEngine;
using System.Collections;

public class HitGoal : MonoBehaviour {
    /*
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    */
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Sphere")
        {
            other.gameObject.rigidbody.velocity = Vector3.zero;
            other.gameObject.rigidbody.angularVelocity = Vector3.zero;
            other.gameObject.transform.position = MapInfo.startPos;
        }
    }
}
