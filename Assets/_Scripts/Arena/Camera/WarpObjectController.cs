using UnityEngine;
using System.Collections.Generic;


//Need to figure out something new, nontrackable objects are warping and i dont know why back to there origional position once a player hits an edge
public class WarpObjectController : MonoBehaviour {


	public float arenaRange = 20f;
    public List<GameObject> nonFollowableObjects;
	public List<Vector3> localPos;

	public Transform topCollider;
	public Transform bottomCollider;
	public Transform rightCollider;
	public Transform leftCollider;

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
		//if (collider.gameObject.GetComponent<TrackObject>() && (timmer+ .1f < Time.time))
		if ((timmer+ .1f < Time.time))
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

	//collider is the object colliding, obj is the collider=2
    private void WarpObject(GameObject obj, Collider2D collider)
    {
		Vector3 temp = Vector3.zero;
        Vector3 temp2 = Vector3.zero;
		temp = collider.transform.position;
        if (obj.name == "Top")
        {
			if(collider.gameObject.GetComponent<TrackObject>())
			{          
				temp.y = obj.transform.position.y;
            	temp.y = temp.y - (arenaRange * 4) + 1f;

				foreach (var nonfollowable in nonFollowableObjects) {
					temp2 = nonfollowable.transform.position;
					temp2.y = temp2.y - arenaRange;
					nonfollowable.transform.position = temp2;
				}
			}
			else 
			{
				temp.y = obj.transform.position.y;
				temp.y = temp.y - (arenaRange * 2) + 1f;
			}				
        }
        else if (obj.name == "Bottom")
        {
			if(collider.gameObject.GetComponent<TrackObject>())
			{
				temp.y = obj.transform.position.y;
				temp.y = temp.y + (arenaRange * 4) - 1f;

				foreach (var nonfollowable in nonFollowableObjects) {
					temp2 = nonfollowable.transform.position;
					temp2.y = temp2.y + arenaRange;
					nonfollowable.transform.position = temp2;
				}
			}
			else
			{
				temp.y = obj.transform.position.y;
				temp.y = temp.y + (arenaRange * 2) - 1f;
			}            
        }
        else if (obj.name == "Right")
        {
			if(collider.gameObject.GetComponent<TrackObject>())
			{
				temp.x = obj.transform.position.x;
				temp.x = temp.x - (arenaRange * 4) + 1f;

				foreach (var nonfollowable in nonFollowableObjects) {
					temp2 = nonfollowable.transform.position;
					temp2.x = temp2.x - arenaRange;
					nonfollowable.transform.position = temp2;
				}
			}
			else{
				temp.x = obj.transform.position.x;
				temp.x = temp.x - (arenaRange * 2) + 1f;
			}
        }
        else if (obj.name == "Left")
        {
			if(collider.gameObject.GetComponent<TrackObject>())
			{
				temp.x = obj.transform.position.x;
				temp.x = temp.x + (arenaRange * 4) - 1f;

				foreach (var nonfollowable in nonFollowableObjects) {
					temp2 = nonfollowable.transform.position;
					temp2.x = temp2.x + arenaRange;
					nonfollowable.transform.position = temp2;
				}
			}
			else{
				temp.x = obj.transform.position.x;
				temp.x = temp.x + (arenaRange * 2) - 1f;
			}            
        }
        collider.transform.position = temp;
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
