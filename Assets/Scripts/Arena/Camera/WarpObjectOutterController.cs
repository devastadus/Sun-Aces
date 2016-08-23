using UnityEngine;
using System.Collections;

public class WarpObjectOutterController : MonoBehaviour {

	public float arenaRange = 20f;


	public void Warper(GameObject obj, Collider2D collider){
        WarpObject(obj,collider);	
	}

    private void WarpObject(GameObject obj, Collider2D collider)
    {
        Vector3 temp = Vector3.zero;
        temp = collider.transform.position;
        if (obj.name == "Top")
        {

            temp.y = obj.transform.position.y;
            temp.y = temp.y - (arenaRange * 2) + 1f;
        }
        else if (obj.name == "Bottom")
        {
            temp.y = obj.transform.position.y;
            temp.y = temp.y + (arenaRange * 2) - 1f;
        }
        else if (obj.name == "Right")
        {
            temp.x = obj.transform.position.x;
            temp.x = temp.x - (arenaRange * 2) + 1f;
        }
        else if (obj.name == "Left")
        {
            temp.x = obj.transform.position.x;
            temp.x = temp.x + (arenaRange * 2) - 1f;
        }
        collider.transform.position = temp;
    }		
}
