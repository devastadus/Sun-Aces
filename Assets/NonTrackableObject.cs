using UnityEngine;
using System.Collections;

public class NonTrackableObject : MonoBehaviour
{

    private WarpObjectController warpObjectController;

	// Use this for initialization
	void Start ()
	{
	    GameObject cameraRig = GameObject.Find("CameraRig");
	    warpObjectController = cameraRig.GetComponentInChildren<WarpObjectController>();
        warpObjectController.AddNonTrackableObject(gameObject);
	}

    void OnDestroy()
    {
        warpObjectController.RemoveNonTrackableObject(gameObject);
    }
}
