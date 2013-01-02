using UnityEngine;
using System.Collections;

public class PlaneRotate : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKey("up"))
        {
            transform.rotation = new Quaternion(transform.rotation.x + 0.01f, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        }

        if (Input.GetKey("down"))
        {
            transform.rotation = new Quaternion(transform.rotation.x - 0.01f, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z + 0.01f, transform.rotation.w);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z - 0.01f, transform.rotation.w);
        }
	}
}
