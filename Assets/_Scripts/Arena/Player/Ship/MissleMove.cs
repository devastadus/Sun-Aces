using UnityEngine;
using System.Collections;

public class MissleMove : MonoBehaviour {

	public float searchRange = 3f;
	public float maxSpeed = 25f;
	public float thrust = 500f;
	public float rotSpeed = 180;
	public float timeToLive = 1f;

	int enemyLayer;
	float deathTime;
	private GameObject closestTarget;
	private Rigidbody2D rb2d;


	// Use this for initialization
	void Start()
	{
		rb2d = gameObject.GetComponent<Rigidbody2D>();

		if(gameObject.layer == 8)
			enemyLayer = 9;
		else if(gameObject.layer == 9)
			enemyLayer = 8;

		deathTime = Time.time + timeToLive;
		//Debug.Log(LayerMask.NameToLayer("BlueTeam"));
		//Debug.Log("enemyTeam: "+enemyLayer);
		//Debug.Log(1<<enemyLayer);


//		Debug.Log(transform.position);
	}
	
	// Update is called once per frame
	void Update()
	{
		FindClosestTarget();	
		Die();					
	}

	void Die(){
		if(Time.time > deathTime){
			Destroy(gameObject);
		}

	}

	void FixedUpdate(){
		Move();
		if(closestTarget)
			FacesEnemy();
	}

	void FindClosestTarget(){		
		Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position,searchRange,1<<enemyLayer);
		if(cols.Length ==0){
			closestTarget = null;
		}
		else {
			float shortestDistance = 0;
			foreach( Collider2D col in cols){
				float currentDistance = Vector2.Distance(transform.position,col.gameObject.transform.position);
				if(shortestDistance == 0 || currentDistance < shortestDistance){
					shortestDistance = currentDistance;
					closestTarget = col.gameObject;
				}				
			}
		}
	}

	void Move(){
		rb2d.AddForce(transform.rotation * Vector2.up *thrust * Time.deltaTime);
		Vector2 limit = Vector2.ClampMagnitude(rb2d.velocity,maxSpeed);
		rb2d.velocity = limit;
	}

	void FacesEnemy(){

		Vector3 dir = closestTarget.transform.position - transform.position;
		dir.Normalize();
		float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
		Quaternion desiredRotation = Quaternion.Euler(0, 0, zAngle);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotSpeed * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		Destroy(gameObject,.02f);	
	}



/*	void FindClosestTarget(){
		
		//Find closest Enemy
		
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		float shortestDistance =0;
		foreach (GameObject enemy in enemies)
		{
			float currentDistance = Vector3.Distance(transform.position, enemy.transform.position);
			
			if (shortestDistance == 0 || currentDistance <= shortestDistance)
			{
				shortestDistance = currentDistance;
				closestTarget = enemy;
			}
		}
		
		
		
		// moves the missle forward
		Vector3 pos = transform.position;
		//Vector3 velocity = Vector3.up * Time.deltaTime * maxSpeed * Input.GetAxis("Vertical");
		Vector3 velocity = new Vector3(0, Time.deltaTime * maxSpeed, 0);
		pos += transform.rotation * velocity;
		
		transform.position = pos;
		
		if (target == null)
			return;
		
		//faces the enemy 
		
		//points to target
		Vector3 dir = target.transform.position - transform.position;
		dir.Normalize();
		//        Debug.Log(Mathf.Atan2(dir.y,dir.x)*Mathf.Rad2Deg);
		
		float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
		Quaternion desiredRotation = Quaternion.Euler(0, 0, zAngle);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotSpeed * Time.deltaTime);
	}*/
}
