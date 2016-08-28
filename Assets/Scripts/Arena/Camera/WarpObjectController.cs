using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WarpObjectController : MonoBehaviour {

	private float timmer;
	public float arenaRange = 20f;
    public List<GameObject> nonFollowableObjects;

	// Use this for initialization
	void Start () {
		timmer = Time.time;	
	}

	public void Warper(GameObject obj, Collider2D collider){

		if (collider.gameObject.GetComponent<TrackObject>() && (timmer+ .1f < Time.time))
		{
            WarpObject(obj,collider);
		}		
	}

    private void WarpObject(GameObject obj, Collider2D collider)
    {
        Vector3 temp = Vector3.zero;
        Vector3 temp2 = Vector3.zero;
        Vector2 objDistance = Vector2.zero;
        temp = collider.transform.position;
        if (obj.name == "Top")
        {
            temp.y = obj.transform.position.y;
            temp.y = temp.y - (arenaRange * 4) + 1f;
            foreach (GameObject nonFollowableObject in nonFollowableObjects)
            {
                temp2.y = nonFollowableObject.transform.position.y;
                temp2.y = temp2.y - (arenaRange*4);// + 1f;
                nonFollowableObject.transform.position = temp2;
            }
        }
        else if (obj.name == "Bottom")
        {
            temp.y = obj.transform.position.y;
            temp.y = temp.y + (arenaRange * 4) - 1f;
            foreach (GameObject nonFollowableObject in nonFollowableObjects)
            {
                temp2.y = nonFollowableObject.transform.position.y;
                temp2.y = temp2.y + (arenaRange * 4);// + 1f;
                nonFollowableObject.transform.position = temp2;
            }
        }
        else if (obj.name == "Right")
        {
            temp.x = obj.transform.position.x;
            temp.x = temp.x - (arenaRange * 4) + 1f;
            foreach (GameObject nonFollowableObject in nonFollowableObjects)
            {
                temp2.x = nonFollowableObject.transform.position.x;
                temp2.x = temp2.x - (arenaRange * 4);// + 1f;
                nonFollowableObject.transform.position = temp2;
            }
        }
        else if (obj.name == "Left")
        {
            temp.x = obj.transform.position.x;
            temp.x = temp.x + (arenaRange * 4) - 1f;
            foreach (GameObject nonFollowableObject in nonFollowableObjects)
            {
                temp2.x = nonFollowableObject.transform.position.x;
                temp2.x = temp2.x + (arenaRange * 4);// + 1f;
                nonFollowableObject.transform.position = temp2;
            } 
        }
        collider.transform.position = temp;
        timmer = Time.time + .1f;
    }

    public void AddNonTrackableObject(GameObject obj)
    {
        nonFollowableObjects.Add(obj);
    }

    public void RemoveNonTrackableObject(GameObject obj)
    {
        nonFollowableObjects.Remove(obj);
    }
}
