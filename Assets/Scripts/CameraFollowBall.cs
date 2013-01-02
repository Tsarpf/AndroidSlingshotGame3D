using UnityEngine;
using System.Collections;

public class CameraFollowBall : MonoBehaviour {

    Transform ball;
    GameObject slingshot;
    Vector3 cameraAngle;
	void Start ()
    {
        ball = GameObject.Find("Sphere").transform;
        slingshot = GameObject.Find("Slingshot");
        cameraAngle = transform.rotation.eulerAngles;
	}
	
	// Update is called once per frame
    public static bool enabled = true;
    public static bool slingin = false;
	void Update ()
    {
        if (enabled)
        {
            transform.position = new Vector3(ball.position.x, transform.position.y, ball.position.z - 10);
        }
        if (slingin)
        {
            transform.LookAt(slingshot.transform.position);
            cameraAngle = transform.rotation.eulerAngles;
            slingshot.transform.eulerAngles = new Vector3(180 , transform.rotation.eulerAngles.y - 90, 90);
        }
        else
        {
            
            transform.rotation = Quaternion.Euler(cameraAngle);
            //transform.LookAt(ball.position);
            
        }
	}
}
