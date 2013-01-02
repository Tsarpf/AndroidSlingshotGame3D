using UnityEngine;
using System.Collections;
using System;

public class CapsulePushOrPull : MonoBehaviour {

    float speed = 1.0f;
    Transform ball;
    UnityEngine.GUIText guiText;
    public bool enabled = true;
	void Start ()
    {
        ball = GameObject.Find("Sphere").transform;
        //guiText = GameObject.Find("GUI Text").guiText;
	}

    
	void Update ()
    {
        if (enabled)
        {
            percentualPullPushBall();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (pull)
                {
                    pull = false;
                }
                else
                {
                    pull = true;
                }
            }
        }
	}
    bool pull = true;

    private void percentualPullPushBall()
    {

        float maxForce = 10.0f;
        float maxDistance = new Vector3(20, 0, 20).magnitude;

        float asd = (1.0f - (Mathf.Min((Vector3.Distance(ball.position, transform.position) / maxDistance), 1)));

        if (pull) { asd *= -1; }

        Vector3 forceasd = (ball.position - transform.position).normalized * maxForce;

        forceasd = new Vector3(forceasd.x * asd, forceasd.y * asd, forceasd.z * asd);

        ball.rigidbody.AddForce(forceasd);
    }
}
