using UnityEngine;
using System.Collections;

public class StartPos : MonoBehaviour {

	// Use this for initialization
    public GameObject player;
	void Start ()
    {
        player = GameObject.Find("Sphere");
        player.transform.position = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
