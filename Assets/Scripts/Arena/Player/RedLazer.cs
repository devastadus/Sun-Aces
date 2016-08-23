using UnityEngine;
using System.Collections;

public class RedLazer : MonoBehaviour {
	private Rigidbody2D rb;
	public float speed = 5f;
	public float timeToLive = 1f;

	bool hasDeltDamage = false;
	public Vector2 speedOfShip;
	float deathTime;
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
		deathTime = Time.time + timeToLive;			
		rb.velocity  = transform.rotation * (Vector2.up * (speed));
	    rb.velocity += speedOfShip;
	}

	void Update(){
		Die();
	}

	// Update is called once per frame
	void FixedUpdate () {
		//MoveMissle();

	}

	void OnCollisionEnter2D(Collision2D coll) {		
		if(hasDeltDamage == false)
			hasDeltDamage = true;
		else
			Destroy(gameObject);				
		//Rigidbody2D collRb = coll.gameObject.GetComponent<Rigidbody2D>();
		//collRb.velocity += rb.velocity;
		Destroy(gameObject,.02f);
	}

	void MoveMissle(){		
		rb.velocity  = transform.rotation * (Vector2.up * (speed) * Time.deltaTime);
		rb.velocity += speedOfShip;		
	} 

	void Die()
	{
		if (Time.time > deathTime)
			Destroy(gameObject);

	}
}
