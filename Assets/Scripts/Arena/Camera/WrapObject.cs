using System;
using UnityEngine;
using System.Collections;

public class WrapObject : MonoBehaviour
{

    private float arenaRange = 9f;
    private float time;

    // Use this for initialization
    void Start ()
	{
	    time = Time.time;
	    Debug.Log(time);
	    //Camera mainCamera = Camera.main;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (time > Time.time + .1f)
        {
            Vector3 temp = Vector3.zero;
            temp = other.transform.position;
            Vector2 velocity = other.gameObject.GetComponent<Rigidbody2D>().velocity.normalized;
            if (gameObject.name == "Top")
            {
                if (!(velocity.y <= 0))
                {
                    temp.y = transform.position.y;
                    temp.y = temp.y - (arenaRange * 4) + 1f;
                }
            }
            else if (gameObject.name == "Bottom")
            {
                if (!(velocity.y >= 0))
                {
                    temp.y = transform.position.y;
                    temp.y = temp.y + (arenaRange * 4) - 1f;
                }
            }
            else if (gameObject.name == "Right")
            {
                if (!(velocity.x <= 0))
                {
                    temp.x = transform.position.x;
                    temp.x = temp.x - (arenaRange * 4) + 1f;
                }
            }
            else if (gameObject.name == "Left")
            {
                if (!(velocity.x >= 0))
                {
                    temp.x = transform.position.x;
                    temp.x = temp.x + (arenaRange * 4) - 1f;
                }
            }
            other.transform.position = temp;
            time = Time.time + .1f;
        }

    }
        
}
