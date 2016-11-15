 using UnityEngine;
using System.Collections;
using Rewired;


public class ShipEngine : MonoBehaviour {
    public Transform EnginePos;
    public GameObject Engine;
    private bool isThrusting = false;
    private GameObject currentEngine;
    private Rewired.Player _player; // The Rewired Player
    float thrust;

    // Use this for initialization

    // Update is called once per frame

    void Start()
    {
        int PlayerId = GetComponent<ShipController>().PlayerId;
        _player = ReInput.players.GetPlayer(PlayerId);
    }

    void Update () {
        thrust = _player.GetAxis("Vertical");

        if ((thrust >.2f || thrust < -.2f) && isThrusting == false)
	    {
	        isThrusting = true;
	        currentEngine = (GameObject) Instantiate(Engine, EnginePos.position, Quaternion.identity);
	        currentEngine.transform.parent = transform;
	    }
		else if ((thrust < .2f && thrust > -.2f) && isThrusting == true)
        {
            isThrusting = false;
            currentEngine.transform.parent = null;
            Destroy(currentEngine,1f);
        }
	
	}
}
