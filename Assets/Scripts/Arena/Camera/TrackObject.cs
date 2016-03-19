using UnityEngine;
using System.Collections;

public class TrackObject : MonoBehaviour {

    private CameraControl cameraControl;

    // Use this for initialization
    void Start () {
        GameObject Camera = GameObject.Find("CameraRig");
        cameraControl = Camera.GetComponent<CameraControl>();
        cameraControl.AddFollowableObject(gameObject);
    }

    public void Untrack()
    {
        cameraControl.RemoveFollowableObject(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
