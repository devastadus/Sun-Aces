using System;
using UnityEngine;
using System.Collections;

public class WrapObjectOutter : MonoBehaviour
{

    //private float arenaRange = 9f;    
	private WarpObjectOutterController controller;

    // Use this for initialization
    void Start ()
	{	    
		controller = gameObject.GetComponentInParent<WarpObjectOutterController>();
	    //Camera mainCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
		controller.Warper(gameObject,other);
	}

	void OnTriggerStay2D(Collider2D other) {
		controller.Warper(gameObject,other);
	}
}
