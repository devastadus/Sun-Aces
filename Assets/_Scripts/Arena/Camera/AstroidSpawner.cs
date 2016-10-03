using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DarkTonic.CoreGameKit;

public class AstroidSpawner : MonoBehaviour {
	public Transform[] Spawners;
	public List<GameObject> Astroids;
	public int maxAstroids = 20;
	 

	// Use this for initialization
	void Start () {
		Astroids = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {		
	
	}

	public void RemoveAstroid(GameObject obj){
		Astroids.Remove(obj);
	}

	public void AddAstroid(GameObject obj){
		Astroids.Add(obj);
	}
}
