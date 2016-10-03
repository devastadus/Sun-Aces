using UnityEngine;
using System.Collections.Generic;


//Need to figure out something new, nontrackable objects are warping and i dont know why back to there origional position once a player hits an edge
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
		Vector3 playerPos = Vector3.zero;
        Vector3 temp2 = Vector3.zero;
        playerPos = collider.transform.position;
        if (obj.name == "Top")
        {
            playerPos.y = obj.transform.position.y;
            playerPos.y = playerPos.y - (arenaRange * 4) + 1f;
            foreach (GameObject nonFollowableObject in nonFollowableObjects)
            {
				temp2 = nonFollowableObject.transform.position;
                temp2.y = nonFollowableObject.transform.position.y;
                temp2.y = temp2.y - (arenaRange*4);// + 1f;
                nonFollowableObject.transform.position = temp2;
            }
        }
        else if (obj.name == "Bottom")
        {
            playerPos.y = obj.transform.position.y;
            playerPos.y = playerPos.y + (arenaRange * 4) - 1f;
            foreach (GameObject nonFollowableObject in nonFollowableObjects)
            {
				temp2 = nonFollowableObject.transform.position;
                temp2.y = nonFollowableObject.transform.position.y;
                temp2.y = temp2.y + (arenaRange * 4);// + 1f;
                nonFollowableObject.transform.position = temp2;
            }
        }
        else if (obj.name == "Right")
        {
            playerPos.x = obj.transform.position.x;
            playerPos.x = playerPos.x - (arenaRange * 4) + 1f;
            foreach (GameObject nonFollowableObject in nonFollowableObjects)
            {
				temp2 = nonFollowableObject.transform.position;
                temp2.x = nonFollowableObject.transform.position.x;
                temp2.x = temp2.x - (arenaRange * 4);// + 1f;
                nonFollowableObject.transform.position = temp2;
            }
        }
        else if (obj.name == "Left")
        {
            playerPos.x = obj.transform.position.x;
            playerPos.x = playerPos.x + (arenaRange * 4) - 1f;
            foreach (GameObject nonFollowableObject in nonFollowableObjects)
            {
				temp2 = nonFollowableObject.transform.position;
                temp2.x = nonFollowableObject.transform.position.x;
                temp2.x = temp2.x + (arenaRange * 4);// + 1f;
                nonFollowableObject.transform.position = temp2;
            } 
        }
        collider.transform.position = playerPos;
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
