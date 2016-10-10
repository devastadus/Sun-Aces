using UnityEngine;
using System.Collections.Generic;


//Need to figure out something new, nontrackable objects are warping and i dont know why back to there origional position once a player hits an edge
public class WarpObjectController : MonoBehaviour {


	public float arenaRange = 20f;
    public List<GameObject> nonFollowableObjects;
	public List<Vector3> localPos;

	private float timmer;
	private int onNextUpdate = 0;

	// Use this for initialization
	void Start () {
		timmer = Time.time;	
	}

	void Update () {
		

		 if(onNextUpdate == 1){
			foreach(GameObject nonFollowableObject in nonFollowableObjects){				
				nonFollowableObject.transform.localPosition = localPos[0];
				localPos.RemoveAt(0);
//				nonFollowableObject.SetActive(true);
			}				
			onNextUpdate = 0;
		}

		else if(onNextUpdate > 1){
			--onNextUpdate;
		}
	}

	public void Warper(GameObject obj, Collider2D collider){		
		if (collider.gameObject.GetComponent<TrackObject>() && (timmer+ .1f < Time.time))
		{
            WarpObject(obj,collider);
		}		
	}

	//moves ships
	//save relative position of objects
	//on next update move those objects back in there relative position

	private void SaveLocalPosition(){
		onNextUpdate = 3;
		foreach(GameObject nonFollowableObject in nonFollowableObjects){
			localPos.Add(nonFollowableObject.transform.localPosition);
//			nonFollowableObject.SetActive(false);
		}
	}

    private void WarpObject(GameObject obj, Collider2D collider)
    {
		Vector3 playerPos = Vector3.zero;
//        Vector3 temp2 = Vector3.zero;
        playerPos = collider.transform.position;
        if (obj.name == "Top")
        {
            playerPos.y = obj.transform.position.y;
            playerPos.y = playerPos.y - (arenaRange * 4) + 1f;
			SaveLocalPosition();
        }
        else if (obj.name == "Bottom")
        {
            playerPos.y = obj.transform.position.y;
            playerPos.y = playerPos.y + (arenaRange * 4) - 1f;
			SaveLocalPosition();
        }
        else if (obj.name == "Right")
        {
            playerPos.x = obj.transform.position.x;
            playerPos.x = playerPos.x - (arenaRange * 4) + 1f;
			SaveLocalPosition();
        }
        else if (obj.name == "Left")
        {
            playerPos.x = obj.transform.position.x;
            playerPos.x = playerPos.x + (arenaRange * 4) - 1f;
			SaveLocalPosition();
        }
        collider.transform.position = playerPos;
        timmer = Time.time + .1f;
    }

	void MoveNonFollowables(){

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
