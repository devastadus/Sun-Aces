using UnityEngine;
using System.Collections;

public class Astroid : MonoBehaviour {

	AstroidSpawner astroidSpawner;

	// Use this for initialization
	void Start () {
		astroidSpawner = GameObject.Find("Spawners").GetComponent<AstroidSpawner>();
		if(!astroidSpawner)
			Debug.Log("Can not find AstroidSpawner");
		astroidSpawner.AddAstroid(gameObject);
//		Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
//		Vector2 random = new Vector2(Random.Range(-5f,5f),Random.Range(-5f,5f));
//		rb2D.velocity = random;	
//		rb2D.AddTorque(Random.Range(-10f,10));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDestory(){
		astroidSpawner.RemoveAstroid(gameObject);
		//TODO: Remove from array;
	}
}
