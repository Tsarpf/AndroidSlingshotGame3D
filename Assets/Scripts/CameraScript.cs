using UnityEngine;
using System.Collections.Generic;

public class CameraScript : MonoBehaviour
{

    Transform ball;
    GameObject slingshot;
    Vector3 cameraAngle;
    void Start()
    {
        ball = GameObject.Find("Sphere").transform;
        slingshot = GameObject.Find("Slingshot");
        cameraAngle = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    //public static bool enabled = true;
    public static bool slingin = false;
    float distanceLast;
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
        /*
        transform.position = new Vector3(ball.position.x, transform.position.y, ball.position.z - 15);
        
        if (slingin)
        {
            transform.LookAt(slingshot.transform.position);
            cameraAngle = transform.rotation.eulerAngles;
            slingshot.transform.eulerAngles = new Vector3(180, transform.rotation.eulerAngles.y - 90, 90);
            t
            //keepCameraBehindBallOnAim();
        }
        else
        {
            transform.rotation = Quaternion.Euler(cameraAngle);
        }
        */
#if UNITY_ANDROID
        if (Input.touchCount == 2)
        {
            Vector3 pos1 = Input.touches[0].position;
            Vector3 pos2 = Input.touches[1].position;
            if (Input.touches[0].phase == TouchPhase.Began || Input.touches[1].phase == TouchPhase.Began)
            {
                distanceLast = Vector3.Distance(pos1, pos2);
            }
            else if (Input.touches[0].phase == TouchPhase.Moved || Input.touches[1].phase == TouchPhase.Moved)
            {
                float distanceNow = Vector3.Distance(pos1, pos2);

                if (distanceNow > distanceLast)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                }
                else if (distanceNow < distanceLast)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + -1, transform.position.z);
                }
            }
        }
#endif

        if (slingin)
        {
            transform.position = new Vector3(slingshot.transform.position.x, transform.position.y, slingshot.transform.position.z);
        }
        else
        {
            //transform.position = new Vector3(ball.position.x, transform.position.y, ball.position.z);
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, ball.position.x, Time.time / 200), transform.position.y, Mathf.Lerp(transform.position.z, ball.position.z, Time.time / 200));
        }
        
    }

    void keepCameraBehindBallOnAim()
    {
        Vector3 ballPos = ball.transform.position;
        Vector3 slingPos = slingshot.transform.position;

        float cameraDistanceFromBall = 15;

        //        ritsaToPallo + (ritsaToPallo.normalize * 15)
        
        //Vector3 moveXUnitsInDir = ballPos + (ballPos.normalized * cameraDistanceFromBall);
        
        //slingshot.transform.position - ballPos

        //ritsa + (ritsa - pallo) + ((ritsa - pallo).normalize * 15)

        //Vector3 pos = slingPos + (slingPos - ballPos) + ((slingPos - ballPos).normalized * cameraDistanceFromBall);
        //Vector3 pos = 
        //

        Vector3 pos = slingPos + ((ballPos - slingPos).normalized * cameraDistanceFromBall);

        transform.position = new Vector3(pos.x, transform.position.y, pos.z);
    }

  
}
