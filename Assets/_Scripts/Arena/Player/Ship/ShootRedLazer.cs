using UnityEngine;
using System.Collections;
using Rewired;

public class ShootRedLazer : WeaponBase {

	public string Button;
	private Rewired.Player _player; // The Rewired Player
	public Transform[] Guns; 
	public GameObject projectile;
    public AudioClip[] Sounds;

	private bool fire;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		int PlayerId = GetComponent<ShipController>().PlayerId;
		_player = ReInput.players.GetPlayer(PlayerId);
        base.energy = GetComponent<Energy>();
	    audioSource = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
		fire = _player.GetButtonDown(Button);
    
		if(fire && useEnergy(requriedEnergy)){
            AudioClip sound = Sounds[Random.Range(0, Sounds.Length)];
            audioSource.clip = sound;
            audioSource.Play();

            foreach (Transform gun in Guns){
				GameObject bullet = Instantiate(projectile, gun.position, gun.rotation) as GameObject;
				RedLazer lazer = bullet.GetComponent<RedLazer>();
			    lazer.speedOfShip = gameObject.GetComponent<Rigidbody2D>().velocity;
			    bullet.layer = gameObject.layer;
			}
		}			
	}
}
