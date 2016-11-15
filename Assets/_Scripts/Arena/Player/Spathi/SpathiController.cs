using UnityEngine;


public class SpathiController : PlayerController {	        		
	public float Speed = 200f; 
	public float RotateSpeed = 80f;
	public float MaxSpeed = 8;
	float _thrust;
	float _rotate;

	//bool isCurrentlyTrusting = false;
	Rigidbody2D _rigidBody2D;

	// Use this for initialization
	new void Start () {
		base.Start();
		_rigidBody2D = gameObject.GetComponent<Rigidbody2D>();	

	}

	// Update is called once per frame
	void FixedUpdate () {
		Move();
		Rotate();				
	}

	void Move(){		

		_thrust = _player.GetAxis("Vertical");
		_rotate = _player.GetAxis("Horizontal");
		_rigidBody2D.AddForce(transform.rotation * Vector2.up *_thrust * Speed * Time.deltaTime);
		Vector2 limit = Vector2.ClampMagnitude(_rigidBody2D.velocity,MaxSpeed);
		_rigidBody2D.velocity = limit;	
	}

	void Rotate(){

		//Torque
		_rigidBody2D.AddTorque(-_rotate * Time.deltaTime *RotateSpeed);
		_rigidBody2D.AddForce(transform.rotation * Vector2.up *_thrust * Speed * Time.deltaTime);
		Vector2 limit = Vector2.ClampMagnitude(_rigidBody2D.velocity,MaxSpeed);
		_rigidBody2D.velocity = limit;	
	}
}

