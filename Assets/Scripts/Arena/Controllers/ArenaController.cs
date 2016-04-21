using UnityEngine;
using System.Collections;

public class ArenaController : MonoBehaviour
{
    private bool player1;
    private bool player2;

    void Awake()
    {
        GameObject go = GameObject.Find("Menu Manager");
        MenuController menuController = go.GetComponent<MenuController>();
        player1 = menuController.player1.isOn;
        player2 = menuController.player2.isOn;


        Destroy(go);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void bam(){
		Debug.Log("bam");
	}
}
