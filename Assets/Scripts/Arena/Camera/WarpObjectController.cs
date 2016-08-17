using UnityEngine;
using System.Collections;

public class WarpObjectController : MonoBehaviour {

	private float timmer;
	private float arenaRange = 10f;

	// Use this for initialization
	void Start () {
		timmer = Time.time;	
	}

	public void Warper(GameObject obj, Collider2D collider){
		if (timmer+ .1f < Time.time)
		{
			Vector3 temp = Vector3.zero;
			temp = collider.transform.position;
			Vector2 velocity = collider.gameObject.GetComponent<Rigidbody2D>().velocity.normalized;
			if (obj.name == "Top")
			{
		
				temp.y = obj.transform.position.y;
				temp.y = temp.y - (arenaRange * 4) + 1f;
			}
			else if (obj.name == "Bottom")
			{
				temp.y = obj.transform.position.y;
				temp.y = temp.y + (arenaRange * 4) - 1f;
			}
			else if (obj.name == "Right")
			{
				temp.x = obj.transform.position.x;
				temp.x = temp.x - (arenaRange * 4) + 1f;
			}
			else if (obj.name == "Left")
			{
				temp.x = obj.transform.position.x;
				temp.x = temp.x + (arenaRange * 4) - 1f;
			}
			collider.transform.position = temp;
			timmer = Time.time + .1f;
		}
	}		
}
