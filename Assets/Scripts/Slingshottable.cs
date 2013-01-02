using UnityEngine;
using System.Collections;

public class Slingshottable : MonoBehaviour {


	// Use this for initialization
    UnityEngine.GUIText guitext;
    //GameObject ball;
    GameObject slingshot;
	void Start ()
    {
        slingshot = GameObject.Find("Slingshot");
	}
	
	// Update is called once per frame
    Vector3 ballStartPos;
    Vector3 ballEndPos;
    bool slingEnabled = false;
    bool turnScreen = false;

    void Update ()
    {
        #region UNITY_ANDROID
#if UNITY_ANDROID
        if (Input.touchCount == 1)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit rayHit;
                    if (Physics.Raycast(ray, out rayHit) && slingEnabled == false)
                    {                               //gameObject is the gameobject the script is attached to
                        //if (rayHit.transform.gameObject.name == gameObject.name)
                        if (rayHit.collider.gameObject.name == gameObject.name)
                        {
                            ballStartPos = transform.position;
                            slingEnabled = true;
                            CameraScript.slingin = true;
                            Color ballColor = renderer.material.color;
                            ballColor = new Color(ballColor.r, ballColor.g, ballColor.b, 10f);
                            renderer.material.color = ballColor;

                            slingshot.renderer.enabled = true;
                            slingshot.transform.position = ballStartPos;
                        }
                    }
                }

                else if (touch.phase == TouchPhase.Moved && slingEnabled == true)
                {
                    if (slingEnabled)
                    {
                        // Bit shift the index of the layer (8) to get a bit mask
                        //var layerMask = 1 << 8;
                        // This would cast rays only against colliders in layer 8.
                        // But instead we want to collide against everything except layer 8.
                        // The ~ operator does this, it inverts a bitmask.
                        //layerMask = ~layerMask;

                        //Ray ray = Camera.main.ScreenPointToRay(touch.position);                
                        rigidbody.collider.enabled = false;

                        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        RaycastHit rayHit;
                        //if (Physics.Raycast(ray, out rayHit, layerMask))
                        if (Physics.Raycast(ray, out rayHit))
                        {
                            transform.position = new Vector3(rayHit.point.x, ballStartPos.y, rayHit.point.z);
                        }

                    }
                }
                //else if (Input.GetMouseButtonUp(0) && enabled == true) equivalent
                else if (touch.phase == TouchPhase.Ended && slingEnabled == true)
                {
                    ballEndPos = transform.position;
                    rigidbody.collider.enabled = true;
                    Color ballColor = renderer.material.color;
                    ballColor = new Color(ballColor.r, ballColor.g, ballColor.b, 255f);
                    renderer.material.color = ballColor;
                    slingEnabled = false;
                    CameraScript.slingin = false;

                    Shoot();
                }
            }
        }
#endif
#endregion
        #region UNITY_EDITOR
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        if (Input.GetMouseButtonDown(0) && slingEnabled == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;
            if (Physics.Raycast(ray, out rayHit))
            {                               //gameObject is the gameobject the script is attached to
                //if (rayHit.transform.gameObject.name == gameObject.name)
                if (rayHit.collider.gameObject.name == gameObject.name)
                {
                    ballStartPos = transform.position;
                    slingEnabled = true;
                    CameraScript.slingin = true;
                    Color ballColor = renderer.material.color;
                    ballColor = new Color(ballColor.r, ballColor.g, ballColor.b, 10f);
                    renderer.material.color = ballColor;

                    //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 10);

                    slingshot.renderer.enabled = true;
                    slingshot.transform.position = ballStartPos;
                }
            }
        }

        else if (Input.GetMouseButton(0) && slingEnabled == true)
        {
            if (slingEnabled)
            {
                // Bit shift the index of the layer (8) to get a bit mask
                //var layerMask = 1 << 8;
                // This would cast rays only against colliders in layer 8.
                // But instead we want to collide against everything except layer 8.
                // The ~ operator does this, it inverts a bitmask.
                //layerMask = ~layerMask;

                //Ray ray = Camera.main.ScreenPointToRay(touch.position);                
                rigidbody.collider.enabled = false;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit rayHit;
                //if (Physics.Raycast(ray, out rayHit, layerMask))
                if (Physics.Raycast(ray, out rayHit))
                {
                    transform.position = new Vector3(rayHit.point.x, ballStartPos.y, rayHit.point.z);
                }
            }
        }
        //(touch.phase == TouchPhase.Ended) equivalent
        else if (Input.GetMouseButtonUp(0) && slingEnabled == true)
        {
            ballEndPos = transform.position;
            rigidbody.collider.enabled = true;
            Color ballColor = renderer.material.color;
            ballColor = new Color(ballColor.r, ballColor.g, ballColor.b, 255f);
            renderer.material.color = ballColor;
            slingEnabled = false;
            CameraScript.slingin = false;

            Shoot();
        }
#endif
        #endregion
    }

    void Shoot()
    {
        //Vector3(to - from).normalized; = direction
        Vector3 dir = (ballStartPos - ballEndPos).normalized;

        float distance = Vector3.Distance(ballStartPos, ballEndPos);

        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;

        Vector3 force = new Vector3((dir.x * distance * 100), 0, (dir.z * distance * 100));

        //rigidbody.AddForce(force);
        rigidbody.AddForce(force);
    }
}