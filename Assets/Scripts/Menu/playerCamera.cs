using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerCamera : MonoBehaviour
{
    public Toggle[] PlayerToggles;
    public GameObject[] PlayerCameras;

	// Use this for initialization
	void Start ()
	{
        foreach(GameObject playerCamera in PlayerCameras)
        {
            playerCamera.SetActive(false);
        }

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
