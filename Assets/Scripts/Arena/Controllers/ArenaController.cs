using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ArenaController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject go = GameObject.Find("Menu Manager");
		MenuController menuController = go.GetComponent<MenuController>();
		Debug.Log(menuController.player1.isOn);
		Debug.Log(menuController.player2.isOn);
		Destroy(go);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void bam(){
		Debug.Log("bam");
	}
}
