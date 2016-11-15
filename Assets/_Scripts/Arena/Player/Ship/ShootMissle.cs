using UnityEngine;
using System.Collections;
using Rewired;

public class ShootMissle : WeaponBase {

	public string Button;
	private Rewired.Player _player; // The Rewired Player
	public Transform[] Guns; 
	public GameObject projectile;

	private bool fire;

	// Use this for initialization
	void Start () {
		int PlayerId = GetComponent<ShipController>().PlayerId;
		_player = ReInput.players.GetPlayer(PlayerId);
		base.energy = GetComponent<Energy>();
	}

	// Update is called once per frame
	void Update () {
		fire = _player.GetButtonDown(Button);

		if(fire && useEnergy(requriedEnergy)){

			foreach(Transform gun in Guns){
				GameObject bullet = Instantiate(projectile, gun.position, gun.rotation) as GameObject;
				bullet.layer = gameObject.layer;
//				Debug.Log(bullet.layer);
			}
		}			
	}
}
