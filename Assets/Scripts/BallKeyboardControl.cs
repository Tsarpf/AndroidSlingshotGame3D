using UnityEngine;
using System.Collections;

public class BallKeyboardControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            StaticData.forwardAngle = 1;
        }
        else
        {
            StaticData.forwardAngle = 0;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            StaticData.upAngle = 1;
        }
        else
        {
            StaticData.upAngle = 0;
        }


        //For android
        if(Input.GetKey(KeyCode.A))
        {
            StaticData.upAngle = 1;
        }
        else
        {
            StaticData.upAngle = 0;
        }
        if(Input.GetKey(KeyCode.W))
        {
            StaticData.forwardAngle = 1;
        }
        else
        {
            StaticData.forwardAngle = 0;
        }
	}
}
