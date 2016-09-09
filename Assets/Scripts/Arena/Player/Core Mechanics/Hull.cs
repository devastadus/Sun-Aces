using UnityEngine;
using System.Collections;

public class Hull : MonoBehaviour {

    public int health = 10;
    public GameObject Death;
    public TrackObject TrackObject;
    public CameraControl CameraControl;

    void Start()
    {
        TrackObject = GetComponent<TrackObject>();
        CameraControl = GameObject.Find("CameraRig").GetComponent<CameraControl>();
    }

    public void modifyHealth(int _health)
    {
        health =+ _health;

        if(health <= 0)
        {
            if (TrackObject != null)
            {
                CameraControl.RemoveFollowableObject(gameObject);
                // remove from camera
            }
            Destroy(gameObject);
            Instantiate(Death, transform.position, Quaternion.identity);
        }
    }
}
