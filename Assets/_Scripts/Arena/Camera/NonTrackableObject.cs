using UnityEngine;
using System.Collections;

public class NonTrackableObject : MonoBehaviour
{

    private WarpObjectController warpObjectController;

	//TODO: change to on Spawn
	// Use this for initialization
	void Start ()
	{
	    GameObject cameraRig = GameObject.Find("CameraRig");
	    warpObjectController = cameraRig.GetComponentInChildren<WarpObjectController>();
        warpObjectController.AddNonTrackableObject(gameObject);
	}

	//TODO: change to on Despawn
    void OnDestroy()
    {
        warpObjectController.RemoveNonTrackableObject(gameObject);
    }
}
