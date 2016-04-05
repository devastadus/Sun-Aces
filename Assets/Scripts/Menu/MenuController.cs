using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public Toggle player1;
	public Toggle player2;
	public Button start;

	void Awake(){
		DontDestroyOnLoad(this);
	}

	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {		
	
	}

	public void buttonClick(){		
		Debug.Log("player1: "+player1.isOn+ "player2: "+player2.isOn);
		SceneManager.LoadScene("Arena");
	}
}
