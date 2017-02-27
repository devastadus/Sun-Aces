using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DarkTonic.CoreGameKit;

public class Hull : MonoBehaviour {

    public int health = 10;
	public int maxHealth = 20;
    public GameObject Death;    
	public Slider slider;
    public AudioClip[] Explosions;

	private TrackObject TrackObject;
	private CameraControl CameraControl;
    private AudioSource audioSource;
    private AudioClip explosion;

    private SpriteRenderer sprite;
    private Collider2D collider2D;


    void Start()
    {
        TrackObject = GetComponent<TrackObject>();
        CameraControl = GameObject.Find("CameraRig").GetComponent<CameraControl>();
        audioSource = GetComponent<AudioSource>();
        explosion = Explosions[Random.Range(0, Explosions.Length)];
        sprite = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();



        if (slider)
            slider.value = (float)health / maxHealth;
    }

    public void modifyHealth(int _health)
    {
        health += _health;
		if(health > maxHealth)
			health = maxHealth;

        if (slider)
		    slider.value = (float)health/maxHealth;

        if(health <= 0)
        {
            if (TrackObject != null)
            {
                CameraControl.RemoveFollowableObject(gameObject);
                // remove from camera
            }
            //PoolBoss.Despawn(gameObject);
            AudioClip sound = Explosions[Random.Range(0, Explosions.Length)];
            audioSource.clip = sound;
            audioSource.Play();

            sprite.enabled = false;
            collider2D.enabled = false;

            Instantiate(Death, transform.position, Quaternion.identity);
            Destroy(gameObject, 1f);
        }
    }

}
