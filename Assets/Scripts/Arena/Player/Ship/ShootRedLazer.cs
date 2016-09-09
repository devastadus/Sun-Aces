using UnityEngine;
using System.Collections;
using Rewired;

public class ShootRedLazer : WeaponBase {

	public string Button;
	private Rewired.Player _player; // The Rewired Player
	public Transform[] Guns; 
	public GameObject projectile;

	private bool fire;

	// Use this for initialization
	void Start () {
		int PlayerId = GetComponent<RedShipController>().PlayerId;
		_player = ReInput.players.GetPlayer(PlayerId);


	}
	
	// Update is called once per frame
	void Update () {
		fire = _player.GetButtonDown(Button);

		if(fire){
			foreach(Transform gun in Guns){
				GameObject bullet = Instantiate(projectile, gun.position, gun.rotation) as GameObject;
				RedLazer lazer = bullet.GetComponent<RedLazer>();
			    lazer.speedOfShip = gameObject.GetComponent<Rigidbody2D>().velocity;
			    bullet.layer = gameObject.layer;
			}
		}			
	}
}
