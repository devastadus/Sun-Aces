using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] clips;

    private AudioSource audioSource;

	// Use this for initialization
	void Start ()
	{
	    audioSource = GetComponent<AudioSource>();
	    int i = Random.Range(0, clips.Length);
	    audioSource.clip = clips[i];
        audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
