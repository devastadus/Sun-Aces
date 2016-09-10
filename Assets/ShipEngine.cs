 	using UnityEngine;
using System.Collections;
using InControl;

public class ShipEngine : MonoBehaviour,IControls {
    public Transform EnginePos;
    public GameObject Engine;
	public PlayerActions Actions{get; set;}


    private bool isThrusting = false;
    private GameObject currentEngine;

	// Use this for initialization
	
	// Update is called once per frame



	void Update () {
		if ((Actions.Control.Y >.5f || Actions.Control.Y <-.5f) && isThrusting == false)
	    {
	        isThrusting = true;
	        currentEngine = (GameObject) Instantiate(Engine, EnginePos.position, Quaternion.identity);
	        currentEngine.transform.parent = transform;
	    }
		else if ((Actions.Control.Y < .5f && Actions.Control.Y > -.5f) && isThrusting == true)
        {
            isThrusting = false;
            currentEngine.transform.parent = null;
            Destroy(currentEngine,1f);
        }
	
	}
}
