using UnityEngine;
using System.Collections;
using Rewired;

public class ShootRedLazer : MonoBehaviour {

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
				//Rigidbody2D bulletRb2d = bullet.GetComponent<Rigidbody2D>();
			}
		}			
	}
}
