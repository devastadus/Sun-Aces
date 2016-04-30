using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerCamera : MonoBehaviour
{
    public Toggle Player1Toggle;
    public Toggle Player2Toggle;

    public GameObject Player1Camera;
    public GameObject Player2Camera;
	// Use this for initialization
	void Start ()
	{
        Player1Camera.SetActive(false);
        Player2Camera.SetActive(false);
        Player1Toggle.onValueChanged.AddListener(Player1Callback);
        Player2Toggle.onValueChanged.AddListener(Player2Callback);

    }
	
	// Update is called once per frame
	void Update ()
	{
       // Debug.Log(playerToggle.isOn);
       // gameObject.SetActive(playerToggle.isOn);
	}

    public void Player1Callback(bool b)
    {
        Player1Camera.SetActive(b);
    }

    public void Player2Callback(bool b)
    {
        Player2Camera.SetActive(b);        
    }
}
