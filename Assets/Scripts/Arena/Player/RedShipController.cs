﻿using UnityEngine;
using Rewired;

	public class RedShipController : MonoBehaviour {	        		
        public float Speed = 200f;
        public float RotateSpeed = 80f;
        public float MaxSpeed = 8;
		public int PlayerId; // The Rewired player id of this character
        float _thrust;
        float _rotate;

		private Rewired.Player _player; // The Rewired Player
        //bool isCurrentlyTrusting = false;
        Rigidbody2D _rigidBody2D;

		void Awake()
		{
			_player = ReInput.players.GetPlayer(PlayerId);
		}

		public Rewired.Player GetPlayer()
		{
			return _player;
		}
		        	
        // Use this for initialization
        void Start () {
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
