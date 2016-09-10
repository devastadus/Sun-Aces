using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hull : MonoBehaviour {

    public int health = 10;
	public int maxHealth = 20;
    public GameObject Death;    
	public Slider slider;

	private TrackObject TrackObject;
	private CameraControl CameraControl;

    void Start()
    {
        TrackObject = GetComponent<TrackObject>();
        CameraControl = GameObject.Find("CameraRig").GetComponent<CameraControl>();

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
            Destroy(gameObject);
            Instantiate(Death, transform.position, Quaternion.identity);
        }
    }

}
